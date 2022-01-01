using BrandDataProcessing.Models;

namespace BrandDataProcessing.DAL
{
    public class BrandLocal
    {
        private readonly Query<Brand> query;

        public BrandLocal(string filePath)
        {
            query = new Query<Brand>(filePath, nameof(Find));
        }

        public void AddInClassificationElement(Brand brand, int elementID)
        {
            query.Add(brand, ConstructorXML.Create, elementID);
        }

        public void DeleteInClassificationElement(int id)
        {
            query.Delete(id);
        }

        public void UpdateInClassificationElement(Brand brand)
        {
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
