using BrandDataProcessing.Models;
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
        event EventHandler<FillExcavationsEventArgs> FillExcavationsList;
        event EventHandler<DeleteExcavationEventArgs> DeleteExcavation;
        event EventHandler<AddExcavationEventArgs> AddExcavation;
        event EventHandler<UpdateExcavationEventArgs> UpdateExcavation;
    }
}