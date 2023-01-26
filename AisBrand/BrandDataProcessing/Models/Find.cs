using System;
using System.Xml.Serialization;

namespace BrandDataProcessing.Models
{
    [Serializable]
    [TranslatedName("Керамика ")]
    public class Find : IIdentifier
    {
        public int ID { get; set; }

        public string Formation { get; set; }

        [XmlIgnore]
        public int? Square { get; set; }

        [XmlElement(nameof(Square))]
        public string SquareText
        {
            get { return Square.HasValue ? Square.ToString() : null; }
            set { Square = !string.IsNullOrEmpty(value) ? int.Parse(value) : null; }
        }

        [XmlIgnore]
        public int? Depth { get; set; }

        [XmlElement(nameof(Depth))]
        public string DepthText
        {
            get { return Depth.HasValue ? Depth.ToString() : null; }
            set { Depth = !string.IsNullOrEmpty(value) ? int.Parse(value) : null; }
        }

        public string FieldNumber { get; set; }

        public string CollectorsNumber { get; set; }

        public DatingBound DatingBound { get; set; }

        public string Description { get; set; }

        [XmlIgnore]
        public string ImageAsString { get; set; }

        [XmlIgnore]
        public string PhotoAsString { get; set; }

        public string Analogy { get; set; } = "1";

        public string Note { get; set; }

        [XmlElement(ElementName = "ImageAsString", DataType = "hexBinary")]
        public byte[] Image { get; set; }

        [XmlElement(ElementName = "PhotoAsString", DataType = "hexBinary")]
        public byte[] Photo { get; set; }

        public Brand Brand { get; set; }

        public AditionalBrand AditionalBrand { get; set; }
    }
}
