using BrandDataProcessing.Models;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System;

namespace BrandDataProcessing.DAL
{
    public class ClassificationLocal : IRepository<Classification>
    {
        private readonly Query<Classification> query;
        //TODO: избавиться от filepath, будет скорее всего только то, что внутри конкртеных раскопок.
        public ClassificationLocal(string filePath)
        {
            query = new Query<Classification>(filePath, nameof(FindsClass));
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
            List<Classification> classifications = Serializated<Classification>.XmlDeserialization(classificationElements).ToList();
            for (int i = 0; i < classifications.Count(); i++)
            {
                classifications[i].Image = classificationElements.Where(c => int.Parse(c.Element("ID").Value) == classifications[i].ID)
                                                                .Select(c =>
                                                                {
                                                                    string image = c.Element("Image")?.Value;
                                                                    return image != null ? Convert.FromBase64String(image) : null;
                                                                })
                                                                ?.FirstOrDefault() ?? null;
            }

            return classifications;
        }

        public void Update(Classification classification)
        {
            query.Update(classification, classification.ID, ConstructorXML.Update);
        }
    }
}
