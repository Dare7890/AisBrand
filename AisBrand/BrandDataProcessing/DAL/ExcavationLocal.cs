﻿using BrandDataProcessing.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace BrandDataProcessing.DAL
{
    public class ExcavationLocal : IRepository<Excavation>
    {
        private const string rootElementName = "ArrayOfExcavation";
        private readonly string fileName;
        private readonly Query<Excavation> query;

        public ExcavationLocal(string fileName)
        {
            this.fileName = fileName;
            if (IsEmptyFile())
            {
                XDocument newXml = new XDocument(new XElement(rootElementName));
                newXml.Save(fileName);
            }

            query = new Query<Excavation>(fileName, rootElementName);
        }

        private bool IsEmptyFile()
        {
            return new FileInfo(fileName).Length == 0;
        }

        public void Add(Excavation excavation, int? id = null)
        {
            if (excavation == null)
                throw new ArgumentNullException(nameof(excavation));

            query.Add(excavation, ConstructorXML.Create, null);
        }

        public void Delete(int id)
        {
            query.Delete(id);
        }

        public void Update(Excavation excavation)
        {
            query.Update(excavation, excavation.ID, ConstructorXML.Update);
        }

        public IEnumerable<Excavation> GetAll(int? id = null)
        {
            IEnumerable<XElement> excavationsElements = query.GetAll(id);
            return Serializated<Excavation>.XmlDeserialization(excavationsElements);
        }

        public IEnumerable<XElement> GetAllElements(int? id = null)
        {
            return query.GetAll(id);
        }
    }
}
