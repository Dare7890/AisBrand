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

                IWorkbook workbook = application.Workbooks.Create(7);
                IWorksheet seventhWorksheet = workbook.Worksheets[6];

                IWorksheet firstWorksheet = workbook.Worksheets[0];
                firstWorksheet.ImportArray(statistic1Header.ToArray(), 1, 1, false);
                firstWorksheet.ImportData(statistic1Data, 2, 1, false);

                firstWorksheet.InsertColumn(7);
                for (int i = 1; i < firstWorksheet.Rows.Length; i++)
                {
                    decimal analogySum = excavationData.Where(e => e.Formation == firstWorksheet.Columns[1].Rows[i].Text &&
                                e.Monument == firstWorksheet.Columns[0].Rows[i].Text &&
                                e.Sprinkling.Split('/', 1).FirstOrDefault() == firstWorksheet.Columns[3].Rows[i].Text.Split('/', 1).FirstOrDefault()).Sum(s => {
                                    if (decimal.TryParse(s.Analogy, out decimal result))
                                    {
                                        return result;
                                    }

                                    return 0;
                                });
                    decimal currentAnalogy = string.IsNullOrWhiteSpace(firstWorksheet.Columns[5].Rows[i].Text) ? 0m : decimal.Parse(firstWorksheet.Columns[5].Rows[i].Text);
                    firstWorksheet.Columns[6].Rows[i].Text = analogySum == 0 ? "0" : (currentAnalogy / analogySum * 100).ToString("0.####");
                }
                firstWorksheet.ImportArray(new string[] { "% от части" }, 1, 7, false);
                var firstSquares = excavationData.Select(e => e.Square.HasValue ? e.Square.Value.ToString() : string.Empty).Distinct().ToArray();
                firstWorksheet.ImportArray(firstSquares, 1, 8, false);

                for (int i = 1; i < firstWorksheet.Rows.Length; i++)
                {
                    for (int j = 7; j < 7 + firstSquares.Length; j++)
                    {
                        decimal excavationsAmount = excavationData.Where
                            (e => e.Monument == firstWorksheet.Columns[0].Rows[i].Text &&
                            e.Formation == firstWorksheet.Columns[1].Rows[i].Text &&
                            (e.Description == firstWorksheet.Columns[2].Rows[i].Text ||
                            string.IsNullOrEmpty(e.Description) && string.IsNullOrEmpty(firstWorksheet.Columns[2].Rows[i].DisplayText)) &&
                            (!e.Square.HasValue && string.IsNullOrEmpty(firstWorksheet.Columns[j].Rows[0].DisplayText) ||
                                e.Square.HasValue && e.Square.Value.ToString() == firstWorksheet.Columns[j].Rows[0].DisplayText) &&
                            e.Sprinkling == firstWorksheet.Columns[3].Rows[i].Text &&
                            e.Dating == firstWorksheet.Columns[4].Rows[i].Text).Sum(s =>
                            {
                                if (decimal.TryParse(s.Analogy, out decimal result))
                                {
                                    return result;
                                }

                                return 0;
                            });
                        firstWorksheet.Columns[j].Rows[i].Text = excavationsAmount.ToString();
                    }
                }

                IWorksheet secondWorksheet = workbook.Worksheets[1];
                secondWorksheet.ImportArray(statistic2Header.ToArray(), 1, 1, false);
                secondWorksheet.ImportData(statistic2Data, 2, 1, false);

                secondWorksheet.InsertColumn(11);
                for (int i = 1; i < secondWorksheet.Rows.Length; i++)
                {
                    decimal analogySum = excavationData.Where(e => e.Formation == secondWorksheet.Columns[1].Rows[i].Text &&
                                e.Monument == secondWorksheet.Columns[0].Rows[i].Text &&
                                e.Sprinkling.Split('/', 1).FirstOrDefault() == secondWorksheet.Columns[3].Rows[i].Text.Split('/', 1).FirstOrDefault()).Sum(s => {
                                    if (decimal.TryParse(s.Analogy, out decimal result))
                                    {
                                        return result;
                                    }

                                    return 0;
                                });
                    decimal currentAnalogy = string.IsNullOrWhiteSpace(secondWorksheet.Columns[9].Rows[i].Text) ? 0m : decimal.Parse(secondWorksheet.Columns[9].Rows[i].Text);
                    secondWorksheet.Columns[10].Rows[i].Text = analogySum == 0 ? "0" : (currentAnalogy / analogySum * 100).ToString("0.####");
                }
                secondWorksheet.ImportArray(new string[] { "% от части" }, 1, 11, false);
                secondWorksheet.InsertColumn(12);
                for (int i = 1; i < secondWorksheet.Rows.Length; i++)
                {
                    decimal analogySum = excavationData.Where(e => e.Formation == secondWorksheet.Columns[1].Rows[i].Text &&
                                e.Monument == secondWorksheet.Columns[0].Rows[i].Text &&
                                e.Description == secondWorksheet.Columns[2].Rows[i].Text).Sum(s =>
                                {
                                    if (decimal.TryParse(s.Analogy, out decimal result))
                                    {
                                        return result;
                                    }

                                    return 0;
                                });
                    decimal currentAnalogy = string.IsNullOrWhiteSpace(secondWorksheet.Columns[9].Rows[i].Text) ? 0m : decimal.Parse(secondWorksheet.Columns[9].Rows[i].Text);
                    secondWorksheet.Columns[11].Rows[i].Text = analogySum == 0 ? "0" : (currentAnalogy / analogySum * 100).ToString("0.####");
                }

                secondWorksheet.ImportArray(new string[] { "%" }, 1, 12, false);

                var secondSquares = excavationData.Select(e => e.Square.HasValue ? e.Square.Value.ToString() : string.Empty).Distinct().ToArray();
                secondWorksheet.ImportArray(secondSquares, 1, 13, false);

                for (int i = 1; i < secondWorksheet.Rows.Length; i++)
                {
                    for (int j = 12; j < 12 + secondSquares.Length; j++)
                    {
                        decimal excavationsAmount = excavationData.Where
                            (e => e.Monument == secondWorksheet.Columns[0].Rows[i].Text &&
                            e.Formation == secondWorksheet.Columns[1].Rows[i].Text &&
                            (e.Description == secondWorksheet.Columns[2].Rows[i].Text ||
                            string.IsNullOrEmpty(e.Description) && string.IsNullOrEmpty(secondWorksheet.Columns[2].Rows[i].DisplayText)) &&
                            (!e.Square.HasValue && string.IsNullOrEmpty(secondWorksheet.Columns[j].Rows[0].DisplayText) ||
                                e.Square.HasValue && e.Square.Value.ToString() == secondWorksheet.Columns[j].Rows[0].DisplayText) &&
                            e.Sprinkling == secondWorksheet.Columns[3].Rows[i].Text &&
                            e.Safety != null && e.Safety.Contains(secondWorksheet.Columns[7].Rows[i].Text) &&
                            e.Relief != null && e.Relief.Contains(secondWorksheet.Columns[8].Rows[i].Text) &&
                            e.ReconstructionReliability != null && e.ReconstructionReliability.Contains(secondWorksheet.Columns[4].Rows[i].Text) &&
                            e.Clay != null && e.Clay.Contains(secondWorksheet.Columns[5].Rows[i].Text) &&
                            e.Admixture != null && e.Admixture.Contains(secondWorksheet.Columns[6].Rows[i].Text)).Sum(s =>
                            {
                                if (decimal.TryParse(s.Analogy, out decimal result))
                                {
                                    return result;
                                }

                                return 0;
                            });
                        secondWorksheet.Columns[j].Rows[i].Text = excavationsAmount.ToString();
                    }
                }

                IWorksheet thirdWorksheet = workbook.Worksheets[2];
                thirdWorksheet.ImportArray(statistic3Header.ToArray(), 1, 1, false);
                thirdWorksheet.ImportData(statistic3Data, 2, 1, false);

                thirdWorksheet.InsertColumn(6);
                for (int i = 1; i < thirdWorksheet.Rows.Length; i++)
                {
                    decimal analogySum = excavationData.Where(e => e.Formation == thirdWorksheet.Columns[1].Rows[i].Text &&
                                e.Monument == thirdWorksheet.Columns[0].Rows[i].Text &&
                                e.Sprinkling.Split('/', 1).FirstOrDefault() == thirdWorksheet.Columns[2].Rows[i].Text.Split('/', 1).FirstOrDefault()).Sum(s => {
                                    if (decimal.TryParse(s.Analogy, out decimal result))
                                    {
                                        return result;
                                    }

                                    return 0;
                                });
                    decimal currentAnalogy = string.IsNullOrWhiteSpace(thirdWorksheet.Columns[4].Rows[i].Text) ? 0m : decimal.Parse(thirdWorksheet.Columns[4].Rows[i].Text);
                    thirdWorksheet.Columns[5].Rows[i].Text = analogySum == 0 ? "0" : (currentAnalogy / analogySum * 100).ToString("0.####");
                }
                thirdWorksheet.ImportArray(new string[] { "% от части" }, 1, 6, false);

                var thirdDescriptions = excavationData.Select(e => e.Description).Distinct().ToArray();
                thirdWorksheet.ImportArray(thirdDescriptions, 1, 7, false);

                for (int i = 1; i < thirdWorksheet.Rows.Length; i++)
                {
                    for (int j = 6; j < 6 + thirdDescriptions.Length; j++)
                    {
                        decimal excavationsAmount = excavationData.Where
                            (e => e.Monument == thirdWorksheet.Columns[0].Rows[i].Text &&
                            e.Formation == thirdWorksheet.Columns[1].Rows[i].Text &&
                            e.Description == thirdWorksheet.Columns[j].Rows[0].DisplayText &&
                            e.Sprinkling == thirdWorksheet.Columns[2].Rows[i].Text &&
                            e.Dating == thirdWorksheet.Columns[3].Rows[i].Text).Sum(s =>
                            {
                                if (decimal.TryParse(s.Analogy, out decimal result))
                                {
                                    return result;
                                }

                                return 0;
                            });
                        thirdWorksheet.Columns[j].Rows[i].Text = excavationsAmount.ToString();
                    }
                }

                IWorksheet fourthWorksheet = workbook.Worksheets[3];
                fourthWorksheet.ImportArray(statistic4Header.ToArray(), 1, 1, false);
                fourthWorksheet.ImportData(statistic4Data, 2, 1, false);

                fourthWorksheet.InsertColumn(10);
                for (int i = 1; i < fourthWorksheet.Rows.Length; i++)
                {
                    decimal analogySum = excavationData.Where(e => e.Formation == fourthWorksheet.Columns[1].Rows[i].Text &&
                                e.Monument == fourthWorksheet.Columns[0].Rows[i].Text &&
                                e.Sprinkling.Split('/', 1).FirstOrDefault() == fourthWorksheet.Columns[2].Rows[i].Text.Split('/', 1).FirstOrDefault()).Sum(s => {
                                    if (decimal.TryParse(s.Analogy, out decimal result))
                                    {
                                        return result;
                                    }

                                    return 0;
                                });
                    decimal currentAnalogy = string.IsNullOrWhiteSpace(fourthWorksheet.Columns[8].Rows[i].Text) ? 0m : decimal.Parse(fourthWorksheet.Columns[8].Rows[i].Text);
                    fourthWorksheet.Columns[9].Rows[i].Text = analogySum == 0 ? "0" : (currentAnalogy / analogySum * 100).ToString("0.####");
                }
                fourthWorksheet.ImportArray(new string[] { "% от части" }, 1, 10, false);
                fourthWorksheet.InsertColumn(11);
                for (int i = 1; i < fourthWorksheet.Rows.Length; i++)
                {
                    decimal analogySum = excavationData.Where(e => e.Formation == fourthWorksheet.Columns[1].Rows[i].Text &&
                                e.Monument == fourthWorksheet.Columns[0].Rows[i].Text).Sum(s =>
                                {
                                    if (decimal.TryParse(s.Analogy, out decimal result))
                                    {
                                        return result;
                                    }

                                    return 0;
                                });
                    decimal currentAnalogy = string.IsNullOrWhiteSpace(fourthWorksheet.Columns[8].Rows[i].Text) ? 0m : decimal.Parse(fourthWorksheet.Columns[8].Rows[i].Text);
                    fourthWorksheet.Columns[10].Rows[i].Text = analogySum == 0 ? "0" : (currentAnalogy / analogySum * 100).ToString("0.####");
                }

                fourthWorksheet.ImportArray(new string[] { "%" }, 1, 11, false);

                var fourthDescriptions = excavationData.Select(e => e.Description).Distinct().ToArray();
                fourthWorksheet.ImportArray(fourthDescriptions, 1, 12, false);
                for (int i = 1; i < fourthWorksheet.Rows.Length; i++)
                {
                    for (int j = 11; j < 11 + fourthDescriptions.Length; j++)
                    {
                        decimal excavationsAmount = excavationData.Where
                            (e => e.Monument == fourthWorksheet.Columns[0].Rows[i].Text &&
                            e.Formation == fourthWorksheet.Columns[1].Rows[i].Text &&
                            e.Description == fourthWorksheet.Columns[j].Rows[0].DisplayText &&
                            e.Sprinkling == fourthWorksheet.Columns[2].Rows[i].Text &&
                            e.Safety != null && e.Safety.Contains(fourthWorksheet.Columns[6].Rows[i].Text) &&
                            e.Relief != null && e.Relief.Contains(fourthWorksheet.Columns[7].Rows[i].Text) &&
                            e.ReconstructionReliability != null && e.ReconstructionReliability.Contains(fourthWorksheet.Columns[3].Rows[i].Text) &&
                            e.Clay != null && e.Clay.Contains(fourthWorksheet.Columns[4].Rows[i].Text) &&
                            e.Admixture != null && e.Admixture.Contains(fourthWorksheet.Columns[5].Rows[i].Text)).Sum(s =>
                            {
                                if (decimal.TryParse(s.Analogy, out decimal result))
                                {
                                    return result;
                                }

                                return 0;
                            });
                        fourthWorksheet.Columns[j].Rows[i].Text = excavationsAmount.ToString();
                    }
                }

                IWorksheet fifthWorksheet = workbook.Worksheets[4];
                fifthWorksheet.ImportArray(statistic5Header.ToArray(), 1, 1, false);
                fifthWorksheet.ImportData(statistic5Data, 2, 1, false);

                fifthWorksheet.InsertColumn(5);
                for (int i = 1; i < fifthWorksheet.Rows.Length; i++)
                {
                    decimal analogySum = excavationData.Where(e => e.Monument == fifthWorksheet.Columns[0].Rows[i].Text &&
                                e.Sprinkling.Split('/', 1).FirstOrDefault() == fifthWorksheet.Columns[1].Rows[i].Text.Split('/', 1).FirstOrDefault()).Sum(s => {
                                    if (decimal.TryParse(s.Analogy, out decimal result))
                                    {
                                        return result;
                                    }

                                    return 0;
                                });
                    decimal currentAnalogy = string.IsNullOrWhiteSpace(fifthWorksheet.Columns[3].Rows[i].Text) ? 0m : decimal.Parse(fifthWorksheet.Columns[3].Rows[i].Text);
                    fifthWorksheet.Columns[4].Rows[i].Text = analogySum == 0 ? "0" : (currentAnalogy / analogySum * 100).ToString("0.####");
                }
                fifthWorksheet.ImportArray(new string[] { "% от части" }, 1, 5, false);
                var fifthFormation = excavationData.Select(e => e.Formation).Distinct().ToArray();
                fifthWorksheet.ImportArray(fifthFormation, 1, 6, false);

                for (int i = 1; i < fifthWorksheet.Rows.Length; i++)
                {
                    for (int j = 5; j < 5 + fifthFormation.Length; j++)
                    {
                        decimal excavationsAmount = excavationData.Where
                            (e => e.Monument == fifthWorksheet.Columns[0].Rows[i].Text &&
                            e.Formation == fifthWorksheet.Columns[j].Rows[0].DisplayText &&
                            e.Sprinkling == fifthWorksheet.Columns[1].Rows[i].Text &&
                            e.Dating == fifthWorksheet.Columns[2].Rows[i].Text).Sum(s =>
                            {
                                if (decimal.TryParse(s.Analogy, out decimal result))
                                {
                                    return result;
                                }

                                return 0;
                            });
                        fifthWorksheet.Columns[j].Rows[i].Text = excavationsAmount.ToString();
                    }
                }

                IWorksheet sixWorksheet = workbook.Worksheets[5];
                sixWorksheet.ImportArray(statistic6Header.ToArray(), 1, 1, false);
                sixWorksheet.ImportData(statistic6Data, 2, 1, false);

                sixWorksheet.InsertColumn(9);
                for (int i = 1; i < sixWorksheet.Rows.Length; i++)
                {
                    decimal analogySum = excavationData.Where(e => e.Monument == sixWorksheet.Columns[0].Rows[i].Text &&
                                e.Sprinkling.Split('/').FirstOrDefault() == sixWorksheet.Columns[1].Rows[i].Text.Split('/').FirstOrDefault()).Sum(s => {
                                    if (decimal.TryParse(s.Analogy, out decimal result))
                                    {
                                        return result;
                                    }

                                    return 0;
                                });
                    decimal currentAnalogy = string.IsNullOrWhiteSpace(sixWorksheet.Columns[7].Rows[i].Text) ? 0m : decimal.Parse(sixWorksheet.Columns[7].Rows[i].Text);
                    sixWorksheet.Columns[8].Rows[i].Text = analogySum == 0 ? "0" : (currentAnalogy / analogySum * 100).ToString("0.####");
                }
                sixWorksheet.ImportArray(new string[] { "% от части" }, 1, 9, false);
                sixWorksheet.InsertColumn(10);
                for (int i = 1; i < sixWorksheet.Rows.Length; i++)
                {
                    decimal analogySum = excavationData.Where(e => e.Monument == sixWorksheet.Columns[0].Rows[i].Text).Sum(s =>
                                {
                                    if (decimal.TryParse(s.Analogy, out decimal result))
                                    {
                                        return result;
                                    }

                                    return 0;
                                });
                    decimal currentAnalogy = string.IsNullOrWhiteSpace(sixWorksheet.Columns[7].Rows[i].Text) ? 0m : decimal.Parse(sixWorksheet.Columns[7].Rows[i].Text);
                    sixWorksheet.Columns[9].Rows[i].Text = analogySum == 0 ? "0" : (currentAnalogy / analogySum * 100).ToString("0.####");
                }

                sixWorksheet.ImportArray(new string[] { "%" }, 1, 10, false);
                var sixFormation = excavationData.Select(e => e.Formation).Distinct().ToArray();
                sixWorksheet.ImportArray(sixFormation, 1, 11, false);
                for (int i = 1; i < sixWorksheet.Rows.Length; i++)
                {
                    for (int j = 10; j < 10 + sixFormation.Length; j++)
                    {
                        decimal excavationsAmount = excavationData.Where
                            (e => e.Monument == sixWorksheet.Columns[0].Rows[i].Text &&
                            e.Formation == sixWorksheet.Columns[j].Rows[0].DisplayText &&
                            e.Sprinkling == sixWorksheet.Columns[1].Rows[i].Text &&
                            e.Safety != null && e.Safety.Contains(sixWorksheet.Columns[5].Rows[i].Text) &&
                            e.Relief != null && e.Relief.Contains(sixWorksheet.Columns[6].Rows[i].Text) &&
                            e.ReconstructionReliability != null && e.ReconstructionReliability.Contains(sixWorksheet.Columns[2].Rows[i].Text) &&
                            e.Clay != null && e.Clay.Contains(sixWorksheet.Columns[3].Rows[i].Text) &&
                            e.Admixture != null && e.Admixture.Contains(sixWorksheet.Columns[4].Rows[i].Text)).Sum(s =>
                            {
                                if (decimal.TryParse(s.Analogy, out decimal result))
                                {
                                    return result;
                                }

                                return 0;
                            });
                        sixWorksheet.Columns[j].Rows[i].Text = excavationsAmount.ToString();
                    }
                }

                seventhWorksheet.ImportArray(header.ToArray(), 1, 1, false);
                seventhWorksheet.ImportData(excavationData.Where(d => !string.IsNullOrWhiteSpace(d.CollectorsNumber)), 2, 1, false);
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
