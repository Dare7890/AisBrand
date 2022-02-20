using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BrandDataProcessing.Models
{
    [Serializable]
    [TranslatedName("Классификация")]
    public class Classification : IIdentifier, IEquatable<Classification>
    {
        public int ID { get; set; }

        public string Type { get; set; }

        public string Variant { get; set; }

        public string Description { get; set; }

        [XmlIgnore]
        public string ImageAsString { get; set; }

        [XmlElement(ElementName = "ImageAsString", DataType = "hexBinary")]
        public byte[] Image { get; set; }

        [XmlElement("Find")]
        public List<Find> Finds { get; set; }

        public bool Equals(Classification other)
        {
            if (object.ReferenceEquals(other, null))
                return false;

            return Type == other.Type && Variant == other.Variant;
        }

        public override int GetHashCode()
        {
            int typeHash = Type.GetHashCode();
            int variantHash = Variant.GetHashCode();

            return typeHash ^ variantHash;
        }

        public static bool operator ==(Classification a, Classification b)
        {
            if (object.ReferenceEquals(a, b))
                return true;

            if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Classification a, Classification b)
        {
            return !(a == b);
        }
    }
}
