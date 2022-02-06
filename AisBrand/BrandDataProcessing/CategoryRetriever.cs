using System;
using System.Collections.Generic;
using System.Reflection;

namespace BrandDataProcessing
{
    public static class CategoryRetriever
    {
        public static string Retrieve(string className)
        {
            Type classNameType = GetClassTypeByName(className);
            return GetCategory(classNameType);
        }

        private static string GetCategory(Type classNameType)
        {
            CategoryAttribute categoryAttribute = (CategoryAttribute)Attribute.GetCustomAttribute(classNameType, typeof(CategoryAttribute));
            return categoryAttribute.Title;
        }

        private static Type GetClassTypeByName(string className)
        {
            IEnumerable<Type> typesWithTranslatedNameAttribute = GetTypesWithTranslatedNameAttribute();
            Type classNameType = EntitiyNameTranslater.GetTypeByTranslatedNameValue(typesWithTranslatedNameAttribute, className);
            return classNameType;
        }

        private static List<Type> GetTypesWithTranslatedNameAttribute()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            List<Type> types = new List<Type>();

            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(TranslatedNameAttribute), true).Length > 0)
                    types.Add(type);
            }

            return types;
        }
    }
}
