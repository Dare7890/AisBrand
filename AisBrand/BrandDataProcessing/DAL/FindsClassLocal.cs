using BrandDataProcessing.Models;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BrandDataProcessing.DAL
{
    public class FindsClassLocal : IRepository<FindsClass>
    {
        private readonly Query<FindsClass> query;

        public FindsClassLocal(string filePath)
        {
            query = new Query<FindsClass>(filePath, nameof(Excavation));
        }

        public void Add(FindsClass findsClass, int? elementID = null)
        {
            query.Add(findsClass, ConstructorXML.Create, elementID);
        }

        public void Delete(int id)
        {
            query.Delete(id);
        }

        public IEnumerable<FindsClass> GetAll()
        {
            IEnumerable<XElement> findsClassesElements = query.GetAll();
            return Serializated<FindsClass>.XmlDeserialization(findsClassesElements);
        }

        public void Update(FindsClass findsClass)
        {
            query.Update(findsClass, findsClass.ID, ConstructorXML.Update);
        }
    }
}
