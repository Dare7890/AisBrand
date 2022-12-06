using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using BrandDataProcessing;
using BrandDataProcessing.Models;
using Syncfusion.XlsIO;

namespace AnalyticsTableExcel
{
    public class DocumentDisplayer
    {
        private const string filePath = @"..\..\..\..\..\Data1.xlsx";
        private List<Excavation> excavations;

        public DocumentDisplayer(IEnumerable<Excavation> excavations)
        {
            this.excavations = new List<Excavation>(excavations);
        }

        public void Show(BrandPropertyHeaders brandPropertyHeaders)
        {
            IEnumerable<string> header = HeadSetter.GetHeader();
            IEnumerable<string> statisticHeader = HeadSetter.GetHeader(brandPropertyHeaders);

            ExcavationViewModelFiller filler = new();

            IEnumerable<ExcavationViewModel> excavationData = filler.Fill(excavations);
            IEnumerable<StatisticViewModel> statisticData = filler.FillStatistic(excavations);

            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;

                IWorkbook workbook = application.Workbooks.Create(2);
                IWorksheet firstWorksheet = workbook.Worksheets[0];

                firstWorksheet.ImportArray(header.ToArray(), 1, 1, false);
                firstWorksheet.ImportData(excavationData, 2, 1, false);

                IWorksheet secondWorksheet = workbook.Worksheets[1];
                secondWorksheet.ImportArray(statisticHeader.ToArray(), 1, 1, false);
                secondWorksheet.ImportData(statisticData, 2, 1, false);
                for (int i = 1; i < statisticData.Count() + 1; i++)
                {
                    for (int j = 3; j < 3 + statisticHeader.Skip(3).Count(); j++)
                    {
                        secondWorksheet.Columns[j].Rows[i].Text = excavationData.Where
                            (e => e.Type == secondWorksheet.Columns[0].Rows[i].Text &&
                            e.Variant == secondWorksheet.Columns[1].Rows[i].Text &&
                            e.Dating == secondWorksheet.Columns[2].Rows[i].Text &&
                            (e.Clay.Contains(secondWorksheet.Columns[j].Rows[0].Text) ||
                            e.Admixture.Contains(secondWorksheet.Columns[j].Rows[0].Text) ||
                            e.Sprinkling.Contains(secondWorksheet.Columns[j].Rows[0].Text) ||
                            e.ReconstructionReliability.Contains(secondWorksheet.Columns[j].Rows[0].Text))).Count().ToString();
                    }
                }

                using (Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    workbook.SaveAs(stream);
                }
            }
        }

        public static void OpenDocument()
        {
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = filePath,
                UseShellExecute = true
            };
            Process.Start(psInfo);
        }
    }
}
