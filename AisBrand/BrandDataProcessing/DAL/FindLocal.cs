﻿using BrandDataProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BrandDataProcessing.DAL
{
    public class FindLocal : IRepository<Find>
    {
        private readonly Query<Find> query;

        //TODO: избавиться от filepath, будет скорее всего только то, что внутри конкртеных раскопок.
        public FindLocal(string filePath)
        {
            query = new Query<Find>(filePath, nameof(Classification));
        }

        public void Add(Find findElement, int? parentId = null)
        {
            query.Add(findElement, ConstructorXML.Create, parentId);
        }

        public void Delete(int id)
        {
            query.Delete(id);
        }

        public IEnumerable<Find> GetAll(int? id)
        {
            IEnumerable<XElement> findElements = query.GetAll(id, nameof(FindsClass));
            List<Find> finds = Serializated<Find>.XmlDeserialization(findElements).ToList();
            for (int i = 0; i < finds.Count(); i++)
            {
                finds[i].Image = query.GetPicture(findElements, finds[i].ID, "Image");
                finds[i].Photo = query.GetPicture(findElements, finds[i].ID, "Photo");
            }

            return finds;
        }

        public void Update(Find element)
        {
            query.Update(element, element.ID, ConstructorXML.Update);
        }
    }
}
