using BrandDataProcessing.Models;

namespace BrandDataProcessingBL
{
    public class AddExcavationEventArgs
    {
        public string FilePath { get; }

        public Excavation Excavation { get; }

        public AddExcavationEventArgs(string filePath, Excavation excavation)
        {
            FilePath = filePath;
            Excavation = excavation;
        }
    }
}