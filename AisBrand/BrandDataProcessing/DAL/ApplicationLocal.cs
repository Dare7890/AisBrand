using BrandDataProcessing.Models;

namespace BrandDataProcessing.DAL
{
    public class ApplicationLocal
    {
        private readonly Query<Application> query;
        //TODO: избавиться от filepath, будет скорее всего только то, что внутри конкртеных раскопок.
        public ApplicationLocal(string filePath)
        {
            query = new Query<Application>(filePath, nameof(Classification));
        }

        public void Add(Application application, int classificationID)
        {
            query.Add(application, ConstructorXML.Create, classificationID);
        }

        public void Delete(int id)
        {
            query.Delete(id);
        }

        public void Update(Application application)
        {
            query.Update(application, application.ID, ConstructorXML.Update);
        }
    }
}
