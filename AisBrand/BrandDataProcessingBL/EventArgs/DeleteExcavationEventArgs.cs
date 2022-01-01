using AddBrandDataUI.ViewModels;

//TODO: перенести viewModel в другую библиотеку.

namespace BrandDataProcessingBL.EventArgs
{
    public class DeleteExcavationEventArgs : System.EventArgs
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