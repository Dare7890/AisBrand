using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using BrandDataProcessing.Models;

namespace BrandDataProcessing.DAL
{
    public class ExcavationLocal
    {
        private const string RootElementName = "ArrayOfExcavation";
        private readonly string fileName;

        public ExcavationLocal(string fileName)
        {
            this.fileName = fileName;
        }

        public void Add(Excavation excavation)
        {
            // Загружаем данные xml файла
            // Перейти к последнему brand
            // Добавить новый brand

            if (excavation == null)
                throw new ArgumentNullException(nameof(excavation));

            XDocument xmlDocument = XDocument.Load(fileName);
            IEnumerable<Excavation> excavations = GetExcavations(xmlDocument);
            int elementID = GetNextElementID(excavations);

            XElement element = new XElement(nameof(Excavation),
                new XElement(nameof(excavation.ID), elementID),
                new XElement(nameof(excavation.Name), excavation.Name),
                new XElement(nameof(excavation.Monument), excavation.Monument)
                );

            xmlDocument.Element(RootElementName).Add(element);
            xmlDocument.Save(fileName);
        }

        public void Delete(int id)
        {
            XDocument xmlDocument = XDocument.Load(fileName);
            IEnumerable<XElement> excavations = xmlDocument.Element(RootElementName).Elements(nameof(Excavation));
            excavations.FirstOrDefault(b => int.Parse(b.Element("ID").Value) == id)?.Remove();
            xmlDocument.Save(fileName);
        }

        public void Update(Excavation excavation)
        {
            if (excavation == null)
                throw new ArgumentNullException(nameof(excavation));

            XDocument xmlDocument = XDocument.Load(fileName);
            IEnumerable<XElement> excavations = xmlDocument.Element(RootElementName).Elements(nameof(Excavation));
            XElement updatedExcavation = excavations.FirstOrDefault(b => int.Parse(b.Element(nameof(excavation.ID)).Value) == excavation.ID);

            updatedExcavation.Element(nameof(excavation.Name)).Value = excavation.Name;
            updatedExcavation.Element(nameof(excavation.Monument)).Value = excavation.Monument;
            xmlDocument.Save(fileName);
        }

        private static IEnumerable<Excavation> GetExcavations(XDocument xmlDocument)
        {
            return Serializated<Excavation>.XmlDeserialization(xmlDocument.Element(RootElementName)
                                                                        .Elements(nameof(Excavation)));
        }

        private static int GetNextElementID(IEnumerable<Excavation> excavations)
        {
            return GetMaxExcavationID(excavations) + 1;
        }

        private static int GetMaxExcavationID(IEnumerable<Excavation> excavations)
        {
            return excavations.Max(i => i.ID);
        }
    }
}
