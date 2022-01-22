using System;
using System.IO;
using System.Reflection;

namespace BrandDataProcessingUI
{
    public class DataFileManager
    {
        public string FilePath { get; } = "../../../../../Data.xml";

        public void Create()
        {
            if (!File.Exists(FilePath))
                using (File.Create(FilePath)) { }
        }

        public bool IsEmpty()
        {
            return new FileInfo(FilePath).Length == 0;
        }
    }
}
