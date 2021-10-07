using BrandDataProcessing.Models;

namespace BrandDataProcessing.DAL
{
    public class ClassificationLocal
    {
        private readonly Query<Classification> query;
        //TODO: избавиться от filepath, будет скорее всего только то, что внутри конкртеных раскопок.
        public ClassificationLocal(string filePath)
        {
            query = new Query<Classification>(filePath, nameof(Excavation));
        }

        public void Add(Classification classification, int excavationID)
        {
            query.Add(classification, ConstructorXML.Create, excavationID);
        }

        public void Delete(int id)
        {
            query.Delete(id);
        }

        public void Update(Classification classification)
        {
            query.Update(classification, classification.ID, ConstructorXML.Update);
        }
    }
}
