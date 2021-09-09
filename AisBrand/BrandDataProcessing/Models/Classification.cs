using System;

namespace BrandDataProcessing.Models
{
    [Serializable]
    public class Classification
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }
    }
}
