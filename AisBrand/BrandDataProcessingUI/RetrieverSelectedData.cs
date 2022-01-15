﻿using AddBrandDataUI.ViewModels;
using System.Windows.Forms;

namespace BrandDataProcessingUI
{
    public static class RetrieverSelectedData
    {
        public static Excavation GetSelectedExcavation(DataGridViewCellCollection cells)
        {
            const int deletedNameIndex = 0;
            const int deletedMonumentIndex = 1;
            string deletedName = cells[deletedNameIndex].Value.ToString();
            string deletedMonument = cells[deletedMonumentIndex].Value.ToString();

            return new Excavation(deletedName, deletedMonument);
        }

        public static FindsClass GetSelectedFindsClass(DataGridViewCellCollection cells)
        {
            const int classIndex = 0;
            string findsClass = cells[classIndex].Value.ToString();

            return new FindsClass(findsClass);
        }

        internal static Classification GetSelectedClassification(DataGridViewCellCollection cells)
        {
            const int typeIndex = 0;
            const int variantIndex = 1;
            string type = cells[typeIndex].Value.ToString();
            string variant = cells[variantIndex].Value.ToString();

            return new Classification(type, variant);
        }
    }
}
