using System.Windows.Forms;

namespace BrandDataProcessingUI
{
    public static class TableHeaders
    {
        public static class Excavation
        {
            private const string monumentTitle = "Памятник";
            private const string nameTitle = "Раскоп";
            private const string findsAmountTitle = "Кол-во предметов";

            private const int monumentIndex = 0;
            private const int nameIndex = 1;
            private const int findsAmountIndex = 2;

            public static void SetExcavationTitles(DataGridView dataGrid)
            {
                dataGrid.Columns[monumentIndex].HeaderText = monumentTitle;
                dataGrid.Columns[nameIndex].HeaderText = nameTitle;
                dataGrid.Columns[findsAmountIndex].HeaderText = findsAmountTitle;
            }
        }

        public static class FindsClass
        {
            private const string classCategory = "Категория";
            private const string classSubcategory = "Подкатегория";
            private const string classificationAmountTitle = "Кол-во предметов";

            private const int classCategoryIndex = 0;
            private const int classSubcategoryIndex = 1;
            private const int classificationAmountIndex = 2;

            public static void SetFindsClassTitles(DataGridView dataGrid)
            {
                dataGrid.Columns[classCategoryIndex].HeaderText = classCategory;
                dataGrid.Columns[classSubcategoryIndex].HeaderText = classSubcategory;
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

        public static class Find
        {
            private const string fieldNumberTitle = "Полевой №";
            private const string collectorsNumberTitle = "Коллекционный №";
            private const string formationTitle = "Пласт";
            private const string squareTitle = "Квадрат";

            private const int fieldNumberIndex = 0;
            private const int collectorsNumberIndex = 1;
            private const int formationIndex = 2;
            private const int squareIndex = 3;

            public static void SetFindTitles(DataGridView dataGrid)
            {
                dataGrid.Columns[fieldNumberIndex].HeaderText = fieldNumberTitle;
                dataGrid.Columns[collectorsNumberIndex].HeaderText = collectorsNumberTitle;
                dataGrid.Columns[formationIndex].HeaderText = formationTitle;
                dataGrid.Columns[squareIndex].HeaderText = squareTitle;
            }
        }
    }
}
