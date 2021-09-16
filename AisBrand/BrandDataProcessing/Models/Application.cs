using System;

namespace BrandDataProcessing.Models
{
    [Serializable]
    public class Application
    {
        public int ClassificationID { get; set; }

        public byte[] File { get; set; }
    }
}
