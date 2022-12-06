using BrandDataProcessing;
using System.Collections.Generic;

namespace AnalyticsTableExcel
{
    public static class HeadSetter
    {
        public static IEnumerable<string> GetHeader()
        {
            yield return "Полевой №";
            yield return "Коллекционыный №";
            yield return "Памятник";
            yield return "Раскоп";
            yield return "Пласт";
            yield return "Квадрат";
            yield return "Глубина";
            yield return "Тип";
            yield return "Подтип";
            yield return "Обжиг";
            yield return "Глина";
            yield return "Примеси";
            yield return "Подсыпка";
            yield return "Датировка";
            yield return "Аналогии";
            yield return "Описание";
            yield return "Примичание";
        }

        public static IEnumerable<string> GetHeader(BrandPropertyHeaders brandPropertyHeaders)
        {
            List<string> headers = new List<string>()
            {
                "Тип",
                "Подтип",
                "Датировка"
            };

            headers.AddRange(brandPropertyHeaders.ClayHeaders);
            headers.AddRange(brandPropertyHeaders.AdmixtureHeaders);
            headers.AddRange(brandPropertyHeaders.SprinklingHeaders);
            headers.AddRange(brandPropertyHeaders.ReliabilityHeaders);

            return headers;
        }
    }
}
