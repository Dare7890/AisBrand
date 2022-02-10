using AddBrandDataUI.ViewModels;
using System;
using Tools.EventArgs;
using FindsClassModel = BrandDataProcessing.Models.FindsClass;

namespace Tools.CrudView
{
    public class FindsClassCrud : BrandDataCrud<FindsClass>
    {
        public FindsClassModel FindsClass { get; set; }

        public event EventHandler<GetFindClassEventArgs> GetFindClass;

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
    }
}
