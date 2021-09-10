using System;

namespace BrandDataProcessing.Models
{
    [Serializable]
    public class ClassifiedBrand
    {
        public int BrandID { get; set; }

        public ClassificationElement ClassificationElement { get; set; }
    }
}
