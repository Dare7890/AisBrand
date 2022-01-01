using BrandDataProcessing.Models;
using BrandDataProcessingBL.EventArgs;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BrandDataProcessingBL
{
    public interface ISearchView
    {
        //  TODO: подумать над обобщением.
        IEnumerable BrandDataList { get; set; }

        string GetFilePath();
        event EventHandler<FillEventArgs> FillExcavationsList;
        event EventHandler<DeleteExcavationEventArgs> DeleteExcavation;
        event EventHandler<AddExcavationEventArgs> AddExcavation;
        event EventHandler<UpdateExcavationEventArgs> UpdateExcavation;

        event EventHandler<FillEventArgs> FillFindsClassListEvent;
    }
}