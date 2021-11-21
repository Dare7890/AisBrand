using System;

namespace BrandDataProcessingBL
{
    public class FillExcavationsEventArgs : EventArgs
    {
        public string FilePath { get; set; }

        public FillExcavationsEventArgs(string filePath)
        {
            FilePath = filePath;
        }
    }
}