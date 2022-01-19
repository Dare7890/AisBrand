using System.Windows.Forms;

namespace BrandDataProcessingUI
{
    public static class TableHeaders
    {
        public static class Excavation
        {
            private const string nameTitle = "Раскоп";
            private const string monumentTitle = "Памятник";
            private const string findsAmountTitle = "Кол-во предметов";

            private const int nameIndex = 0;
            private const int monumentIndex = 1;
            private const int findsAmountIndex = 2;

            public static void SetExcavationTitles(DataGridView dataGrid)
            {
                dataGrid.Columns[nameIndex].HeaderText = nameTitle;
                dataGrid.Columns[monumentIndex].HeaderText = monumentTitle;
                dataGrid.Columns[findsAmountIndex].HeaderText = findsAmountTitle;
            }
        }

        public static class FindsClass
        {
            private const string classTitle = "Класс предметов";
            private const string classificationAmountTitle = "Кол-во предметов";

            private const int classIndex = 0;
            private const int classificationAmountIndex = 1;

            public static void SetFindsClassTitles(DataGridView dataGrid)
            {
                dataGrid.Columns[classIndex].HeaderText = classTitle;
                dataGrid.Columns[classificationAmountIndex].HeaderText = classificationAmountTitle;
            }
        }

        public static class Classification
        {
            private const string typeTitle = "Тип";
            private const string variantTitle = "Вариант";

            private const int typeIndex = 0;
            private const int variantIndex = 1;

            public static void SetClassificationTitles(DataGridView dataGrid)
            {
                dataGrid.Columns[typeIndex].HeaderText = typeTitle;
                dataGrid.Columns[variantIndex].HeaderText = variantTitle;
            }
        }
    }
}
