using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BrandDataProcessing.Models
{
    [Serializable]
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

        [XmlIgnore]
        public int? DatingLowerBound { get; set; }

        [XmlElement(nameof(DatingLowerBound))]
        public string DatingLowerBoundText
        {
            get { return DatingLowerBound.HasValue ? DatingLowerBound.ToString() : null; }
            set { DatingLowerBound = !string.IsNullOrEmpty(value) ? int.Parse(value) : null; }
        }

        [XmlIgnore]
        public int? DatingUpperBound { get; set; }

        [XmlElement(nameof(DatingUpperBound))]
        public string DatingUpperBoundText
        {
            get { return DatingUpperBound.HasValue ? DatingUpperBound.ToString() : null; }
            set { DatingUpperBound = !string.IsNullOrEmpty(value) ? int.Parse(value) : null; }
        }

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

        public List<Brand> Brands { get; set; }

        public List<AditionalBrand> AditionalBrands { get; set; }
    }
}
