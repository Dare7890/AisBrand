using AddBrandDataUI.ViewModels;

namespace Tools.EventArgs
{
    public class FindInfoEventArgs : System.EventArgs
    {
        public string FilePath { get; }

        public Find Find { get; set; }

        public BrandDataProcessing.Models.FindsClass FindsClass { get; set; }

        public string FieldNumber { get; set; }

        public FindInfoEventArgs(string filePath, Find find, BrandDataProcessing.Models.FindsClass findsClass, string fieldNumber = null)
        {
            FilePath = filePath;
            Find = find;
            FindsClass = findsClass;
            FieldNumber = fieldNumber;
        }
    }
}
