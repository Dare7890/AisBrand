using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BrandDataProcessing
{
    public class EntitiyNameTranslater : ITranslater
    {
        public IEnumerable<string> Translate(IEnumerable<string> names)
        {
            List<string> translatedNames = new List<string>();
            foreach (string name in names)
                translatedNames.Add(Translate(name));

            return translatedNames;
        }

        public string Translate(string name)
        {
            TranslatedNameAttribute translatedNameAttribute = (TranslatedNameAttribute)Attribute.GetCustomAttribute(Type.GetType(name), typeof(TranslatedNameAttribute));
            return translatedNameAttribute.Name;
        }

        public static Type GetTypeByTranslatedNameValue(IEnumerable<Type> types, string className)
        {
            return types.SingleOrDefault(t => (t.GetCustomAttribute(typeof(TranslatedNameAttribute)) as TranslatedNameAttribute).Name == className);
        }
    }
}
