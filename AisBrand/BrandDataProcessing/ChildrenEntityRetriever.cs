using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BrandDataProcessing.Models;

namespace BrandDataProcessing
{
    public static class ChildrenEntityRetriever
    {
        public static IEnumerable<string> RetrieveTranslatedFindChildrenNames(ITranslater translater)
        {
            Type parentType = typeof(Find);
            return RetrieveTranslatedNames(parentType, translater);
        }

        public static IEnumerable<string> RetrieveTranslatedNames(Type parentType, ITranslater translater)
        {
            Type childrenTypeInterface = typeof(IIdentifier);
            IEnumerable<string> entitiesNames = parentType.GetProperties()
                                                                .Where(p => childrenTypeInterface.IsAssignableFrom(p.PropertyType)).Select(l => l.PropertyType.FullName);

            return translater.Translate(entitiesNames);
        }
    }
}
