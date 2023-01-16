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
            yield return "Экспедиция";
            yield return "Раскоп";
            yield return "Пласт";
            yield return "Квадрат";
            yield return "Глубина";
            yield return "Тип";
            yield return "Обжиг";
            yield return "Глина";
            yield return "Примеси";
            yield return "ДОП";
            yield return "Орнамент";
            yield return "Датировка";
            yield return "Количество";
            yield return "Описание";
            yield return "Примичание";
        }

        public static IEnumerable<string> GetStatisticHeader()
        {
            yield return "Тип";
            yield return "Экспедиция";
            yield return "Раскоп";
            yield return "Пласт";
            yield return "Квадрат";
            yield return "Датировка";
            yield return "Количество";
        }

        public static IEnumerable<string> GetHeader(BrandPropertyHeaders brandPropertyHeaders)
        {
            List<string> headers = new List<string>();
            headers.AddRange(brandPropertyHeaders.SafetyHeaders);
            headers.AddRange(brandPropertyHeaders.ReliefHeaders);
            headers.AddRange(brandPropertyHeaders.ReliabilityHeaders);
            headers.AddRange(brandPropertyHeaders.ClayHeaders);
            headers.AddRange(brandPropertyHeaders.AdmixtureHeaders);

            return headers;
        }

        public static List<string[]> GetScalarMultipleHeader(BrandPropertyHeaders brandPropertyHeaders)
        {
            List<string[]> headers = new()
            {
                new string[] { "ДОП", "Орнамент", "Обжиг", "Глина", "Примеси", "Тип" }
            };

            List<IEnumerable<string>> items = new()
            {
                brandPropertyHeaders.SafetyHeaders,
                brandPropertyHeaders.ReliefHeaders,
                brandPropertyHeaders.ReliabilityHeaders,
                brandPropertyHeaders.ClayHeaders,
                brandPropertyHeaders.AdmixtureHeaders,
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
