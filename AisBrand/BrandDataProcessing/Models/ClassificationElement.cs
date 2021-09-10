using System;
using System.Collections.Generic;

namespace BrandDataProcessing.Models
{
    [Serializable]
    public class ClassificationElement
    {
        public int ID { get; set; }
        // TODO: удостовериться
        public int ClassificationID { get; set; }

        public string Type { get; set; }

        public string Variant { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public List<Application> Applications { get; set; }
    }
}
