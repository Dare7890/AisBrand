using System;
using System.IO;
using System.Xml.Serialization;

namespace BrandDataProcessing
{
    public static class Serializated<T>
        where T : class
    {
        public static void XmlSerialization(string filePath, T obj)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                formatter.Serialize(stream, obj);
        }

        public static T XmlDeserialization(string filePath)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                return (T)formatter.Deserialize(stream);
        }
    }
}