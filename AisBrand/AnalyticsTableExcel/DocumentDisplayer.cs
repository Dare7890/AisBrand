using System;
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
            IEnumerable<string> statistic3Header = HeadSetter.GetStatistic3Header();
            IEnumerable<string> statistic4Header = HeadSetter.GetStatistic4Header();
            IEnumerable<string> statistic5Header = HeadSetter.GetStatistic5Header();
            IEnumerable<string> statistic6Header = HeadSetter.GetStatistic6Header();
            IList<string[]> hardStatisticHeader = HeadSetter.GetScalarMultipleHeader(brandPropertyHeaders);

            ExcavationViewModelFiller filler = new();

            IEnumerable<ExcavationViewModel> excavationData = filler.Fill(excavations);
            IList<Statistic3ViewModel> statistic3Data = filler.FillStatistic3(excavations);
            IList<Statistic4ViewModel> statistic4Data = filler.FillStatistic4(excavations);
            IList<Statistic5ViewModel> statistic5Data = filler.FillStatistic5(excavations);
            IList<Statistic6ViewModel> statistic6Data = filler.FillStatistic6(excavations);

            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;

                IWorkbook workbook = application.Workbooks.Create(7);

                WriteFirstWorkSheet(excavationData, workbook.Worksheets[0]);
                WriteSecondWorkSheet(excavationData, workbook.Worksheets[1]);
                WriteThirdWorkSheet(excavationData, workbook.Worksheets[2]);
                WriteFouthWorkSheet(excavationData, workbook.Worksheets[3]);
                WriteFifthWorkSheet(excavationData, workbook.Worksheets[4]);
                WriteSixthWorkSheet(excavationData, workbook.Worksheets[5]);

                // 7
                IWorksheet seventhWorksheet = workbook.Worksheets[6];
                seventhWorksheet.ImportArray(header.ToArray(), 1, 1, false);
                seventhWorksheet.ImportData(excavationData.Where(d => !string.IsNullOrWhiteSpace(d.CollectorsNumber)), 2, 1, false);

                using (Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    workbook.SaveAs(stream);
                }
            }
        }

        private void WriteSixthWorkSheet(IEnumerable<ExcavationViewModel> excavationData, IWorksheet worksheet)
        {
            IEnumerable<string> statisticHeader = HeadSetter.GetStatistic6Header();
            ExcavationViewModelFiller filler = new();
            IList<Statistic6ViewModel> statisticData = filler.FillStatistic6(excavations);

            worksheet.ImportArray(statisticHeader.ToArray(), 1, 1, false);
            worksheet.ImportData(statisticData, 2, 1, false);
            worksheet.InsertColumn(9);
            worksheet.InsertColumn(10);

            var analogiesSum = new string[worksheet.Rows.Length];
            var analogiesSum1 = new string[worksheet.Rows.Length];
            var formations = excavationData.Select(e => e.Formation).Distinct().ToArray();
            var excavationsAmounts = new object[worksheet.Rows.Length, formations.Length];

            Func<int, IEnumerable<ExcavationViewModel>> excavationSearch = (int index) => excavationData.Where(e =>
                e.Monument == statisticData[index - 1].Monument &&
                e.Sprinkling.Split('/').FirstOrDefault() == statisticData[index - 1].Sprinkling.Split('/').FirstOrDefault());

            Func<int, IEnumerable<ExcavationViewModel>> excavationSearch1 = (int index) => excavationData.Where(e =>
                e.Monument == statisticData[index - 1].Monument);

            for (int i = 1; i < worksheet.Rows.Length; i++)
            {
                CalculateAnalogiesSum(analogiesSum, statisticData[i - 1].Analogy, i, excavationSearch);
                CalculateAnalogiesSum(analogiesSum1, statisticData[i - 1].Analogy, i, excavationSearch1);

                for (int j = 10; j < 10 + formations.Length; j++)
                {
                    excavationsAmounts[i - 1, j - 10] = excavationData.Where
                        (e => e.Monument == statisticData[i - 1].Monument &&
                        e.Formation == formations[j - 10] &&
                        e.Sprinkling == statisticData[i - 1].Sprinkling &&
                        e.Safety != null && e.Safety.Contains(statisticData[i - 1].Safety) &&
                        e.Relief != null && e.Relief.Contains(statisticData[i - 1].Relief) &&
                        e.ReconstructionReliability != null && e.ReconstructionReliability.Contains(statisticData[i - 1].ReconstructionReliability) &&
                        e.Clay != null && e.Clay.Contains(statisticData[i - 1].Clay) &&
                        e.Admixture != null && e.Admixture.Contains(statisticData[i - 1].Admixture)).Sum(s =>
                        {
                            if (decimal.TryParse(s.Analogy, out decimal result))
                            {
                                return result;
                            }

                            return 0;
                        });
                }
            }

            excavationSearch = null;
            excavationSearch1 = null;

            worksheet.ImportArray(analogiesSum, 2, 9, true);
            worksheet.ImportArray(new string[] { "% от части" }, 1, 9, false);

            worksheet.ImportArray(analogiesSum1, 2, 10, true);
            worksheet.ImportArray(new string[] { "%" }, 1, 10, false);

            worksheet.ImportArray(formations, 1, 11, false);
            worksheet.ImportArray(excavationsAmounts, 2, 11);
        }

        private void WriteFifthWorkSheet(IEnumerable<ExcavationViewModel> excavationData, IWorksheet worksheet)
        {
            IEnumerable<string> statisticHeader = HeadSetter.GetStatistic5Header();
            ExcavationViewModelFiller filler = new();
            IList<Statistic5ViewModel> statisticData = filler.FillStatistic5(excavations);

            worksheet.ImportArray(statisticHeader.ToArray(), 1, 1, false);
            worksheet.ImportData(statisticData, 2, 1, false);
            worksheet.InsertColumn(5);

            var analogiesSum = new string[worksheet.Rows.Length];
            var formations = excavationData.Select(e => e.Formation).Distinct().ToArray();
            var excavationsAmounts = new object[worksheet.Rows.Length, formations.Length];

            Func<int, IEnumerable<ExcavationViewModel>> excavationSearch = (int index) => excavationData.Where(e =>
                e.Monument == statisticData[index - 1].Monument &&
                e.Sprinkling.Split('/', 1).FirstOrDefault() == statisticData[index - 1].Sprinkling.Split('/', 1).FirstOrDefault());

            for (int i = 1; i < worksheet.Rows.Length; i++)
            {
                CalculateAnalogiesSum(analogiesSum, statisticData[i - 1].Analogy, i, excavationSearch);

                for (int j = 5; j < 5 + formations.Length; j++)
                {
                    excavationsAmounts[i - 1, j - 5] = excavationData.Where
                        (e => e.Monument == statisticData[i - 1].Monument &&
                        e.Formation == formations[j - 5] &&
                        e.Sprinkling == statisticData[i - 1].Sprinkling &&
                        e.Dating == statisticData[i - 1].Dating).Sum(s =>
                        {
                            if (decimal.TryParse(s.Analogy, out decimal result))
                            {
                                return result;
                            }

                            return 0;
                        });
                }
            }

            excavationSearch = null;

            worksheet.ImportArray(analogiesSum, 2, 5, true);
            worksheet.ImportArray(new string[] { "% от части" }, 1, 5, false);

            worksheet.ImportArray(formations, 1, 6, false);
            worksheet.ImportArray(excavationsAmounts, 2, 6);
        }

        private void WriteFouthWorkSheet(IEnumerable<ExcavationViewModel> excavationData, IWorksheet worksheet)
        {
            IEnumerable<string> statisticHeader = HeadSetter.GetStatistic4Header();
            ExcavationViewModelFiller filler = new();
            IList<Statistic4ViewModel> statisticData = filler.FillStatistic4(excavations);

            worksheet.ImportArray(statisticHeader.ToArray(), 1, 1, false);
            worksheet.ImportData(statisticData, 2, 1, false);
            worksheet.InsertColumn(10);
            worksheet.InsertColumn(11);

            var analogiesSum = new string[worksheet.Rows.Length];
            var analogiesSum1 = new string[worksheet.Rows.Length];
            var descriptions = excavationData.Select(e => e.Description).Distinct().ToArray();
            var excavationsAmounts = new object[worksheet.Rows.Length, descriptions.Length];

            Func<int, IEnumerable<ExcavationViewModel>> excavationSearch = (int index) => excavationData.Where(e =>
                e.Formation == statisticData[index - 1].Formation && e.Monument == statisticData[index - 1].Monument &&
                e.Sprinkling.Split('/', 1).FirstOrDefault() == statisticData[index - 1].Sprinkling.Split('/', 1).FirstOrDefault());

            Func<int, IEnumerable<ExcavationViewModel>> excavationSearch1 = (int index) => excavationData.Where(e =>
                e.Formation == statisticData[index - 1].Formation && e.Monument == statisticData[index - 1].Monument);

            for (int i = 1; i < worksheet.Rows.Length; i++)
            {
                CalculateAnalogiesSum(analogiesSum, statisticData[i - 1].Analogy, i, excavationSearch);
                CalculateAnalogiesSum(analogiesSum1, statisticData[i - 1].Analogy, i, excavationSearch1);

                for (int j = 11; j < 11 + descriptions.Length; j++)
                {
                    excavationsAmounts[i - 1, j - 11] = excavationData.Where
                        (e => e.Monument == statisticData[i - 1].Monument &&
                        e.Formation == statisticData[i - 1].Formation &&
                        e.Description == descriptions[j - 11] &&
                        e.Sprinkling == statisticData[i - 1].Sprinkling &&
                        e.Safety != null && e.Safety.Contains(statisticData[i - 1].Safety) &&
                        e.Relief != null && e.Relief.Contains(statisticData[i - 1].Relief) &&
                        e.ReconstructionReliability != null && e.ReconstructionReliability.Contains(statisticData[i - 1].ReconstructionReliability) &&
                        e.Clay != null && e.Clay.Contains(statisticData[i - 1].Clay) &&
                        e.Admixture != null && e.Admixture.Contains(statisticData[i - 1].Admixture)).Sum(s =>
                        {
                            if (decimal.TryParse(s.Analogy, out decimal result))
                            {
                                return result;
                            }

                            return 0;
                        });
                }
            }

            excavationSearch = null;
            excavationSearch1 = null;

            worksheet.ImportArray(analogiesSum, 2, 10, true);
            worksheet.ImportArray(new string[] { "% от части" }, 1, 10, false);

            worksheet.ImportArray(analogiesSum1, 2, 11, true);
            worksheet.ImportArray(new string[] { "%" }, 1, 11, false);

            worksheet.ImportArray(descriptions, 1, 12, false);
            worksheet.ImportArray(excavationsAmounts, 2, 12);
        }

        private void WriteThirdWorkSheet(IEnumerable<ExcavationViewModel> excavationData, IWorksheet worksheet)
        {
            IEnumerable<string> statisticHeader = HeadSetter.GetStatistic3Header();
            ExcavationViewModelFiller filler = new();
            IList<Statistic3ViewModel> statisticData = filler.FillStatistic3(excavations);

            worksheet.ImportArray(statisticHeader.ToArray(), 1, 1, false);
            worksheet.ImportData(statisticData, 2, 1, false);
            worksheet.InsertColumn(6);

            var analogiesSum = new string[worksheet.Rows.Length];
            var descriptions = excavationData.Select(e => e.Description).Distinct().ToArray();
            var excavationsAmounts = new object[worksheet.Rows.Length, descriptions.Length];

            Func<int, IEnumerable<ExcavationViewModel>> excavationSearch = (int index) => excavationData.Where(e =>
                e.Formation == statisticData[index - 1].Formation && e.Monument == statisticData[index - 1].Monument &&
                e.Sprinkling.Split('/', 1).FirstOrDefault() == statisticData[index - 1].Sprinkling.Split('/', 1).FirstOrDefault());

            for (int i = 1; i < worksheet.Rows.Length; i++)
            {
                CalculateAnalogiesSum(analogiesSum, statisticData[i - 1].Analogy, i, excavationSearch);

                for (int j = 6; j < 6 + descriptions.Length; j++)
                {
                    excavationsAmounts[i - 1, j - 6] = excavationData.Where
                        (e => e.Monument == statisticData[i - 1].Monument &&
                        e.Formation == statisticData[i - 1].Formation &&
                        e.Description == descriptions[j - 6] &&
                        e.Sprinkling == statisticData[i - 1].Sprinkling &&
                        e.Dating == statisticData[i - 1].Dating).Sum(s =>
                        {
                            if (decimal.TryParse(s.Analogy, out decimal result))
                            {
                                return result;
                            }

                            return 0;
                        });
                }
            }
            excavationSearch = null;

            worksheet.ImportArray(analogiesSum, 2, 6, true);
            worksheet.ImportArray(new string[] { "% от части" }, 1, 6, false);

            worksheet.ImportArray(descriptions, 1, 7, false);
            worksheet.ImportArray(excavationsAmounts, 2, 7);
        }

        private void WriteSecondWorkSheet(IEnumerable<ExcavationViewModel> excavationData, IWorksheet worksheet)
        {
            IEnumerable<string> statisticHeader = HeadSetter.GetStatistic2Header();
            ExcavationViewModelFiller filler = new();
            IList<Statistic2ViewModel> statisticData = filler.FillStatistic2(excavations);

            worksheet.ImportArray(statisticHeader.ToArray(), 1, 1, false);
            worksheet.ImportData(statisticData, 2, 1, false);
            worksheet.InsertColumn(11);
            worksheet.InsertColumn(12);

            var analogiesSum = new string[worksheet.Rows.Length];
            var analogiesSum1 = new string[worksheet.Rows.Length];
            var squares = excavationData.Select(e => e.Square.HasValue ? e.Square.Value.ToString() : string.Empty).Distinct().ToArray();
            var excavationsAmounts = new object[worksheet.Rows.Length, squares.Length];

            Func<int, IEnumerable<ExcavationViewModel>> excavationSearch = (int index) => excavationData.Where(e =>
                e.Formation == statisticData[index - 1].Formation && e.Monument == statisticData[index - 1].Monument &&
                e.Sprinkling.Split('/', 1).FirstOrDefault() == statisticData[index - 1].Sprinkling.Split('/', 1).FirstOrDefault());

            Func<int, IEnumerable<ExcavationViewModel>> excavationSearch1 = (int index) => excavationData.Where(e =>
                e.Formation == statisticData[index - 1].Formation && e.Monument == statisticData[index - 1].Monument &&
                e.Description == statisticData[index - 1].Description);

            for (int i = 1; i < worksheet.Rows.Length; i++)
            {
                CalculateAnalogiesSum(analogiesSum, statisticData[i - 1].Analogy, i, excavationSearch);
                CalculateAnalogiesSum(analogiesSum1, statisticData[i - 1].Analogy, i, excavationSearch1);

                for (int j = 12; j < 12 + squares.Length; j++)
                {
                    excavationsAmounts[i - 1, j - 12] = excavationData.Where
                        (e => e.Monument == statisticData[i - 1].Monument &&
                        e.Formation == statisticData[i - 1].Formation &&
                        e.Description == statisticData[i - 1].Description &&
                        (!e.Square.HasValue && string.IsNullOrEmpty(squares[j - 12]) ||
                            e.Square.HasValue && e.Square.Value.ToString() == squares[j - 12]) &&
                        e.Sprinkling == statisticData[i - 1].Sprinkling &&
                        e.Safety != null && e.Safety.Contains(statisticData[i - 1].Safety) &&
                        e.Relief != null && e.Relief.Contains(statisticData[i - 1].Relief) &&
                        e.ReconstructionReliability != null && e.ReconstructionReliability.Contains(statisticData[i - 1].ReconstructionReliability) &&
                        e.Clay != null && e.Clay.Contains(statisticData[i - 1].Clay) &&
                        e.Admixture != null && e.Admixture.Contains(statisticData[i - 1].Admixture)).Sum(s =>
                        {
                            if (decimal.TryParse(s.Analogy, out decimal result))
                            {
                                return result;
                            }

                            return 0;
                        });
                }
            }

            excavationSearch = null;
            excavationSearch1 = null;

            worksheet.ImportArray(analogiesSum, 2, 11, true);
            worksheet.ImportArray(new string[] { "% от части" }, 1, 11, false);

            worksheet.ImportArray(analogiesSum1, 2, 12, true);
            worksheet.ImportArray(new string[] { "%" }, 1, 12, false);

            worksheet.ImportArray(squares, 1, 13, false);
            worksheet.ImportArray(excavationsAmounts, 2, 13);
        }

        private void WriteFirstWorkSheet(IEnumerable<ExcavationViewModel> excavationData, IWorksheet worksheet)
        {
            IEnumerable<string> statisticHeader = HeadSetter.GetStatistic1Header();

            ExcavationViewModelFiller filler = new();
            IList<Statistic1ViewModel> statisticData = filler.FillStatistic1(excavations);

            worksheet.ImportArray(statisticHeader.ToArray(), 1, 1, false);
            worksheet.ImportData(statisticData, 2, 1, false);
            worksheet.InsertColumn(7);

            var analogiesSum = new string[worksheet.Rows.Length];
            var squares = excavationData.Select(e => e.Square.HasValue ? e.Square.Value.ToString() : string.Empty)
                .Distinct().ToArray();
            var excavationsAmounts = new object[worksheet.Rows.Length, squares.Length];

            Func<int, IEnumerable<ExcavationViewModel>> excavationSearch = (int index) => excavationData.Where(e =>
                e.Formation == statisticData[index - 1].Formation && e.Monument == statisticData[index - 1].Monument &&
                e.Sprinkling.Split('/', 1).FirstOrDefault() == statisticData[index - 1].Sprinkling.Split('/', 1).FirstOrDefault());

            for (int i = 1; i < worksheet.Rows.Length; i++)
            {
                CalculateAnalogiesSum(analogiesSum, statisticData[i - 1].Analogy, i, excavationSearch);

                for (int j = 7; j < 7 + squares.Length; j++)
                {
                    excavationsAmounts[i - 1, j - 7] = excavationData.Where
                        (e => e.Monument == statisticData[i - 1].Monument &&
                        e.Formation == statisticData[i - 1].Formation &&
                        e.Description == statisticData[i - 1].Description &&
                        (!e.Square.HasValue && string.IsNullOrEmpty(squares[j - 7]) ||
                            e.Square.HasValue && e.Square.Value.ToString() == squares[j - 7]) &&
                        e.Sprinkling == statisticData[i - 1].Sprinkling &&
                        e.Dating == statisticData[i - 1].Dating).Sum(s =>
                        {
                            if (decimal.TryParse(s.Analogy, out decimal result))
                            {
                                return result;
                            }

                            return 0;
                        });
                }
            }

            excavationSearch = null;

            worksheet.ImportArray(analogiesSum, 2, 7, true);
            worksheet.ImportArray(new string[] { "% от части" }, 1, 7, false);

            worksheet.ImportArray(squares, 1, 8, false);
            worksheet.ImportArray(excavationsAmounts, 2, 8);
        }

        private static void CalculateAnalogiesSum(string[] analogiesSum, string analogy, int index,
            Func<int, IEnumerable<ExcavationViewModel>> excavationSearch)
        {
            decimal analogySum = excavationSearch(index).Sum(s =>
                            {
                                if (decimal.TryParse(s.Analogy, out decimal result))
                                {
                                    return result;
                                }

                                return 0;
                            });
            decimal currentAnalogy = string.IsNullOrWhiteSpace(analogy) ? 0m : decimal.Parse(analogy);
            analogiesSum[index - 1] = analogySum == 0 ? "0" : (currentAnalogy / analogySum * 100).ToString("0.####");
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
