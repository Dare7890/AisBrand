namespace Tools.EventArgs
{
    public class UpdateEventArgs<T> : System.EventArgs
    {
        public string FilePath { get; set; }

        public T SourceBrandData { get; set; }

        public T UpdatedBrandData { get; set; }

        public UpdateEventArgs(string filePath, T sourceBrandData, T updatedBrandData)
        {
            FilePath = filePath;
            SourceBrandData = sourceBrandData;
            UpdatedBrandData = updatedBrandData;
        }
    }
}
