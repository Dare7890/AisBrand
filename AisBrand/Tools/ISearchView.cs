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

        ExcavationCrud ExcavationCrud { get; }
        BrandDataCrud<AddBrandDataUI.ViewModels.FindsClass> FindsClassCrud { get; }
        ClassificationCrud ClassificationCrud { get; }
    }
}