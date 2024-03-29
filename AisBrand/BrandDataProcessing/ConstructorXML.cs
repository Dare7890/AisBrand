﻿using BrandDataProcessing.Models;
using System;
using System.Xml.Linq;

namespace BrandDataProcessing
{
    public class ConstructorXML
    {
        public static XElement Create(Excavation excavation)
        {
            XElement excavationElement = new XElement(nameof(Excavation),
                                    new XElement(nameof(excavation.ID), excavation.ID),
                                    new XElement(nameof(excavation.Name), excavation.Name),
                                    new XElement(nameof(excavation.Monument), excavation.Monument)
                                    );

            if (excavation.FindsClasses != null)
            {
                foreach (FindsClass findsClass in excavation.FindsClasses)
                {
                    XElement findsClassesElement = Create(findsClass);
                    excavationElement.Add(findsClassesElement);
                }
            }

            return excavationElement;
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
                classificationXml.Add(CreatePictureElement(nameof(classification.Image), classification.Image));

            return classificationXml;
        }

        public static XElement Create(Find find)
        {
            XElement findXml = new XElement(nameof(Find),
                new XElement(nameof(find.ID), find.ID),
                new XElement(nameof(find.Formation), find.Formation),
                new XElement(nameof(find.Square), find.Square),
                new XElement(nameof(find.Depth), find.Depth),
                new XElement(nameof(find.FieldNumber), find.FieldNumber),
                new XElement(nameof(find.CollectorsNumber), find.CollectorsNumber),
                new XElement(nameof(find.Description), find.Description),
                new XElement(nameof(find.Analogy), find.Analogy),
                new XElement(nameof(find.Note), find.Note)
                );

            if (find.Image != null)
                findXml.Add(CreatePictureElement(nameof(find.Image), find.Image));

            if (find.Photo != null)
                findXml.Add(CreatePictureElement(nameof(find.Photo), find.Photo));

            if (find.Brand != null)
                findXml.Add(Create(find.Brand));

            XElement datingElement = find.DatingBound == null ? new XElement(nameof(DatingBound), find.DatingBound) : CreateDatingBound(find.DatingBound);
            findXml.Add(datingElement);

            return findXml;
        }

        private static XElement CreateDatingBound(DatingBound datingBound)
        {
            return new XElement(nameof(DatingBound),
                new XElement(nameof(datingBound.BoundData), datingBound.BoundData),
                new XElement(nameof(datingBound.DatingLowerBound), datingBound.DatingLowerBound),
                new XElement(nameof(datingBound.DatingUpperBound), datingBound.DatingUpperBound)
                );
        }

        private static XElement CreatePictureElement(string name, byte[] image)
        {
            return new XElement(name, Convert.ToBase64String(image));
        }

        public static XElement Create(FindsClass findsClass)
        {
            XElement findsClassElement = new XElement(nameof(FindsClass),
                                        new XElement(nameof(findsClass.ID), findsClass.ID),
                                        new XElement(nameof(findsClass.Class), findsClass.Class)
                                        );

            if (findsClass.Classifications != null)
            {
                foreach (Classification classification in findsClass.Classifications)
                {
                    XElement classificationElement = Create(classification);
                    findsClassElement.Add(classificationElement);
                }
            }

            return findsClassElement;
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

            string imageName = nameof(classification.Image);
            UpdatePicture(imageName, classification.Image, updatedClassification);
        }

        public static void Update(Find find, XElement updatedFind)
        {
            updatedFind.Element(nameof(find.Formation)).Value = find.Formation;
            updatedFind.Element(nameof(find.Square)).Value = find.Square.ToString();
            updatedFind.Element(nameof(find.Depth)).Value = find.Depth.ToString();
            updatedFind.Element(nameof(find.FieldNumber)).Value = find.FieldNumber;
            updatedFind.Element(nameof(find.CollectorsNumber)).Value = find.CollectorsNumber;
            updatedFind.Element(nameof(find.Description)).Value = find.Description;
            updatedFind.Element(nameof(find.Analogy)).Value = find.Analogy;
            updatedFind.Element(nameof(find.Note)).Value = find.Note;

            string imageName = nameof(find.Image);
            UpdatePicture(imageName, find.Image, updatedFind);

            string photoName = nameof(find.Image);
            UpdatePicture(photoName, find.Image, updatedFind);

            UpdateDating(find.DatingBound, updatedFind);
        }

        private static void UpdateDating(DatingBound dating, XElement updatedDating)
        {
            updatedDating.Element(nameof(dating.BoundData)).Value = dating.BoundData;
            updatedDating.Element(nameof(dating.DatingLowerBound)).Value = dating.DatingLowerBound.ToString();
            updatedDating.Element(nameof(dating.DatingUpperBound)).Value = dating.DatingUpperBound.ToString();
        }

        private static void UpdatePicture(string name, byte[] picture, XElement updatedEntity)
        {
            if (picture != null)
            {
                string image = Convert.ToBase64String(picture);
                if (updatedEntity.Element(name) == null)
                    updatedEntity.Add(new XElement(name, image));
                else
                    updatedEntity.Element(name).Value = image;
            }
            else
            {
                updatedEntity.Element(name)?.Remove();
            }
        }

        public static void Update(FindsClass findsClass, XElement updatedClass)
        {
            updatedClass.Element(nameof(findsClass.Class)).Value = findsClass.Class;
        }
    }
}
