using System;

namespace BrandDataProcessing.Models
{
    [Serializable]
    public class Brand
    {
        public int ID { get; set; }

        public string Formation { get; set; }

        public int Square { get; set; }

        public int Depth { get; set; }

        public string FieldNumber { get; set; }

        public string CollectorsNumber { get; set; }

        public string Clay { get; set; }

        public string Admixture { get; set; }

        public string Sprinkling { get; set; }

        public string Safety { get; set; }

        public string Relief { get; set; }

        public string ReconstructionReliability { get; set; }

        public int DatingLowerBound { get; set; }

        public int DatingUpperBound { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public byte[] Photo { get; set; }

        public string Analogy { get; set; }

        public string Note { get; set; }

        public ClassifiedBrand ClassifiedBrand { get; set; }
    }
}
