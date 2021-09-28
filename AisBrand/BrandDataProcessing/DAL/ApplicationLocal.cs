using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using BrandDataProcessing;
using BrandDataProcessing.Models;

namespace BrandDataProcessing.DAL
{
    public class ApplicationLocal
    {
        private const string RootElementName = "ArrayOfExcavation";
        private readonly string fileName;
        //TODO: избавиться от filepath, будет скорее всего только то, что внутри конкртеных раскопок.
        public ApplicationLocal(string fileName)
        {
            this.fileName = fileName;
        }

        public void Add(Application application, int classificationID)
        {
            if (application == null)
                throw new ArgumentNullException(nameof(application));

            XDocument xmlDocument = XDocument.Load(fileName);
            IEnumerable<Application> applications = GetApplications(xmlDocument);
            int classificationsID = GetNextElementID(applications);
            XElement element = new XElement(nameof(Application),
                new XElement(nameof(application.ID), classificationsID),
                new XElement(nameof(application.ClassificationID), classificationID),
                new XElement(nameof(application.File), application.File)
                );

            xmlDocument.Element(RootElementName)
                .Elements(nameof(Excavation))
                .Elements(nameof(Classification))
                .FirstOrDefault(e => int.Parse(e.Element("ID").Value) == classificationID)
                ?.Add(element);

            xmlDocument.Save(fileName);
        }

        public void Delete(int id)
        {
            XDocument xmlDocument = XDocument.Load(fileName);
            xmlDocument.Element(RootElementName)
                .Elements(nameof(Excavation))
                .Elements(nameof(Classification))
                .Elements(nameof(Application))
                .FirstOrDefault(a => int.Parse(a.Element("ID").Value) == id)
                ?.Remove();

            xmlDocument.Save(fileName);
        }

        public void Update(Application application)
        {
            if (application == null)
                throw new ArgumentNullException(nameof(application));

            XDocument xmlDocument = XDocument.Load(fileName);
            XElement updatedApplication = xmlDocument.Element(RootElementName)
                                        .Elements(nameof(Excavation))
                                        .Elements(nameof(Classification))
                                        .Elements(nameof(Application))
                                        .FirstOrDefault(b => int.Parse(b.Element("ID").Value) == application.ID);

            if (updatedApplication != null)
            {
                updatedApplication.Element(nameof(application.ClassificationID)).Value = application.ClassificationID.ToString();
                updatedApplication.Element(nameof(application.File)).Value = application.FileAsString;

                xmlDocument.Save(fileName);
            }
        }

        private static IEnumerable<Application> GetApplications(XDocument xmlDocument)
        {
            return Serializated<Application>.XmlDeserialization(xmlDocument.Element(RootElementName)
                                                                        .Elements(nameof(Excavation))
                                                                        .Elements(nameof(Classification))
                                                                        .Elements(nameof(Application)));
        }

        private static int GetNextElementID(IEnumerable<Application> applications)
        {
            return GetMaxClassificationID(applications) + 1;
        }

        private static int GetMaxClassificationID(IEnumerable<Application> applications)
        {
            return applications.Count() == 0 ? 0 : applications.Max(i => i.ID);
        }
    }
}
