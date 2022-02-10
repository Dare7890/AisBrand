using BrandDataProcessing.Models;
using System.Collections.Generic;
using System.Linq;

namespace BrandDataProcessingBL
{
    public class ClassificationsRetriever : IClassificationsRetriever
    {
        public IEnumerable<Classification> RetrieveFindsClassClassifications(IEnumerable<Excavation> excavations, string monument, ref int nextClassificationId, FindsClass findsClass)
        {
            IEnumerable<Classification> classifications = GetClassificationsByMonuments(excavations, findsClass.Class, monument);
            findsClass.Classifications = new List<Classification>();
            foreach (Classification classification in classifications)
            {
                Classification newClassification = new Classification();
                newClassification.ID = nextClassificationId;
                newClassification.Type = classification.Type;
                newClassification.Variant = classification.Variant;
                newClassification.Description = classification.Description;

                newClassification.Image = null;
                if (classification.Image != null)
                {
                    int pictuteLength = classification.Image.Length;
                    int startIndex = 0;
                    newClassification.Image = new byte[pictuteLength];
                    classification.Image.CopyTo(newClassification.Image, startIndex);
                }

                findsClass.Classifications.Add(newClassification);
                nextClassificationId++;
            }

            return classifications;
        }

        private static IEnumerable<Classification> GetClassificationsByMonuments(IEnumerable<Excavation> excavations, string className, string monument)
        {
            return excavations.Where(m => m.Monument == monument)
                               .SelectMany(f => f.FindsClasses)
                               .Where(c => c.Class == className)
                               .SelectMany(f => f.Classifications)
                               .Distinct();
        }

        public IEnumerable<Classification> GetClassifications(IEnumerable<FindsClass> findsClasses)
        {
            return findsClasses.SelectMany(c => c.Classifications);
        }
    }
}
