using System;
using System.Text;
using System.Xml.Linq;
using BrandDataProcessing.Models;

namespace BrandDataProcessing
{
    public class ConstructorXML
    {
        public static XElement Create(Excavation excavation)
        {
            return new XElement(nameof(Excavation),
                new XElement(nameof(excavation.ID), excavation.ID),
                new XElement(nameof(excavation.Name), excavation.Name),
                new XElement(nameof(excavation.Monument), excavation.Monument)
                );
        }

        public static XElement Create(Brand brand)
        {
            return new XElement(nameof(Brand),
                new XElement(nameof(brand.ID), brand.ID),
                new XElement(nameof(brand.Clay), brand.Clay),
                new XElement(nameof(brand.Admixture), brand.Admixture),
                new XElement(nameof(brand.Sprinkling), brand.Sprinkling),
                new XElement(nameof(brand.Safety), brand.Safety),
                new XElement(nameof(brand.Relief), brand.Relief),
                new XElement(nameof(brand.ReconstructionReliability), brand.ReconstructionReliability)
                );
        }

        public static XElement Create(Classification classification)
        {
            XElement classificationXml = new XElement(nameof(Classification),
                new XElement(nameof(classification.ID), classification.ID),
                new XElement(nameof(classification.Type), classification.Type),
                new XElement(nameof(classification.Variant), classification.Variant),
                new XElement(nameof(classification.Description), classification.Description)
                );

            if (classification.Image != null)
                classificationXml.Add(new XElement(nameof(classification.Image), Convert.ToBase64String(classification.Image)));

            return classificationXml;
        }

        public static XElement Create(Find find)
        {
            return new XElement(nameof(Find),
                new XElement(nameof(find.ID), find.ID),
                new XElement(nameof(find.Formation), find.Formation),
                new XElement(nameof(find.Square), find.Square),
                new XElement(nameof(find.Depth), find.Depth),
                new XElement(nameof(find.FieldNumber), find.FieldNumber),
                new XElement(nameof(find.CollectorsNumber), find.CollectorsNumber),
                new XElement(nameof(find.DatingLowerBound), find.DatingLowerBound),
                new XElement(nameof(find.DatingUpperBound), find.DatingUpperBound),
                new XElement(nameof(find.Description), find.Description),
                new XElement(nameof(find.Image), find.Image),
                new XElement(nameof(find.Photo), find.Photo),
                new XElement(nameof(find.Analogy), find.Analogy),
                new XElement(nameof(find.Note), find.Note)
                );
        }

        public static XElement Create(FindsClass findsClass)
        {
            return new XElement(nameof(FindsClass),
                new XElement(nameof(findsClass.ID), findsClass.ID),
                new XElement(nameof(findsClass.Class), findsClass.Class)
                );
        }

        public static void Update(Excavation excavation, XElement updatedExcavation)
        {
            updatedExcavation.Element(nameof(excavation.Name)).Value = excavation.Name;
            updatedExcavation.Element(nameof(excavation.Monument)).Value = excavation.Monument;
        }

        public static void Update(Brand brand, XElement updatedBrand)
        {
            updatedBrand.Element(nameof(brand.Clay)).Value = brand.Clay;
            updatedBrand.Element(nameof(brand.Admixture)).Value = brand.Admixture;
            updatedBrand.Element(nameof(brand.Sprinkling)).Value = brand.Sprinkling;
            updatedBrand.Element(nameof(brand.Safety)).Value = brand.Safety;
            updatedBrand.Element(nameof(brand.Relief)).Value = brand.Relief;
            updatedBrand.Element(nameof(brand.ReconstructionReliability)).Value = brand.ReconstructionReliability;
        }

        public static void Update(Classification classification, XElement updatedClassification)
        {
            updatedClassification.Element(nameof(classification.Type)).Value = classification.Type;
            updatedClassification.Element(nameof(classification.Variant)).Value = classification.Variant;
            updatedClassification.Element(nameof(classification.Description)).Value = classification.Description;

            string name = nameof(classification.Image);
            if (classification.Image != null)
            {
                string image = Convert.ToBase64String(classification.Image);
                if (updatedClassification.Element(name) == null)
                    updatedClassification.Add(new XElement(name, image));
                else
                    updatedClassification.Element(name).Value = image;
            }
            else
            {
                updatedClassification.Element(name)?.Remove();
            }
        }

        public static void Update(Find find, XElement updatedFind)
        {
            updatedFind.Element(nameof(find.Formation)).Value = find.Formation;
            updatedFind.Element(nameof(find.Square)).Value = find.Square.ToString();
            updatedFind.Element(nameof(find.Depth)).Value = find.Depth.ToString();
            updatedFind.Element(nameof(find.FieldNumber)).Value = find.FieldNumber;
            updatedFind.Element(nameof(find.CollectorsNumber)).Value = find.CollectorsNumber;
            updatedFind.Element(nameof(find.DatingLowerBound)).Value = find.DatingLowerBound.ToString();
            updatedFind.Element(nameof(find.DatingUpperBound)).Value = find.DatingUpperBound.ToString();
            updatedFind.Element(nameof(find.Description)).Value = find.Description;
            updatedFind.Element(nameof(find.Image)).Value = Encoding.Default.GetString(find.Image);
            updatedFind.Element(nameof(find.Photo)).Value = Encoding.Default.GetString(find.Photo);
            updatedFind.Element(nameof(find.Analogy)).Value = find.Analogy;
            updatedFind.Element(nameof(find.Note)).Value = find.Note;
        }

        public static void Update(FindsClass findsClass, XElement updatedClass)
        {
            updatedClass.Element(nameof(findsClass.Class)).Value = findsClass.Class;
        }
    }
}
