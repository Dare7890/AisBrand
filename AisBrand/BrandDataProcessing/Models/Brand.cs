using System;
using System.Text;
using System.Xml.Serialization;

namespace BrandDataProcessing.Models
{
    [Serializable]
    public class Brand : IIdentifier
    {
        public int ID { get; set; }

        public string Formation { get; set; }

        public int Square { get; set; }

        public int Depth { get; set; }

        public string FieldNumber { get; set; }

        public string CollectorsNumber { get; set; }

        public string Clay { get; set; }

        public string Admixture { get; set; }

        public string Sprinkling { get; set; }

        public string Safety { get; set; }

        public string Relief { get; set; }

        public string ReconstructionReliability { get; set; }

        public int DatingLowerBound { get; set; }

        public int DatingUpperBound { get; set; }

        public string Description { get; set; }
        [XmlIgnore]
        public string ImageAsString { get; set; }
        [XmlIgnore]
        public string PhotoAsString { get; set; }

        public string Analogy { get; set; }

        public string Note { get; set; }

        [XmlElement(ElementName = "ImageAsString", DataType = "hexBinary")]
        public byte[] Image
        {
            get { return Encoding.UTF8.GetBytes(ImageAsString ?? string.Empty); }
            set { ImageAsString = Encoding.UTF8.GetString(value); }
        }

        [XmlElement(ElementName = "PhotoAsString", DataType = "hexBinary")]
        public byte[] Photo
        {
            get { return Encoding.UTF8.GetBytes(PhotoAsString ?? string.Empty); }
            set { PhotoAsString = Encoding.UTF8.GetString(value); }
        }
    }
}
