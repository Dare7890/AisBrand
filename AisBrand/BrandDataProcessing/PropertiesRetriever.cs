﻿using System.Collections.Generic;
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
                    { "Monument", "Памятник/Раскоп" },
                    { "Name", "Экспедиция" }
                };
            }
        }

        public static class FindsClass
        {
            public static Dictionary<string, string> Retrieve()
            {
                return new Dictionary<string, string>()
                {
                    { "Class", "Подкатегория" }
                };
            }
        }

        public static class Classification
        {
            public static Dictionary<string, string> Retrieve()
            {
                return new Dictionary<string, string>()
                {
                    { "Type", "Форма" },
                    { "Variant", "Часть/Тип" }
                };
            }
        }

        public static class Find
        {
            public static Dictionary<string, string> Retrieve(string type)
            {
                return new Dictionary<string, string>()
                {
                    { "CollectorsNumber", "Коллекционный №" },
                    { "FieldNumber", "Полевой №" },
                    { "Formation", "Пласт" },
                    { "Square", "Квадрат" }
                };
            }
        }
    }
}
