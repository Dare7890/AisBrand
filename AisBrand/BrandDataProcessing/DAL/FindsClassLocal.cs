using BrandDataProcessing.Models;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System;

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
            int existingFindsClassesAmount = query.GetAll(elementID).Count();
            Func<FindsClass, XElement> constructor = existingFindsClassesAmount == 0 ? ConstructorXML.CreateWithRoot : ConstructorXML.Create;

            query.Add(findsClass, constructor, elementID);
        }

        public void Delete(int id)
        {
            query.Delete(id);
        }

        public IEnumerable<FindsClass> GetAll(int? elementId)
        {
            IEnumerable<XElement> findsClassesElements = query.GetAll(elementId);
            return Serializated<FindsClass>.XmlDeserialization(findsClassesElements);
        }

        public void Update(FindsClass findsClass)
        {
            query.Update(findsClass, findsClass.ID, ConstructorXML.Update);
        }
    }
}
