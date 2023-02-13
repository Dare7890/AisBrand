using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using BrandDataProcessing;
using BrandDataProcessing.Constants;
using BrandDataProcessing.Models;
using Syncfusion.XlsIO;

namespace AnalyticsTableExcel
{
    public class DocumentDisplayer
    {
        private const int headerRowsAmount = 6;
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
            IEnumerable<string> statisticHeader = HeadSetter.GetStatisticHeader();
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
                for (int i = 0; i < hardStatisticHeader.Count(); i++)
                {
                    secondWorksheet.ImportArray(hardStatisticHeader[i], 1, i + 1, true);
                }
                secondWorksheet.ImportArray(SubFieldsRetriever.Retrieve().Sprinklings.ToArray(), 6, 1, true);
                List<HardStatisticViewModel> choosedExcavations = new List<HardStatisticViewModel>();
                AddSequenceNumber(secondWorksheet);
                for (int i = 6; i < SubFieldsRetriever.Retrieve().Sprinklings.Count() + 6; i++)
                {
                    for (int j = 1; j < 1 + hardStatisticHeader.Skip(1).Count(); j++)
                    {
                        decimal excavationsAmount = excavationData.Where
                            (e => e.Sprinkling == secondWorksheet.Columns[0].Rows[i].Text &&
                            e.Safety != null && e.Safety.Contains(secondWorksheet.Columns[j].Rows[0].Text) &&
                            e.Relief != null && e.Relief.Contains(secondWorksheet.Columns[j].Rows[1].Text) &&
                            e.ReconstructionReliability != null && e.ReconstructionReliability.Contains(secondWorksheet.Columns[j].Rows[2].Text) &&
                            e.Clay != null && e.Clay.Contains(secondWorksheet.Columns[j].Rows[3].Text) &&
                            e.Admixture != null && e.Admixture.Contains(secondWorksheet.Columns[j].Rows[4].Text)).Sum(s => {
                                if (decimal.TryParse(s.Analogy, out decimal result))
                                {
                                    return result;
                                }

                                return 0;
                            });
                        secondWorksheet.Columns[j].Rows[i].Text = excavationsAmount.ToString();
                        if (excavationsAmount > 0)
                        {
                            HardStatisticViewModel choosedExcavation = new()
                            {
                                Admixture = secondWorksheet.Columns[j].Rows[4].Text,
                                ReconstructionReliability = secondWorksheet.Columns[j].Rows[2].Text,
                                Clay = secondWorksheet.Columns[j].Rows[3].Text,
                                Safety = secondWorksheet.Columns[j].Rows[0].Text,
                                Relief = secondWorksheet.Columns[j].Rows[1].Text,
                                Sprinkling = secondWorksheet.Columns[0].Rows[i].Text,
                                SequencesNumber = j - 1
                            };
                            choosedExcavations.Add(choosedExcavation);
                        }
                    }
                }

                DeleteEmptyColumns(secondWorksheet, headerRowsAmount);
                DeleteEmptyRows(secondWorksheet);
                secondWorksheet.ImportArray(new string[] { "Вариант" }, 6, 1, false);


                IWorksheet thirdWorksheet = workbook.Worksheets[2];
                thirdWorksheet.ImportArray(statisticHeader.ToArray(), 1, 1, false);
                thirdWorksheet.ImportData(statisticData, 2, 1, false);

                thirdWorksheet.InsertColumn(1);
                foreach (var row in firstWorksheet.Rows)
                {
                    if (row.Row == 1)
                    {
                        continue;
                    }

                    int? sequencesNumber = choosedExcavations.FirstOrDefault(e =>
                        e.ReconstructionReliability == row.Columns[8].Text &&
                        e.Clay == row.Columns[9].Text &&
                        e.Admixture == row.Columns[10].Text &&
                        e.Safety == row.Columns[11].Text &&
                        e.Relief == row.Columns[12].Text)?.SequencesNumber;
                    if (sequencesNumber.HasValue)
                    {
                        thirdWorksheet.Columns[0].Rows[row.Row - 1].Text = (sequencesNumber.Value + 1).ToString();
                    }
                }
                thirdWorksheet.ImportArray(new string[] { "Технология" }, 1, 1, false);

                thirdWorksheet.InsertColumn(8, 2);
                for (int i = 1; i < thirdWorksheet.Rows.Length; i++)
                {
                    decimal analogySum = excavationData.Where(e => e.Formation == thirdWorksheet.Columns[3].Rows[i].Text &&
                                e.Monument == thirdWorksheet.Columns[2].Rows[i].Text).Sum(s => {
                                    if (decimal.TryParse(s.Analogy, out decimal result))
                                    {
                                        return result;
                                    }

                                    return 0;
                                });
                    decimal currentAnalogy = string.IsNullOrWhiteSpace(thirdWorksheet.Columns[6].Rows[i].Text) ? 0m : decimal.Parse(thirdWorksheet.Columns[6].Rows[i].Text);
                    thirdWorksheet.Columns[7].Rows[i].Text = analogySum == 0 ? "0" : (currentAnalogy / analogySum * 100).ToString("0.##");
                    thirdWorksheet.Columns[8].Rows[i].Text = analogySum.ToString("0.##");
                }
                thirdWorksheet.ImportArray(new string[] { "% в пласте", "Всего в пласте" }, 1, 8, false);
                thirdWorksheet.InsertColumn(10, 2);
                for (int i = 1; i < thirdWorksheet.Rows.Length; i++)
                {
                    decimal analogySum = excavationData.Where(e => e.Formation == thirdWorksheet.Columns[3].Rows[i].Text &&
                                e.Monument == thirdWorksheet.Columns[2].Rows[i].Text &&
                                e.Description == thirdWorksheet.Columns[4].Rows[i].Text).Sum(s =>
                                {
                                    if (decimal.TryParse(s.Analogy, out decimal result))
                                    {
                                        return result;
                                    }

                                    return 0;
                                });
                    decimal currentAnalogy = string.IsNullOrWhiteSpace(thirdWorksheet.Columns[6].Rows[i].Text) ? 0m : decimal.Parse(thirdWorksheet.Columns[6].Rows[i].Text);
                    thirdWorksheet.Columns[9].Rows[i].Text = analogySum == 0 ? "0" : (currentAnalogy / analogySum * 100).ToString("0.##");
                    thirdWorksheet.Columns[10].Rows[i].Text = analogySum.ToString("0.##");
                }

                thirdWorksheet.ImportArray(new string[] { "% в комплексе", "Всего в комплексе" }, 1, 10, false);
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

        private static void DeleteEmptyRows(IWorksheet worksheet, int skipColumnsAmount = 1)
        {
            int counter = 0;
            List<int> deletedRowsIndexes = new List<int>(0);
            foreach (var row in worksheet.Rows)
            {
                if (row.Columns.Skip(skipColumnsAmount).All(r => r.Text == "0"))
                {
                    deletedRowsIndexes.Add(row.Row - counter);
                    counter++;
                }
            }
            foreach (var deletedRowIndexes in deletedRowsIndexes)
            {
                worksheet.DeleteRow(deletedRowIndexes);
            }
        }

        private static void AddSequenceNumber(IWorksheet worksheet)
        {
            worksheet.InsertRow(6, 1);
            int columnsAmount = worksheet.Columns.Length - typedColumnsAmount;
            worksheet.ImportArray(Enumerable.Range(1, columnsAmount).ToArray(), 6, 2, false);
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
