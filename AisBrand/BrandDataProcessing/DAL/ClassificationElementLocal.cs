using BrandDataProcessing.Models;

namespace BrandDataProcessing.DAL
{
    public class ClassificationElementLocal
    {
        private readonly Query<ClassificationElement> query;

        //TODO: избавиться от filepath, будет скорее всего только то, что внутри конкртеных раскопок.
        public ClassificationElementLocal(string filePath)
        {
            query = new Query<ClassificationElement>(filePath, nameof(Classification));
        }

        public void Add(ClassificationElement classificationElement, int classificationID)
        {
            query.Add(classificationElement, ConstructorXML.Create, classificationID);
        }

        public void Delete(int id)
        {
            query.Delete(id);
        }

        public void Update(ClassificationElement element)
        {
            query.Update(element, element.ID, ConstructorXML.Update);
        }
    }
}
