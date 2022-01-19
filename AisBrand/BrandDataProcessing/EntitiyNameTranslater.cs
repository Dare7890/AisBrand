using System;
using System.Collections.Generic;

namespace BrandDataProcessing
{
    public class EntitiyNameTranslater : ITranslater
    {
        public IEnumerable<string> Translate(IEnumerable<string> entitiesNames)
        {
            List<string> translatedNames = new List<string>();
            foreach (string name in entitiesNames)
                translatedNames.Add(Translate(name));

            return translatedNames;
        }

        private static string Translate(string name)
        {
            TranslatedNameAttribute translatedNameAttribute = (TranslatedNameAttribute)Attribute.GetCustomAttribute(Type.GetType(name), typeof(TranslatedNameAttribute));
            return translatedNameAttribute.Name;
        }
    }
}
