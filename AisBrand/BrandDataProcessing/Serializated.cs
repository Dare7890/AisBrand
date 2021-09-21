using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
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

        public static IEnumerable<T> XmlDeserialization(IEnumerable<XElement> elements)
        {
            if (elements == null)
                throw new ArgumentNullException(nameof(elements));

            List<T> objects = new List<T>();
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            foreach (XElement obj in elements)
            {
                T deserializedObject = (T)formatter.Deserialize(obj.CreateReader());
                objects.Add(deserializedObject);
            }

            return objects;
        }
    }
}