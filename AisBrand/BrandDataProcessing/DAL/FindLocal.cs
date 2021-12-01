using BrandDataProcessing.Models;

namespace BrandDataProcessing.DAL
{
    public class FindLocal
    {
        private readonly Query<Find> query;

        //TODO: избавиться от filepath, будет скорее всего только то, что внутри конкртеных раскопок.
        public FindLocal(string filePath)
        {
            query = new Query<Find>(filePath, nameof(Classification));
        }

        public void Add(Find findElement, int classificationID)
        {
            query.Add(findElement, ConstructorXML.Create, classificationID);
        }

        public void Delete(int id)
        {
            query.Delete(id);
        }

        public void Update(Find element)
        {
            query.Update(element, element.ID, ConstructorXML.Update);
        }
    }
}
