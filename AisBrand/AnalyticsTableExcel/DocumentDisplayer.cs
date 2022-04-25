using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BrandDataProcessing.Models;
using Syncfusion.XlsIO;

namespace AnalyticsTableExcel
{
    public class DocumentDisplayer
    {
        private const string filePath = "../../../../../Data1.xlsx";
        private List<Excavation> excavations;

        public DocumentDisplayer(IEnumerable<Excavation> excavations)
        {
            this.excavations = new List<Excavation>(excavations);
        }

        public void Show()
        {
            IEnumerable<string> header = HeadSetter.GetHeader();
            ExcavationViewModelFiller filler = new();
            IEnumerable<ExcavationViewModel> tableData = filler.Fill(excavations);

            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;

                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet worksheet = workbook.Worksheets[0];

                worksheet.ImportArray(header.ToArray(), 1, 1, false);
                worksheet.ImportData(tableData, 2, 1, false);

                using (Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    workbook.SaveAs(stream);
                }
            }
        }
    }
}
