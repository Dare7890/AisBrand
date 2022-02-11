using AddBrandDataUI;
using AddBrandDataUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tools.EventArgs;
using Tools.Map;

namespace Tools.CrudView
{
    public class FindCrud : BrandDataCrud<Find>
    {
        public int ClassificationId { get; set; }

        public event EventHandler<GetIdEventArgs<Classification>> GetClassificationId;

        public override void Add(Form owner, IMapper<Find> mapper, IEnumerable<string> types = null, BrandDataProcessing.Models.FindsClass findsClass = null)
        {
            if (FilePath == null)
                return;

            using (AddBrandDataForm<Find> form = new AddBrandDataForm<Find>(types: types, parent: findsClass))
            {
                if (form.ShowDialog(owner) == DialogResult.OK)
                {
                    try
                    {
                        Find find = mapper.Map(form);
                        GetParentClassificationId(form);
                        OnAdd(find, ClassificationId);
                    }
                    catch (InvalidOperationException)
                    {
                        NotifyAboutExistsSameExcavation();
                        Add(owner, mapper, types);
                    }
                }

                form.Close();
            }
        }

        private void GetParentClassificationId(AddBrandDataForm<Find> form)
        {
            Classification classification = form.GetParentClassification();
            OnGetClassificationId(classification);
        }

        protected virtual void OnGetClassificationId(Classification classification)
        {
            if (GetClassificationId != null)
                GetClassificationId.Invoke(this, new GetIdEventArgs<Classification>(FilePath, classification));
        }
    }
}
