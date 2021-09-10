using System;

namespace BrandDataProcessing.Models
{
    [Serializable]
    public class Application
    {
        public Classification Classification { get; set; }

        public byte[] File { get; set; }
    }
}
