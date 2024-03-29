﻿using System.Collections;
using System.Collections.Generic;
using BrandDataProcessing.Models;
using Tools.CrudView;

namespace Tools
{
    public interface ISearchView
    {
        //  TODO: подумать над обобщением.
        IEnumerable BrandDataList { get; set; }
        Dictionary<string, string> Properties { set; }
        int? SelectedParentId { get; set; }
        IEnumerable<Excavation> AllExcavations { get; set; }

        ExcavationCrud ExcavationCrud { get; }
        FindsClassCrud FindsClassCrud { get; }
        ClassificationCrud ClassificationCrud { get; }
        FindCrud FindCrud { get; }
    }
}