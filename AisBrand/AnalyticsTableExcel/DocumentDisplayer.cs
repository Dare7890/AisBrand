using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AnalyticsTableExcel.Statistics;
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
            IEnumerable<string> statistic1Header = HeadSetter.GetStatistic1Header();
            IEnumerable<string> statistic2Header = HeadSetter.GetStatistic2Header();
            IEnumerable<string> statistic3Header = HeadSetter.GetStatistic3Header();
            IEnumerable<string> statistic4Header = HeadSetter.GetStatistic4Header();
            IEnumerable<string> statistic5Header = HeadSetter.GetStatistic5Header();
            IEnumerable<string> statistic6Header = HeadSetter.GetStatistic6Header();
            IList<string[]> hardStatisticHeader = HeadSetter.GetScalarMultipleHeader(brandPropertyHeaders);

            ExcavationViewModelFiller filler = new();

            IEnumerable<ExcavationViewModel> excavationData = filler.Fill(excavations);
            IEnumerable<Statistic1ViewModel> statistic1Data = filler.FillStatistic1(excavations);
            IEnumerable<Statistic2ViewModel> statistic2Data = filler.FillStatistic2(excavations);
            IEnumerable<Statistic3ViewModel> statistic3Data = filler.FillStatistic3(excavations);
            IEnumerable<Statistic4ViewModel> statistic4Data = filler.FillStatistic4(excavations);
            IEnumerable<Statistic5ViewModel> statistic5Data = filler.FillStatistic5(excavations);
            IEnumerable<Statistic6ViewModel> statistic6Data = filler.FillStatistic6(excavations);

            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;

                IWorkbook workbook = application.Workbooks.Create(6);

                IWorksheet firstWorksheet = workbook.Worksheets[0];
                firstWorksheet.ImportArray(statistic1Header.ToArray(), 1, 1, false);
                firstWorksheet.ImportData(statistic1Data, 2, 1, false);

                firstWorksheet.InsertColumn(8);
                for (int i = 1; i < firstWorksheet.Rows.Length; i++)
                {
                    decimal analogySum = excavationData.Where(e => e.Formation == firstWorksheet.Columns[1].Rows[i].Text &&
                                e.Monument == firstWorksheet.Columns[0].Rows[i].Text &&
                                (!e.Square.HasValue && firstWorksheet.Columns[3].Rows[i].Text == null ||
                                e.Square.Value.ToString() == firstWorksheet.Columns[3].Rows[i].Text) &&
                                e.Sprinkling.Split('/', 1).FirstOrDefault() == firstWorksheet.Columns[4].Rows[i].Text.Split('/', 1).FirstOrDefault()).Sum(s => {
                                    if (decimal.TryParse(s.Analogy, out decimal result))
                                    {
                                        return result;
                                    }

                                    return 0;
                                });
                    decimal currentAnalogy = string.IsNullOrWhiteSpace(firstWorksheet.Columns[6].Rows[i].Text) ? 0m : decimal.Parse(firstWorksheet.Columns[6].Rows[i].Text);
                    firstWorksheet.Columns[7].Rows[i].Text = analogySum == 0 ? "0" : (currentAnalogy / analogySum * 100).ToString("0.####");
                }
                firstWorksheet.ImportArray(new string[] { "% от части" }, 1, 8, false);
                firstWorksheet.InsertColumn(9);
                for (int i = 1; i < firstWorksheet.Rows.Length; i++)
                {
                    decimal analogySum = excavationData.Where(e => e.Formation == firstWorksheet.Columns[1].Rows[i].Text &&
                                e.Monument == firstWorksheet.Columns[0].Rows[i].Text &&
                                e.Description == firstWorksheet.Columns[2].Rows[i].Text &&
                                (!e.Square.HasValue && firstWorksheet.Columns[3].Rows[i].Text == null ||
                                e.Square.Value.ToString() == firstWorksheet.Columns[3].Rows[i].Text)).Sum(s =>
                                {
                                    if (decimal.TryParse(s.Analogy, out decimal result))
                                    {
                                        return result;
                                    }

                                    return 0;
                                });
                    decimal currentAnalogy = string.IsNullOrWhiteSpace(firstWorksheet.Columns[6].Rows[i].Text) ? 0m : decimal.Parse(firstWorksheet.Columns[6].Rows[i].Text);
                    firstWorksheet.Columns[8].Rows[i].Text = analogySum == 0 ? "0" : (currentAnalogy / analogySum * 100).ToString("0.####");
                }

                firstWorksheet.ImportArray(new string[] { "%" }, 1, 9, false);

                IWorksheet secondWorksheet = workbook.Worksheets[1];
                secondWorksheet.ImportArray(statistic2Header.ToArray(), 1, 1, false);
                secondWorksheet.ImportData(statistic2Data, 2, 1, false);

                secondWorksheet.InsertColumn(13);
                for (int i = 1; i < secondWorksheet.Rows.Length; i++)
                {
                    decimal analogySum = excavationData.Where(e => e.Formation == secondWorksheet.Columns[1].Rows[i].Text &&
                                e.Monument == secondWorksheet.Columns[0].Rows[i].Text &&
                                (!e.Square.HasValue && secondWorksheet.Columns[3].Rows[i].Text == null ||
                                e.Square.Value.ToString() == secondWorksheet.Columns[3].Rows[i].Text) &&
                                e.Sprinkling.Split('/', 1).FirstOrDefault() == secondWorksheet.Columns[4].Rows[i].Text.Split('/', 1).FirstOrDefault()).Sum(s => {
                                    if (decimal.TryParse(s.Analogy, out decimal result))
                                    {
                                        return result;
                                    }

                                    return 0;
                                });
                    decimal currentAnalogy = string.IsNullOrWhiteSpace(secondWorksheet.Columns[11].Rows[i].Text) ? 0m : decimal.Parse(secondWorksheet.Columns[11].Rows[i].Text);
                    secondWorksheet.Columns[12].Rows[i].Text = analogySum == 0 ? "0" : (currentAnalogy / analogySum * 100).ToString("0.####");
                }
                secondWorksheet.ImportArray(new string[] { "% от части" }, 1, 13, false);
                secondWorksheet.InsertColumn(14);
                for (int i = 1; i < secondWorksheet.Rows.Length; i++)
                {
                    decimal analogySum = excavationData.Where(e => e.Formation == secondWorksheet.Columns[1].Rows[i].Text &&
                                e.Monument == secondWorksheet.Columns[0].Rows[i].Text &&
                                e.Description == secondWorksheet.Columns[2].Rows[i].Text &&
                                (!e.Square.HasValue && secondWorksheet.Columns[3].Rows[i].Text == null ||
                                e.Square.Value.ToString() == secondWorksheet.Columns[3].Rows[i].Text)).Sum(s =>
                                {
                                    if (decimal.TryParse(s.Analogy, out decimal result))
                                    {
                                        return result;
                                    }

                                    return 0;
                                });
                    decimal currentAnalogy = string.IsNullOrWhiteSpace(secondWorksheet.Columns[11].Rows[i].Text) ? 0m : decimal.Parse(secondWorksheet.Columns[11].Rows[i].Text);
                    secondWorksheet.Columns[13].Rows[i].Text = analogySum == 0 ? "0" : (currentAnalogy / analogySum * 100).ToString("0.####");
                }

                secondWorksheet.ImportArray(new string[] { "%" }, 1, 14, false);

                IWorksheet thirdWorksheet = workbook.Worksheets[2];
                thirdWorksheet.ImportArray(statistic3Header.ToArray(), 1, 1, false);
                thirdWorksheet.ImportData(statistic3Data, 2, 1, false);

                thirdWorksheet.InsertColumn(7);
                for (int i = 1; i < thirdWorksheet.Rows.Length; i++)
                {
                    decimal analogySum = excavationData.Where(e => e.Formation == thirdWorksheet.Columns[1].Rows[i].Text &&
                                e.Monument == thirdWorksheet.Columns[0].Rows[i].Text &&
                                e.Sprinkling.Split('/', 1).FirstOrDefault() == thirdWorksheet.Columns[3].Rows[i].Text.Split('/', 1).FirstOrDefault()).Sum(s => {
                                    if (decimal.TryParse(s.Analogy, out decimal result))
                                    {
                                        return result;
                                    }

                                    return 0;
                                });
                    decimal currentAnalogy = string.IsNullOrWhiteSpace(thirdWorksheet.Columns[5].Rows[i].Text) ? 0m : decimal.Parse(thirdWorksheet.Columns[5].Rows[i].Text);
                    thirdWorksheet.Columns[6].Rows[i].Text = analogySum == 0 ? "0" : (currentAnalogy / analogySum * 100).ToString("0.####");
                }
                thirdWorksheet.ImportArray(new string[] { "% от части" }, 1, 7, false);
                thirdWorksheet.InsertColumn(8);
                for (int i = 1; i < thirdWorksheet.Rows.Length; i++)
                {
                    decimal analogySum = excavationData.Where(e => e.Formation == thirdWorksheet.Columns[1].Rows[i].Text &&
                                e.Monument == thirdWorksheet.Columns[0].Rows[i].Text &&
                                e.Description == thirdWorksheet.Columns[2].Rows[i].Text).Sum(s =>
                                {
                                    if (decimal.TryParse(s.Analogy, out decimal result))
                                    {
                                        return result;
                                    }

                                    return 0;
                                });
                    decimal currentAnalogy = string.IsNullOrWhiteSpace(thirdWorksheet.Columns[5].Rows[i].Text) ? 0m : decimal.Parse(thirdWorksheet.Columns[5].Rows[i].Text);
                    thirdWorksheet.Columns[7].Rows[i].Text = analogySum == 0 ? "0" : (currentAnalogy / analogySum * 100).ToString("0.####");
                }

                thirdWorksheet.ImportArray(new string[] { "%" }, 1, 8, false);

                IWorksheet fourthWorksheet = workbook.Worksheets[3];
                fourthWorksheet.ImportArray(statistic4Header.ToArray(), 1, 1, false);
                fourthWorksheet.ImportData(statistic4Data, 2, 1, false);

                fourthWorksheet.InsertColumn(12);
                for (int i = 1; i < fourthWorksheet.Rows.Length; i++)
                {
                    decimal analogySum = excavationData.Where(e => e.Formation == fourthWorksheet.Columns[1].Rows[i].Text &&
                                e.Monument == fourthWorksheet.Columns[0].Rows[i].Text &&
                                e.Sprinkling.Split('/', 1).FirstOrDefault() == fourthWorksheet.Columns[3].Rows[i].Text.Split('/', 1).FirstOrDefault()).Sum(s => {
                                    if (decimal.TryParse(s.Analogy, out decimal result))
                                    {
                                        return result;
                                    }

                                    return 0;
                                });
                    decimal currentAnalogy = string.IsNullOrWhiteSpace(fourthWorksheet.Columns[10].Rows[i].Text) ? 0m : decimal.Parse(fourthWorksheet.Columns[10].Rows[i].Text);
                    fourthWorksheet.Columns[11].Rows[i].Text = analogySum == 0 ? "0" : (currentAnalogy / analogySum * 100).ToString("0.####");
                }
                fourthWorksheet.ImportArray(new string[] { "% от части" }, 1, 12, false);
                fourthWorksheet.InsertColumn(13);
                for (int i = 1; i < fourthWorksheet.Rows.Length; i++)
                {
                    decimal analogySum = excavationData.Where(e => e.Formation == fourthWorksheet.Columns[1].Rows[i].Text &&
                                e.Monument == fourthWorksheet.Columns[0].Rows[i].Text &&
                                e.Description == fourthWorksheet.Columns[2].Rows[i].Text).Sum(s =>
                                {
                                    if (decimal.TryParse(s.Analogy, out decimal result))
                                    {
                                        return result;
                                    }

                                    return 0;
                                });
                    decimal currentAnalogy = string.IsNullOrWhiteSpace(fourthWorksheet.Columns[10].Rows[i].Text) ? 0m : decimal.Parse(fourthWorksheet.Columns[10].Rows[i].Text);
                    fourthWorksheet.Columns[12].Rows[i].Text = analogySum == 0 ? "0" : (currentAnalogy / analogySum * 100).ToString("0.####");
                }

                fourthWorksheet.ImportArray(new string[] { "%" }, 1, 13, false);

                IWorksheet fifthWorksheet = workbook.Worksheets[4];
                fifthWorksheet.ImportArray(statistic5Header.ToArray(), 1, 1, false);
                fifthWorksheet.ImportData(statistic5Data, 2, 1, false);

                fifthWorksheet.InsertColumn(6);
                for (int i = 1; i < fifthWorksheet.Rows.Length; i++)
                {
                    decimal analogySum = excavationData.Where(e => e.Formation == fifthWorksheet.Columns[1].Rows[i].Text &&
                                e.Monument == fifthWorksheet.Columns[0].Rows[i].Text &&
                                e.Sprinkling.Split('/', 1).FirstOrDefault() == fifthWorksheet.Columns[2].Rows[i].Text.Split('/', 1).FirstOrDefault()).Sum(s => {
                                    if (decimal.TryParse(s.Analogy, out decimal result))
                                    {
                                        return result;
                                    }

                                    return 0;
                                });
                    decimal currentAnalogy = string.IsNullOrWhiteSpace(fifthWorksheet.Columns[4].Rows[i].Text) ? 0m : decimal.Parse(fifthWorksheet.Columns[4].Rows[i].Text);
                    fifthWorksheet.Columns[5].Rows[i].Text = analogySum == 0 ? "0" : (currentAnalogy / analogySum * 100).ToString("0.####");
                }
                fifthWorksheet.ImportArray(new string[] { "% от части" }, 1, 6, false);
                fifthWorksheet.InsertColumn(7);
                for (int i = 1; i < fifthWorksheet.Rows.Length; i++)
                {
                    decimal analogySum = excavationData.Where(e => e.Formation == fifthWorksheet.Columns[1].Rows[i].Text &&
                                e.Monument == fifthWorksheet.Columns[0].Rows[i].Text).Sum(s =>
                                {
                                    if (decimal.TryParse(s.Analogy, out decimal result))
                                    {
                                        return result;
                                    }

                                    return 0;
                                });
                    decimal currentAnalogy = string.IsNullOrWhiteSpace(fifthWorksheet.Columns[4].Rows[i].Text) ? 0m : decimal.Parse(fifthWorksheet.Columns[4].Rows[i].Text);
                    fifthWorksheet.Columns[6].Rows[i].Text = analogySum == 0 ? "0" : (currentAnalogy / analogySum * 100).ToString("0.####");
                }

                fifthWorksheet.ImportArray(new string[] { "%" }, 1, 7, false);

                IWorksheet sixWorksheet = workbook.Worksheets[5];
                sixWorksheet.ImportArray(statistic6Header.ToArray(), 1, 1, false);
                sixWorksheet.ImportData(statistic6Data, 2, 1, false);

                sixWorksheet.InsertColumn(11);
                for (int i = 1; i < sixWorksheet.Rows.Length; i++)
                {
                    decimal analogySum = excavationData.Where(e => e.Formation == sixWorksheet.Columns[1].Rows[i].Text &&
                                e.Monument == sixWorksheet.Columns[0].Rows[i].Text &&
                                e.Sprinkling.Split('/', 1).FirstOrDefault() == sixWorksheet.Columns[2].Rows[i].Text.Split('/', 1).FirstOrDefault()).Sum(s => {
                                    if (decimal.TryParse(s.Analogy, out decimal result))
                                    {
                                        return result;
                                    }

                                    return 0;
                                });
                    decimal currentAnalogy = string.IsNullOrWhiteSpace(sixWorksheet.Columns[9].Rows[i].Text) ? 0m : decimal.Parse(sixWorksheet.Columns[9].Rows[i].Text);
                    sixWorksheet.Columns[10].Rows[i].Text = analogySum == 0 ? "0" : (currentAnalogy / analogySum * 100).ToString("0.####");
                }
                sixWorksheet.ImportArray(new string[] { "% от части" }, 1, 11, false);
                sixWorksheet.InsertColumn(12);
                for (int i = 1; i < sixWorksheet.Rows.Length; i++)
                {
                    decimal analogySum = excavationData.Where(e => e.Formation == sixWorksheet.Columns[1].Rows[i].Text &&
                                e.Monument == sixWorksheet.Columns[0].Rows[i].Text).Sum(s =>
                                {
                                    if (decimal.TryParse(s.Analogy, out decimal result))
                                    {
                                        return result;
                                    }

                                    return 0;
                                });
                    decimal currentAnalogy = string.IsNullOrWhiteSpace(sixWorksheet.Columns[9].Rows[i].Text) ? 0m : decimal.Parse(sixWorksheet.Columns[9].Rows[i].Text);
                    sixWorksheet.Columns[11].Rows[i].Text = analogySum == 0 ? "0" : (currentAnalogy / analogySum * 100).ToString("0.####");
                }

                secondWorksheet.ImportArray(new string[] { "%" }, 1, 12, false);
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
