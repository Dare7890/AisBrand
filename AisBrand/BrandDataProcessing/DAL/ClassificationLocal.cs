using BrandDataProcessing.Models;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BrandDataProcessing.DAL
{
    public class ClassificationLocal : IRepository<Classification>
    {
        private readonly Query<Classification> query;
        //TODO: избавиться от filepath, будет скорее всего только то, что внутри конкртеных раскопок.
        public ClassificationLocal(string filePath)
        {
            query = new Query<Classification>(filePath, nameof(Excavation));
        }

        public void Add(Classification classification, int? parentId = null)
        {
            query.Add(classification, ConstructorXML.Create, parentId);
        }

        public void Delete(int id)
        {
            query.Delete(id);
        }

        public IEnumerable<Classification> GetAll(int? id)
        {
            IEnumerable<XElement> classificationElements = query.GetAll(id);
            return Serializated<Classification>.XmlDeserialization(classificationElements);
        }

        public void Update(Classification classification)
        {
            query.Update(classification, classification.ID, ConstructorXML.Update);
        }
    }
}
