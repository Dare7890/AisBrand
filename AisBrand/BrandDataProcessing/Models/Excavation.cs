using System;
using System.Collections.Generic;

namespace BrandDataProcessing.Models
{
    [Serializable]
    [TranslatedName("Археологические объекты")]
    public class Excavation : IIdentifier
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Monument { get; set; }

        public List<FindsClass> FindsClasses { get; set; }

        public Excavation() { }

        public Excavation(int id, string name, string monument)
        {
            ID = id;
            Name = name;
            Monument = monument;
        }
    }
}
