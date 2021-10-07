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
        }

        public static XElement Create(Application application)
        {
            return new XElement(nameof(Application),
                new XElement(nameof(application.ID), application.ID),
                new XElement(nameof(application.ClassificationID), application.ClassificationID),
                new XElement(nameof(application.File), application.File)
                );
        }

        public static XElement Create(Classification classification)
        {
            return new XElement(nameof(Classification),
                new XElement(nameof(classification.ID), classification.ID),
                new XElement(nameof(classification.Name), classification.Name),
                new XElement(nameof(classification.Author), classification.Author)
                );
        }

        public static XElement Create(ClassificationElement classificationElement)
        {
            return new XElement(nameof(ClassificationElement),
                new XElement(nameof(classificationElement.ID), classificationElement.ID),
                new XElement(nameof(classificationElement.Type), classificationElement.Type),
                new XElement(nameof(classificationElement.Variant), classificationElement.Variant),
                new XElement(nameof(classificationElement.Description), classificationElement.Description),
                new XElement(nameof(classificationElement.Image), classificationElement.Image)
                );
        }

        public static void Update(Excavation excavation, XElement updatedExcavation)
        {
            updatedExcavation.Element(nameof(excavation.Name)).Value = excavation.Name;
            updatedExcavation.Element(nameof(excavation.Monument)).Value = excavation.Monument;
        }

        public static void Update(Brand brand, XElement updatedBrand)
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
        }

        public static void Update(Application application, XElement updatedApplication)
        {
            updatedApplication.Element(nameof(application.ClassificationID)).Value = application.ClassificationID.ToString();
            updatedApplication.Element(nameof(application.File)).Value = application.FileAsString;
        }

        public static void Update(Classification classification, XElement updatedClassification)
        {
            updatedClassification.Element(nameof(classification.Name)).Value = classification.Name;
            updatedClassification.Element(nameof(classification.Author)).Value = classification.Author;
        }

        public static void Update(ClassificationElement element, XElement updatedElement)
        {
            updatedElement.Element(nameof(element.Type)).Value = element.Type;
            updatedElement.Element(nameof(element.Variant)).Value = element.Variant;
            updatedElement.Element(nameof(element.Description)).Value = element.Description;
            updatedElement.Element(nameof(element.Image)).Value = element.ImageAsString;
        }
    }
}
