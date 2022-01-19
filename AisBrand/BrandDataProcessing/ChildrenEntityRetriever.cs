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
            Type childrenType = typeof(List<>);
            IEnumerable<PropertyInfo> parentLists = parentType.GetProperties().Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == childrenType);
            IEnumerable<string> entitiesNames = parentLists.Select(l => l.PropertyType.GetGenericArguments()[0].FullName);

            return translater.Translate(entitiesNames);
        }
    }
}
