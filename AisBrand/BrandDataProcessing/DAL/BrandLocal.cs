using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using BrandDataProcessing.Models;

namespace BrandDataProcessing.DAL
{
    public class BrandLocal
    {
        private const string RootElementName = "ArrayOfExcavation";
        private readonly string fileName;

        public BrandLocal(string fileName)
        {
            this.fileName = fileName;
        }

        public void Add(Brand brand, int excavationID)
        {
            if (brand == null)
                throw new ArgumentNullException(nameof(brand));

            XDocument xmlDocument = XDocument.Load(fileName);
            IEnumerable<Brand> brands = GetBrands(xmlDocument, excavationID);
            int brendID = GetNextElementID(brands);
            XElement element = new XElement(nameof(Brand),
                new XElement(nameof(brand.ID), brendID),
                new XElement(nameof(brand.Formation), brand.Formation),
                new XElement(nameof(brand.Square), brand.Square),
                new XElement(nameof(brand.Depth), brand.Depth),
                new XElement(nameof(brand.FieldNumber), brand.FieldNumber),
                new XElement(nameof(brand.CollectorsNumber), brand.CollectorsNumber),
                new XElement(nameof(brand.Clay), brand.Clay),
                new XElement(nameof(brand.Admixture), brand.Admixture),
                new XElement(nameof(brand.Sprinkling), brand.Sprinkling),
                new XElement(nameof(brand.Safety), brand.Safety),
                new XElement(nameof(brand.Relief), brand.Relief),
                new XElement(nameof(brand.ReconstructionReliability), brand.ReconstructionReliability),
                new XElement(nameof(brand.DatingLowerBound), brand.DatingLowerBound),
                new XElement(nameof(brand.DatingUpperBound), brand.DatingUpperBound),
                new XElement(nameof(brand.Description), brand.Description),
                new XElement(nameof(brand.Image), brand.Image),
                new XElement(nameof(brand.Photo), brand.Photo),
                new XElement(nameof(brand.Analogy), brand.Analogy),
                new XElement(nameof(brand.Note), brand.Note)
                );

            xmlDocument.Element(RootElementName)
                .Elements(nameof(Excavation))
                .FirstOrDefault(e => int.Parse(e.Element("ID").Value) == excavationID)
                ?.Add(element);

            xmlDocument.Save(fileName);
        }

        public void Delete(int id, int excavationID)
        {
            XDocument xmlDocument = XDocument.Load(fileName);
            xmlDocument.Element(RootElementName)
                .Elements(nameof(Excavation))
                .FirstOrDefault(e => int.Parse(e.Element("ID").Value) == excavationID)
                .Elements(nameof(Brand))
                .FirstOrDefault(b => int.Parse(b.Element("ID").Value) == id)
                ?.Remove();

            xmlDocument.Save(fileName);
        }

        public void Update(Brand brand, int excavationID)
        {
            if (brand == null)
                throw new ArgumentNullException(nameof(brand));

            XDocument xmlDocument = XDocument.Load(fileName);
            XElement updatedBrand = xmlDocument.Element(RootElementName)
                                        .Elements(nameof(Excavation))
                                        .FirstOrDefault(e => int.Parse(e.Element("ID").Value) == excavationID)
                                        .Elements(nameof(Brand))
                                        .FirstOrDefault(b => int.Parse(b.Element("ID").Value) == brand.ID);

            if (updatedBrand != null)
            {
                updatedBrand.Element(nameof(brand.Formation)).Value = brand.Formation;
                updatedBrand.Element(nameof(brand.Square)).Value = brand.Square.ToString();
                updatedBrand.Element(nameof(brand.Depth)).Value = brand.Depth.ToString();
                updatedBrand.Element(nameof(brand.FieldNumber)).Value = brand.FieldNumber;
                updatedBrand.Element(nameof(brand.CollectorsNumber)).Value = brand.CollectorsNumber;
                updatedBrand.Element(nameof(brand.Clay)).Value = brand.Clay;
                updatedBrand.Element(nameof(brand.Admixture)).Value = brand.Admixture;
                updatedBrand.Element(nameof(brand.Sprinkling)).Value = brand.Sprinkling;
                updatedBrand.Element(nameof(brand.Safety)).Value = brand.Safety;
                updatedBrand.Element(nameof(brand.Relief)).Value = brand.Relief;
                updatedBrand.Element(nameof(brand.ReconstructionReliability)).Value = brand.ReconstructionReliability;
                updatedBrand.Element(nameof(brand.DatingLowerBound)).Value = brand.DatingLowerBound.ToString();
                updatedBrand.Element(nameof(brand.DatingUpperBound)).Value = brand.DatingUpperBound.ToString();
                updatedBrand.Element(nameof(brand.Description)).Value = brand.Description;
                updatedBrand.Element(nameof(brand.Image)).Value = Encoding.Default.GetString(brand.Image);
                updatedBrand.Element(nameof(brand.Photo)).Value = Encoding.Default.GetString(brand.Photo);
                updatedBrand.Element(nameof(brand.Analogy)).Value = brand.Analogy;
                updatedBrand.Element(nameof(brand.Note)).Value = brand.Note;

                xmlDocument.Save(fileName);
            }
        }

        private static IEnumerable<Brand> GetBrands(XDocument xmlDocument, int excavationID)
        {
            return Serializated<Brand>.XmlDeserialization(xmlDocument.Element(RootElementName)
                                                                        .Elements(nameof(Excavation))
                                                                        .Elements(nameof(Brand)));
        }

        private static int GetNextElementID(IEnumerable<Brand> brands)
        {
            return GetMaxBrandID(brands) + 1;
        }

        private static int GetMaxBrandID(IEnumerable<Brand> brands)
        {
            return brands.Count() == 0 ? 0 : brands.Max(i => i.ID);
        }
    }
}
