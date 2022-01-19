using System;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace BrandDataProcessing.Models
{
    [Serializable]
    [TranslatedName("Клеймо")]
    public class Brand : IIdentifier/*, IXmlSerializable*/
    {
        public int ID { get; set; }

        public string Clay { get; set; }

        public string Admixture { get; set; }

        public string Sprinkling { get; set; }

        public string Safety { get; set; }

        public string Relief { get; set; }

        public string ReconstructionReliability { get; set; }

        //public XmlSchema GetSchema()
        //{
        //    return null;
        //}

        //public void ReadXml(XmlReader reader)
        //{
        //    reader.MoveToContent();
        //    reader.MoveToElement();
        //    reader.ReadStartElement();
        //    ID = int.Parse(reader.ReadElementContentAsString());
        //    Formation = ChangeEmptyToNull(reader.ReadElementContentAsString());
        //    SquareText = reader.ReadElementContentAsString();
        //    DepthText = reader.ReadElementContentAsString();
        //    FieldNumber = ChangeEmptyToNull(reader.ReadElementContentAsString());
        //    CollectorsNumber = ChangeEmptyToNull(reader.ReadElementContentAsString());
        //    Clay = ChangeEmptyToNull(reader.ReadElementContentAsString());
        //    Admixture = ChangeEmptyToNull(reader.ReadElementContentAsString());
        //    Sprinkling = ChangeEmptyToNull(reader.ReadElementContentAsString());
        //    Safety = ChangeEmptyToNull(reader.ReadElementContentAsString());
        //    Relief = ChangeEmptyToNull(reader.ReadElementContentAsString());
        //    ReconstructionReliability = reader.ReadElementContentAsString();
        //    DatingLowerBoundText = reader.ReadElementContentAsString();
        //    DatingUpperBoundText = reader.ReadElementContentAsString();
        //    Description = ChangeEmptyToNull(reader.ReadElementContentAsString());
        //    Analogy = ChangeEmptyToNull(reader.ReadElementContentAsString());
        //    Note = ChangeEmptyToNull(reader.ReadElementContentAsString());
        //    Image = Encoding.UTF8.GetBytes(reader.ReadElementContentAsString());
        //    Photo = Encoding.UTF8.GetBytes(reader.ReadElementContentAsString());
        //}

        //public void WriteXml(XmlWriter writer)
        //{
        //    throw new NotImplementedException();
        //}

        //private string ChangeEmptyToNull(string line)
        //{
        //    return line == string.Empty ? null : line;
        //}
    }
}
