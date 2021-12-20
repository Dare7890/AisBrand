using AddBrandDataUI.ViewModels;
using System;

//TODO: перенести viewModel в другую библиотеку.

namespace BrandDataProcessingBL
{
    public class DeleteExcavationEventArgs : EventArgs
    {
        public string FilePath { get; set; }

        public Excavation DeletedExcavation { get; set; }

        public DeleteExcavationEventArgs(string filePath, Excavation excavation)
        {
            FilePath = filePath;
            DeletedExcavation = excavation;
        }
    }
}