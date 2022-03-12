using System.Collections.Generic;
using System.Linq;

namespace BrandDataProcessing
{
    public static class PropertiesRetriever
    {
        public static class Excavation
        {
            public static Dictionary<string, string> Retrieve()
            {
                return new Dictionary<string, string>()
                {
                    {"Monument", "Памятник" },
                    { "Name", "Раскоп" }
                };
            }
        }

        public static class FindsClass
        {
            public static IEnumerable<string> Retrieve()
            {
                return new List<string>()
                {
                    "Категория",
                    "Подкатегория"
                };
            }
        }

        public static class Classification
        {
            public static IEnumerable<string> Retrieve()
            {
                return new List<string>()
                {
                    "Тип",
                    "Вариант"
                };
            }
        }

        public static class Find
        {
            private const string brandEntityName = "Клеймо";

            public static IEnumerable<string> Retrieve(string type)
            {
                List<string> properties = new List<string>()
                {
                    "Коллекционный №",
                    "Полевой №",
                    "Пласт",
                    "Квадрат",
                    "Глубина",
                };

                IEnumerable<string> subproperties;
                subproperties = type == brandEntityName ? Brand.Retrieve() : AdditionalBrand.Retrieve();
                properties.AddRange(subproperties);

                return properties;
            }
        }

        private static class Brand
        {
            public static IEnumerable<string> Retrieve()
            {
                return new List<string>()
                {
                    "Глина",
                    "Примеси",
                    "Подсыпка",
                    "Обжиг"
                };
            }
        }

        private static class AdditionalBrand
        {
            public static IEnumerable<string> Retrieve()
            {
                return Enumerable.Empty<string>();
            }
        }
    }
}
