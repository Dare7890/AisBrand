using BrandDataProcessing;
using System.Collections.Generic;
using System.Linq;

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

        public static List<string[]> GetScalarMultipleHeader(BrandPropertyHeaders brandPropertyHeaders)
        {
            List<string[]> headers = new()
            {
                new string[] { "Тип" },
                new string[] { "Подтип" },
                new string[] { "Датировка" }
            };

            List<IEnumerable<string>> items = new()
            {
                brandPropertyHeaders.ReliabilityHeaders,
                brandPropertyHeaders.ClayHeaders,
                brandPropertyHeaders.AdmixtureHeaders,
                brandPropertyHeaders.SprinklingHeaders
            };

            headers.AddRange(items.ConcatLines().Select(i => i.ToArray()));

            return headers;
        }

        private static IEnumerable<IEnumerable<string>> ConcatLines(this IEnumerable<IEnumerable<string>> sequences)
        {
            IEnumerable<IEnumerable<string>> emptyProduct = new[] { Enumerable.Empty<string>() };
            return sequences.Aggregate(
                emptyProduct,
                (accumulator, sequence) =>
                    from accseq in accumulator
                    from item in sequence
                    select accseq.Concat(new[] { item }));
        }
    }
}
