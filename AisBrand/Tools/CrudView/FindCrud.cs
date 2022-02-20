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
        public event EventHandler<FindInfoEventArgs> GetFullFindInfo;

        public override void Add(Form owner, IMapper<Find> mapper, IEnumerable<string> types = null, BrandDataProcessing.Models.FindsClass findsClass = null)
        {
            if (FilePath == null)
                return;

            using (AddBrandDataForm<Find> form = new AddBrandDataForm<Find>(types: types, parent: findsClass))
            {
                if (form.ShowDialog(owner) == DialogResult.OK)
                    Add(owner, mapper, form, types, findsClass);

                form.Close();
            }
        }

        public void Add(Form owner, IMapper<Find> mapper, AddBrandDataForm<Find> form, IEnumerable<string> types = null, BrandDataProcessing.Models.FindsClass findsClass = null)
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
                Add(owner, mapper, form, types, findsClass);
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

        public void OnGetFullFindInfo(Find find, BrandDataProcessing.Models.FindsClass findsClas)
        {
            if (FilePath == null)
                return;

            if (GetFullFindInfo != null)
                GetFullFindInfo.Invoke(this, new FindInfoEventArgs(FilePath, find, findsClas));
        }

        public virtual void Update(Form owner, IMapper<Find> mapper, Find find, BrandDataProcessing.Models.FindsClass findsClass)
        {
            if (FilePath == null)
                return;

            using (AddBrandDataForm<Find> form = new AddBrandDataForm<Find>(find, parent: findsClass))
                base.Update(owner, mapper, find, form);
        }
    }
}
