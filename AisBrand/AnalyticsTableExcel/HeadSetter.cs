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
            yield return "Тип";
            yield return "Подтип";
            yield return "Обжиг";
            yield return "Глина";
            yield return "Примеси";
            yield return "Подсыпка";
            yield return "Датировка";
        }
    }
}
