using System;
using System.Collections.Generic;

namespace BrandDataProcessing.Models
{
    [Serializable]
    public class Excavation : IIdentifier
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Monument { get; set; }

        public List<Brand> Brands { get; set; }
    }
}
