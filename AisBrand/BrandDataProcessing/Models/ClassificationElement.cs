using System;
using System.Collections.Generic;

namespace BrandDataProcessing.Models
{
    [Serializable]
    public class ClassificationElement
    {
        public int ID { get; set; }

        public string Type { get; set; }

        public string Variant { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public Classification Classification { get; set; }
    }
}
