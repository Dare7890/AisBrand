using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using BrandDataProcessing;
using BrandDataProcessing.Models;

namespace BrandDataProcessing.DAL
{
    public class ClassificationLocal
    {
        private const string RootElementName = "ArrayOfExcavation";
        private readonly string fileName;
        //TODO: избавиться от filepath, будет скорее всего только то, что внутри конкртеных раскопок.
        public ClassificationLocal(string fileName)
        {
            this.fileName = fileName;
        }

        public void Add(Classification classification, int excavationID)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification));

            XDocument xmlDocument = XDocument.Load(fileName);
            IEnumerable<Classification> classifications = GetClassifications(xmlDocument);
            int classificationsID = GetNextElementID(classifications);
            XElement element = new XElement(nameof(Classification),
                new XElement(nameof(classification.ID), classificationsID),
                new XElement(nameof(classification.Name), classification.Name),
                new XElement(nameof(classification.Author), classification.Author)
                );

            xmlDocument.Element(RootElementName)
                .Elements(nameof(Excavation))
                .FirstOrDefault(e => int.Parse(e.Element("ID").Value) == excavationID)
                ?.Add(element);

            xmlDocument.Save(fileName);
        }

        public void Delete(int id)
        {
            XDocument xmlDocument = XDocument.Load(fileName);
            xmlDocument.Element(RootElementName)
                .Elements(nameof(Excavation))
                .Elements(nameof(Classification))
                .FirstOrDefault(b => int.Parse(b.Element("ID").Value) == id)
                ?.Remove();

            xmlDocument.Save(fileName);
        }

        public void Update(Classification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification));

            XDocument xmlDocument = XDocument.Load(fileName);
            XElement updatedClassification = xmlDocument.Element(RootElementName)
                                        .Elements(nameof(Excavation))
                                        .Elements(nameof(Classification))
                                        .FirstOrDefault(b => int.Parse(b.Element("ID").Value) == classification.ID);

            if (updatedClassification != null)
            {
                updatedClassification.Element(nameof(classification.Name)).Value = classification.Name;
                updatedClassification.Element(nameof(classification.Author)).Value = classification.Author;

                xmlDocument.Save(fileName);
            }
        }

        private static IEnumerable<Classification> GetClassifications(XDocument xmlDocument)
        {
            return Serializated<Classification>.XmlDeserialization(xmlDocument.Element(RootElementName)
                                                                        .Elements(nameof(Excavation))
                                                                        .Elements(nameof(Classification)));
        }

        private static int GetNextElementID(IEnumerable<Classification> classifications)
        {
            return GetMaxClassificationID(classifications) + 1;
        }

        private static int GetMaxClassificationID(IEnumerable<Classification> classifications)
        {
            return classifications.Count() == 0 ? 0 : classifications.Max(i => i.ID);
        }
    }
}
