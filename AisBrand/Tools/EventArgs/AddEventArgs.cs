namespace Tools.EventArgs
{
    public class AddEventArgs<T> : System.EventArgs
    {
        public string FilePath { get; }

        public T BrandData { get; }

        public AddEventArgs(string filePath, T brandData)
        {
            FilePath = filePath;
            BrandData = brandData;
        }
    }
}