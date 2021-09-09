using System.IO;
using NUnit.Framework;
using BrandDataProcessing;
using BrandDataProcessing.Models;
using System;

namespace BrandDataProcessingTests
{
    [TestFixture]
    public class SerializatedTests
    {
        [Test]
        public void TestXmlSerialization_Classification_Serialize()
        {
            const string fileName = "Test.xml";
            string filePath = Path.Combine(Environment.CurrentDirectory, fileName);

            Classification classification = new Classification();
            classification.ID = 1;
            classification.Name = "Classification";
            classification.Author = "Ivan Ivanov";

            Serializated<Classification>.XmlSerialization(filePath, classification);
        }
    }
}