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

        public List<Classification> Classifications { get; set; }

        public Excavation() { }

        public Excavation(int id, string name, string monument)
        {
            ID = id;
            Name = name;
            Monument = monument;
        }
    }
}
