namespace Tools.EventArgs
{
    public class FillClassificationEventArgs : System.EventArgs
    {
        public string FilePath { get; }

        public string Type { get; }

        public string Variant { get; }

        public FillClassificationEventArgs(string filePath, string type, string variant)
        {
            FilePath = filePath;
            Type = type;
            Variant = variant;
        }
    }
}
