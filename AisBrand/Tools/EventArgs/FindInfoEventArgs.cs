using AddBrandDataUI.ViewModels;

namespace Tools.EventArgs
{
    public class FindInfoEventArgs : System.EventArgs
    {
        public string FilePath { get; }

        public Find Find { get; set; }

        public BrandDataProcessing.Models.FindsClass FindsClass { get; set; }

        public FindInfoEventArgs(string filePath, Find find, BrandDataProcessing.Models.FindsClass findsClass)
        {
            FilePath = filePath;
            Find = find;
            FindsClass = findsClass;
        }
    }
}
