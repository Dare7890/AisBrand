using AddBrandDataUI.ViewModels;
using System;
using System.Windows.Forms;

namespace BrandDataProcessingUI
{
    public static class RetrieverSelectedData
    {
        public static Excavation GetSelectedExcavation(DataGridViewCellCollection cells)
        {
            const int deletedMonumentIndex = 0;
            const int deletedNameIndex = 1;
            string deletedName = cells[deletedNameIndex].Value.ToString();
            string deletedMonument = cells[deletedMonumentIndex].Value.ToString();

            return new Excavation(deletedName, deletedMonument);
        }

        public static FindsClass GetSelectedFindsClass(DataGridViewCellCollection cells)
        {
            const int classIndex = 1;
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

        internal static Find GetSelectedFind(DataGridViewCellCollection cells)
        {
            const int fieldNumberIndex = 0;
            const int collectorsNumberIndex = 1;
            const int formationIndex = 2;
            const int squareIndex = 3;
            string fieldNumber = cells[fieldNumberIndex].Value.ToString();
            string collectorsNumber = cells[collectorsNumberIndex].Value.ToString();
            string formation = cells[formationIndex].Value.ToString();

            string squareString = cells[squareIndex].Value?.ToString();
            int? square = squareString == null ? null : int.Parse(squareString);

            return new Find(fieldNumber, formation, collectorsNumber: collectorsNumber, square: square);
        }
    }
}
