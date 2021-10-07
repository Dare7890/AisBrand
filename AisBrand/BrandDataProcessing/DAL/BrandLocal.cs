using BrandDataProcessing.Models;

namespace BrandDataProcessing.DAL
{
    public class BrandLocal
    {
        private readonly string fileName;

        public BrandLocal(string fileName)
        {
            this.fileName = fileName;
        }
        // TODO: добавить подэлемент Brands.
        public void AddInExcavation(Brand brand, int excavationID)
        {
            Query<Brand> query = new Query<Brand>(fileName, nameof(Excavation));
            query.Add(brand, ConstructorXML.Create, excavationID);
        }

        public void AddInClassificationElement(Brand brand, int elementID)
        {
            Query<Brand> query = new Query<Brand>(fileName, nameof(ClassificationElement));
            query.Add(brand, ConstructorXML.Create, elementID);
        }

        public void DeleteInExcavation(int id)
        {
            Query<Brand> query = new Query<Brand>(fileName, nameof(Excavation));
            query.Delete(id);
        }

        public void DeleteInClassificationElement(int id)
        {
            Query<Brand> query = new Query<Brand>(fileName, nameof(ClassificationElement));
            query.Delete(id);
        }

        public void UpdateInExcavation(Brand brand)
        {
            Query<Brand> query = new Query<Brand>(fileName, nameof(Excavation));
            query.Update(brand, brand.ID, ConstructorXML.Update);
        }

        public void UpdateInClassificationElement(Brand brand)
        {
            Query<Brand> query = new Query<Brand>(fileName, nameof(ClassificationElement));
            query.Update(brand, brand.ID, ConstructorXML.Update);
        }
    }
}
