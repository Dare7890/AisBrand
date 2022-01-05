using System;
using System.Collections;
using System.Collections.Generic;
using Tools.CrudView;

namespace Tools
{
    public interface ISearchView
    {
        //  TODO: подумать над обобщением.
        IEnumerable BrandDataList { get; set; }
        int? SelectedParentId { get; set; }

        string GetFilePath();
        BrandDataCrud<AddBrandDataUI.ViewModels.Excavation> ExcavationCrud { get; }
        BrandDataCrud<AddBrandDataUI.ViewModels.FindsClass> FindsClassCrud { get; }
    }
}