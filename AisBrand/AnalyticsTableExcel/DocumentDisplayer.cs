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
        private const int headerRowsAmount = 5;
        private const int typedColumnsAmount = 3;
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
            IList<string[]> hardStatisticHeader = HeadSetter.GetScalarMultipleHeader(brandPropertyHeaders);

            ExcavationViewModelFiller filler = new();

            IEnumerable<ExcavationViewModel> excavationData = filler.Fill(excavations);
            IEnumerable<StatisticViewModel> statisticData = filler.FillStatistic(excavations);

            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;

                IWorkbook workbook = application.Workbooks.Create(3);
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

                DeleteEmptyColumns(secondWorksheet);

                IWorksheet thirdWorksheet = workbook.Worksheets[2];
                for (int i = 0; i < hardStatisticHeader.Count(); i++)
                {
                    thirdWorksheet.ImportArray(hardStatisticHeader[i], 1, i + 1, true);
                }
                List<HardStatisticViewModel> choosedExcavations = new List<HardStatisticViewModel>();
                thirdWorksheet.ImportData(statisticData, 5, 1, false);
                AddSequenceNumber(thirdWorksheet);
                for (int i = 5; i < statisticData.Count() + 5; i++)
                {
                    for (int j = 3; j < 3 + hardStatisticHeader.Skip(3).Count(); j++)
                    {
                        int excavationsAmount = excavationData.Where
                            (e => e.Type == thirdWorksheet.Columns[0].Rows[i].Text &&
                            e.Variant == thirdWorksheet.Columns[1].Rows[i].Text &&
                            e.Dating == thirdWorksheet.Columns[2].Rows[i].Text &&
                            (e.Clay.Contains(thirdWorksheet.Columns[j].Rows[1].Text) &&
                            e.Admixture.Contains(thirdWorksheet.Columns[j].Rows[2].Text) &&
                            e.Sprinkling.Contains(thirdWorksheet.Columns[j].Rows[3].Text) &&
                            e.ReconstructionReliability.Contains(thirdWorksheet.Columns[j].Rows[0].Text))).Count();
                        thirdWorksheet.Columns[j].Rows[i].Text = excavationsAmount.ToString();
                        if (excavationsAmount > 0)
                        {
                            HardStatisticViewModel choosedExcavation = new()
                            {
                                Admixture = thirdWorksheet.Columns[j].Rows[2].Text,
                                Sprinkling = thirdWorksheet.Columns[j].Rows[3].Text,
                                ReconstructionReliability = thirdWorksheet.Columns[j].Rows[0].Text,
                                Clay = thirdWorksheet.Columns[j].Rows[1].Text,
                                Dating = thirdWorksheet.Columns[2].Rows[i].Text,
                                Variant = thirdWorksheet.Columns[1].Rows[i].Text,
                                Type = thirdWorksheet.Columns[0].Rows[i].Text,
                                SequencesNumber = j - 2
                            };
                            choosedExcavations.Add(choosedExcavation);
                        }
                    }
                }

                DeleteEmptyColumns(thirdWorksheet, headerRowsAmount);

                firstWorksheet.InsertColumn(firstWorksheet.Columns.Length + 1);
                foreach (var row in firstWorksheet.Rows)
                {
                    if (row.Row == 1)
                    {
                        continue;
                    }

                    int? sequencesNumber = choosedExcavations.FirstOrDefault(e => e.Type == row.Columns[7].Text &&
                        e.Variant == row.Columns[8].Text &&
                        e.ReconstructionReliability == row.Columns[9].Text &&
                        e.Clay == row.Columns[10].Text &&
                        e.Admixture == row.Columns[11].Text &&
                        e.Sprinkling == row.Columns[12].Text &&
                        e.Dating == row.Columns[13].Text)?.SequencesNumber;
                    if (sequencesNumber.HasValue)
                    {
                        firstWorksheet.Columns[17].Rows[row.Row - 1].Text = sequencesNumber.Value.ToString();
                    }
                }
                using (Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    workbook.SaveAs(stream);
                }
            }
        }

        private static void DeleteEmptyColumns(IWorksheet worksheet, int skipRowsAmount = 1)
        {
            int counter = 0;
            List<int> deletedColumnIndexes = new List<int>(0);
            foreach (var column in worksheet.Columns)
            {
                if (column.Rows.Skip(skipRowsAmount).All(r => r.Text == "0"))
                {
                    deletedColumnIndexes.Add(column.Column - counter);
                    counter++;
                }
            }
            foreach (var deletedColumnIndex in deletedColumnIndexes)
            {
                worksheet.DeleteColumn(deletedColumnIndex);
            }
        }

        private static void AddSequenceNumber(IWorksheet worksheet)
        {
            worksheet.InsertRow(5, 1);
            int columnsAmount = worksheet.Columns.Length - typedColumnsAmount;
            worksheet.ImportArray(Enumerable.Range(1, columnsAmount).ToArray(), 5, 4, false);
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
