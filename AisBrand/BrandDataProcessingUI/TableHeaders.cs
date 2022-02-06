﻿using System.Windows.Forms;

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
    }
}
