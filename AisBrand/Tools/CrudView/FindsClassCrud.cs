using AddBrandDataUI;
using AddBrandDataUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tools.EventArgs;
using Tools.Map;
using FindsClassModel = BrandDataProcessing.Models.FindsClass;

namespace Tools.CrudView
{
    public class FindsClassCrud : BrandDataCrud<FindsClass>
    {
        public FindsClassModel FindsClass { get; set; }

        public event EventHandler<GetFindClassEventArgs> GetFindClass;
        public event EventHandler<AddEventArgs<FindsClass>> AddEmptyFindsClass;

        public FindsClassModel GetFindClassById(int findsClassId)
        {
            OnGetFindClass(findsClassId);
            return FindsClass;
        }

        private void OnGetFindClass(int findsClassId)
        {
            if (GetFindClass != null)
                GetFindClass.Invoke(this, new GetFindClassEventArgs(findsClassId));
        }

        public override void Add(Form owner, IMapper<FindsClass> mapper, IEnumerable<string> types = null, FindsClassModel findsClass = null)
        {
            if (FilePath == null)
                return;

            using (AddBrandDataForm<FindsClass> form = new AddBrandDataForm<FindsClass>(types: types, parent: findsClass))
            {
                if (form.ShowDialog(owner) == DialogResult.OK)
                {
                    try
                    {
                        FindsClass brandData = mapper.Map(form);

                        if (form.IsCopyData())
                            OnAdd(brandData);
                        else
                            OnAddEmptyFindsClass(brandData);
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

        protected void OnAddEmptyFindsClass(FindsClass findsClass, int? parentId = null)
        {
            if (AddEmptyFindsClass != null)
                AddEmptyFindsClass.Invoke(this, new AddEventArgs<FindsClass>(FilePath, findsClass, parentId));
        }
    }
}
