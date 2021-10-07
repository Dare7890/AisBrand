﻿using System;
using System.Text;
using System.Xml.Serialization;

namespace BrandDataProcessing.Models
{
    [Serializable]
    public class Application : IIdentifier
    {
        public int ID { get; set; }

        public int ClassificationID { get; set; }

        [XmlIgnore]
        public string FileAsString { get; set; }

        [XmlElement(ElementName = "FileAsString", DataType = "hexBinary")]
        public byte[] File
        {
            get { return Encoding.UTF8.GetBytes(FileAsString ?? string.Empty); }
            set { FileAsString = Encoding.UTF8.GetString(value); }
        }
    }
}
