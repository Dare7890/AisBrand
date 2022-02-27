using System.Linq;
using FindsClassModel = BrandDataProcessing.Models.FindsClass;
using ClassificationModel = BrandDataProcessing.Models.Classification;

namespace AddBrandDataUI.ViewModels
{
    public class Classification
    {
        public string Type { get; }

        public string Variant { get; }

        public string Description { get; }

        public byte[] Image { get; }

        public Classification(string type, string variant, string description = null, byte[] image = null)
        {
            Type = type;
            Variant = variant;
            Description = description;
            Image = image;
        }

        public Classification(FindsClassModel findsClass, string fieldNumber)
        {
            Type = GetFindType(findsClass, fieldNumber);
            Variant = GetFindVariant(findsClass, fieldNumber);
        }

        private static string GetFindType(FindsClassModel findsClass, string fieldNumber)
        {
            ClassificationModel classification = GetClassificationByFieldNumber(findsClass, fieldNumber);
            return classification?.Type;
        }

        private static string GetFindVariant(FindsClassModel findsClass, string fieldNumber)
        {
            ClassificationModel classification = GetClassificationByFieldNumber(findsClass, fieldNumber);
            return classification?.Variant;
        }

        private static ClassificationModel GetClassificationByFieldNumber(FindsClassModel findsClass, string fieldNumber)
        {
            return findsClass.Classifications.FirstOrDefault(c => c.Finds.Select(f => f.FieldNumber).Contains(fieldNumber));
        }
    }
}
