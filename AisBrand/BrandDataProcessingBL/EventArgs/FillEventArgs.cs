namespace BrandDataProcessingBL.EventArgs
{
    public class FillEventArgs : System.EventArgs
    {
        public string FilePath { get; set; }

        public FillEventArgs(string filePath)
        {
            FilePath = filePath;
        }
    }
}