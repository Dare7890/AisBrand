namespace Tools.EventArgs
{
    public class AddEventArgs<T> : System.EventArgs
    {
        public string FilePath { get; }

        public T BrandData { get; }

        public int? ParentId { get; set; }

        public AddEventArgs(string filePath, T brandData, int? parentId = null)
        {
            FilePath = filePath;
            BrandData = brandData;
            ParentId = parentId;
        }
    }
}