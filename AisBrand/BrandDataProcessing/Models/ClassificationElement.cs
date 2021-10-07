using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BrandDataProcessing.Models
{
    [Serializable]
    public class ClassificationElement : IIdentifier
    {
        public int ID { get; set; }

        public string Type { get; set; }

        public string Variant { get; set; }

        public string Description { get; set; }

        [XmlIgnore]
        public string ImageAsString { get; set; }

        public List<Brand> Brands { get; set; }

        [XmlElement(ElementName = "ImageAsString", DataType = "hexBinary")]
        public byte[] Image
        {
            get { return Encoding.UTF8.GetBytes(ImageAsString ?? string.Empty); }
            set { ImageAsString = Encoding.UTF8.GetString(value); }
        }
    }
}
