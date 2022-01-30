using System.Collections.Generic;
using System.Xml.Serialization;

namespace BrandDataProcessing.Models
{
    [TranslatedName("Категории предметов")]
    public class FindsClass : IIdentifier
    {
        public int ID { get; set; }

        public string Class { get; set; }

        [XmlElement("Classification")]
        public List<Classification> Classifications { get; set; }
    }
}
