using System;

namespace BrandDataProcessing.Models
{
    [Serializable]
    [TranslatedName("Клеймо")]
    [Category("Керамика")]
    public class Brand : IIdentifier
    {
        public int ID { get; set; }

        public string Clay { get; set; }

        public string Admixture { get; set; }

        public string Sprinkling { get; set; }

        public string Safety { get; set; }

        public string Relief { get; set; }

        public string ReconstructionReliability { get; set; }
    }
}
