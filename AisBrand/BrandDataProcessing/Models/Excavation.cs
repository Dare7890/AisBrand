using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BrandDataProcessing.Models
{
    [Serializable]
    [TranslatedName("Археологические объекты")]
    public class Excavation : IIdentifier
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Monument { get; set; }

        [XmlElement("FindsClass")]
        public List<FindsClass> FindsClasses { get; set; }

        public Excavation() { }

        public Excavation(int id, string name, string monument)
        {
            ID = id;
            Name = name;
            Monument = monument;
        }

        public Excavation(Excavation excavation)
        {
            ID = excavation.ID;
            Name = excavation.Name;
            Monument = excavation.Monument;
            FindsClasses = new List<FindsClass>(excavation.FindsClasses);
        }
    }
}
