using BrandDataProcessing.Models;
using System;
using System.Collections.Generic;

namespace BrandDataProcessingBL
{
    public interface ISearchView
    {
        IList<Excavation> CustomerList { get; set; }

        string GetFilePath();
        event EventHandler<FillExcavationsEventArgs> FillExcavationsList;
    }
}
