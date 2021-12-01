using BrandDataProcessing.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BrandDataProcessing.DAL
{
    public class BrandLocal
    {
        private readonly string fileName;

        public BrandLocal(string fileName)
        {
            this.fileName = fileName;
        }

        public void AddInClassificationElement(Brand brand, int elementID)
        {
            Query<Brand> query = new Query<Brand>(fileName, nameof(Find));
            query.Add(brand, ConstructorXML.Create, elementID);
        }

        public void DeleteInClassificationElement(int id)
        {
            Query<Brand> query = new Query<Brand>(fileName, nameof(Find));
            query.Delete(id);
        }

        public void UpdateInClassificationElement(Brand brand)
        {
            Query<Brand> query = new Query<Brand>(fileName, nameof(Find));
            query.Update(brand, brand.ID, ConstructorXML.Update);
        }

        //public IEnumerable<Brand> GetWithEmptyName()
        //{
        //    Query<Brand> query = new Query<Brand>(fileName, nameof(Excavation));
        //    IEnumerable<XElement> brandsXml = query.GetAll();
        //    IEnumerable<Brand> brands = Serializated<Brand>.XmlDeserialization(brandsXml);
        //    return brands.Where(b => ReferenceEquals(b.FieldNumber, null));
        //}
    }
}
