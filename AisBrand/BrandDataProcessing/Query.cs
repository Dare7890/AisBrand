using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using BrandDataProcessing.Models;

namespace BrandDataProcessing
{
    public class Query<T> where T : class, IIdentifier
    {
        private const string RootElementName = "ArrayOfExcavation";
        private readonly string filePath;

        private readonly XDocument xmlDocument;
        private readonly IEnumerable<XElement> parentElements;

        public Query(string filePath, string parentElementsTypeName)
        {
            this.filePath = filePath;
            xmlDocument = InitXmlDocument(filePath);
            parentElements = InitElements(xmlDocument, parentElementsTypeName);
        }

        private static XDocument InitXmlDocument(string filePath)
        {
            return XDocument.Load(filePath);
        }

        private static IEnumerable<XElement> InitElements(XDocument xmlDocument, string elementsTypeName)
        {
            return xmlDocument.Descendants(elementsTypeName);
        }

        public void Add(T obj, Func<T, XElement> constructor, int? id)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            obj.ID = GetNextElementID(parentElements);
            XElement constructXmlElement = constructor(obj);
            XElement parentElement = id.HasValue ? parentElements.FirstOrDefault(e => int.Parse(e.Element("ID").Value) == id) : parentElements.First();
            XElement parentElementWithRoot = parentElement.Element(string.Format($"ArrayOf{typeof(T).Name}")) ?? parentElement;

            //string rootElement = string.Format($"ArrayOf{nameof(T)}");
            //if (parentElement.Element(rootElement) == null)
            //{
            //    XElement xmlElementWithRoot = new XElement()
            //}
            parentElementWithRoot?.Add(constructXmlElement);
            xmlDocument.Save(filePath);
        }

        public IEnumerable<XElement> GetAll(int? elementId, string parentTypeName = null)
        {
            IEnumerable<XElement> parentElements;
            parentElements = parentTypeName != null ? InitElements(xmlDocument, parentTypeName) : this.parentElements;

            if (!elementId.HasValue)
                return GetDescendants(parentElements, typeof(T));

            IEnumerable<XElement> parentElement = parentElements.Where(p => int.Parse(p.Element("ID").Value) == elementId);
            return GetDescendants(parentElement, typeof(T));
        }

        public void Delete(int id)
        {
            IEnumerable<XElement> descendants = GetDescendants(parentElements, typeof(T));
            descendants.FirstOrDefault(b => int.Parse(b.Element("ID").Value) == id)
                ?.Remove();

            xmlDocument.Save(filePath);
        }

        public void Update(T obj, int id, Action<T, XElement> updater)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            IEnumerable<XElement> descendants = GetDescendants(parentElements, typeof(T));
            XElement updatedObject = descendants.FirstOrDefault(b => int.Parse(b.Element("ID").Value) == id);

            if (updatedObject != null)
            {
                updater(obj, updatedObject);
                xmlDocument.Save(filePath);
            }
        }

        private static IEnumerable<T> GetDeserializationElement(IEnumerable<XElement> xmlElements)
        {
            return Serializated<T>.XmlDeserialization(xmlElements);
        }

        private static int GetNextElementID(IEnumerable<XElement> elements)
        {
            IEnumerable<T> allDeserializationElements = GetDeserializationElement(GetDescendants(elements, typeof(T)));
            return GetMaxClassificationID(allDeserializationElements) + 1;
        }

        private static int GetMaxClassificationID(IEnumerable<T> elements)
        {
            return elements.Count() == 0 ? 0 : elements.Max(i => i.ID);
        }

        private static IEnumerable<XElement> GetDescendants(IEnumerable<XElement> elements, Type descendantsType)
        {
            return elements.Descendants(descendantsType.Name);
        }
    }
}
