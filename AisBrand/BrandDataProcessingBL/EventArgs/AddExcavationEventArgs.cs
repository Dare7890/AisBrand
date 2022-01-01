using AddBrandDataUI.ViewModels;

namespace BrandDataProcessingBL.EventArgs
{
    public class AddExcavationEventArgs<T> : System.EventArgs
    {
        public string FilePath { get; }

        public T BrandData { get; }

        public AddExcavationEventArgs(string filePath, T brandData)
        {
            FilePath = filePath;
            BrandData = brandData;
        }
    }
}