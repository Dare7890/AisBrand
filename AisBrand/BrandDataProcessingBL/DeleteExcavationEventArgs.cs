namespace BrandDataProcessingBL
{
    public class DeleteExcavationEventArgs
    {
        public string FilePath { get; set; }

        public int DeletedLineIndex { get; set; }

        public DeleteExcavationEventArgs(string filePath, int deletedLineIndex)
        {
            FilePath = filePath;
            DeletedLineIndex = deletedLineIndex;
        }
    }
}