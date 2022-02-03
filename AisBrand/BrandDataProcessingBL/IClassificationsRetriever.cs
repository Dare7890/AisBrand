using BrandDataProcessing.Models;
using System.Collections.Generic;

namespace BrandDataProcessingBL
{
    public interface IClassificationsRetriever
    {
        IEnumerable<Classification> GetClassifications(IEnumerable<FindsClass> findsClasses);
        IEnumerable<Classification> RetrieveFindsClassClassifications(IEnumerable<Excavation> excavations, string monument, int id, FindsClass findsClass);
    }
}