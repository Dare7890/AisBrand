namespace Tools.EventArgs
{
    public class GetIdEventArgs<T> : System.EventArgs
    {
        public string FilePath { get; set; }

        public T BrandData { get; set; }

        public GetIdEventArgs(string filePath, T brandData)
        {
            FilePath = filePath;
            BrandData = brandData;
        }
    }
}
