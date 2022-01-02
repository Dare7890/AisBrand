using BrandDataProcessing.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace BrandDataProcessing.DAL
{
    public class ExcavationLocal : IRepository<Excavation>
    {
        private const string rootElementName = "ArrayOfExcavation";
        private readonly string fileName;
        private readonly Query<Excavation> query;

        public ExcavationLocal(string fileName)
        {
            this.fileName = fileName;
            if (!File.Exists(fileName))
            {
                using (File.Create(fileName)) { }
                XDocument newXml = new XDocument(new XElement(rootElementName));
                newXml.Save(fileName);
            }

            query = new Query<Excavation>(fileName, rootElementName);
        }

        public void Add(Excavation excavation, int? id = null)
        {
            if (excavation == null)
                throw new ArgumentNullException(nameof(excavation));

            query.Add(excavation, ConstructorXML.Create, null);
        }

        public void Delete(int id)
        {
            query.Delete(id);
        }

        public void Update(Excavation excavation)
        {
            query.Update(excavation, excavation.ID, ConstructorXML.Update);
        }

        public IEnumerable<Excavation> GetAll()
        {
            IEnumerable<XElement> excavationsElements = query.GetAll();
            return Serializated<Excavation>.XmlDeserialization(excavationsElements);
        }

        public IEnumerable<XElement> GetAllElements()
        {
            return query.GetAll();
        }
    }
}
