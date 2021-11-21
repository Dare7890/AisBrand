using System;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BrandDataProcessing.Models
{
    [Serializable]
    public class Brand : IIdentifier, IXmlSerializable
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

        public string Clay { get; set; }

        public string Admixture { get; set; }

        public string Sprinkling { get; set; }

        public string Safety { get; set; }

        public string Relief { get; set; }

        public string ReconstructionReliability { get; set; }

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

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            reader.MoveToElement();
            reader.ReadStartElement();
            ID = int.Parse(reader.ReadElementContentAsString());
            Formation = ChangeEmptyToNull(reader.ReadElementContentAsString());
            SquareText = reader.ReadElementContentAsString();
            DepthText = reader.ReadElementContentAsString();
            FieldNumber = ChangeEmptyToNull(reader.ReadElementContentAsString());
            CollectorsNumber = ChangeEmptyToNull(reader.ReadElementContentAsString());
            Clay = ChangeEmptyToNull(reader.ReadElementContentAsString());
            Admixture = ChangeEmptyToNull(reader.ReadElementContentAsString());
            Sprinkling = ChangeEmptyToNull(reader.ReadElementContentAsString());
            Safety = ChangeEmptyToNull(reader.ReadElementContentAsString());
            Relief = ChangeEmptyToNull(reader.ReadElementContentAsString());
            ReconstructionReliability = reader.ReadElementContentAsString();
            DatingLowerBoundText = reader.ReadElementContentAsString();
            DatingUpperBoundText = reader.ReadElementContentAsString();
            Description = ChangeEmptyToNull(reader.ReadElementContentAsString());
            Analogy = ChangeEmptyToNull(reader.ReadElementContentAsString());
            Note = ChangeEmptyToNull(reader.ReadElementContentAsString());
            Image = Encoding.UTF8.GetBytes(reader.ReadElementContentAsString());
            Photo = Encoding.UTF8.GetBytes(reader.ReadElementContentAsString());
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        private string ChangeEmptyToNull(string line)
        {
            return line == string.Empty ? null : line;
        }
    }
}
