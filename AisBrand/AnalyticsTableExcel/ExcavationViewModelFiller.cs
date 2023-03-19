using System.Collections.Generic;
using System.Linq;
using AnalyticsTableExcel.Statistics;
using BrandDataProcessing.Models;

namespace AnalyticsTableExcel
{
    public class ExcavationViewModelFiller
    {
        public IEnumerable<ExcavationViewModel> Fill(IList<Excavation> excavations)
        {
            if (excavations.Count == 0)
                return Enumerable.Empty<ExcavationViewModel>();

            List<ExcavationViewModel> excavationViewModels = new();
            var exv = Enumerable.Repeat(excavations.Select(e => new { e.Monument, e.Name}), excavations.SelectMany(f => f.FindsClasses)
                                                                                                    .SelectMany(c => c.Classifications)
                                                                                                    .SelectMany(f => f.Finds)
                                                                                                    .Count())
                                .SelectMany(e => e);

            var classifications = excavations.SelectMany(e => e.FindsClasses)
                                            .SelectMany(c => c.Classifications);

            List<IEnumerable<Classification>> cls = new();
            foreach (var classification in classifications)
                cls.Add(Enumerable.Repeat(classification, classification.Finds.Count));

            var filteredClassifications = cls.SelectMany(a => a);

            var finds = excavations.SelectMany(e => e.FindsClasses).SelectMany(c => c.Classifications).SelectMany(f => f.Finds);
            var union = exv.Zip(filteredClassifications).Zip(finds);
            foreach (var u in union)
            {
                ExcavationViewModel excavationViewModel = new();
                excavationViewModel.Monument = u.First.First.Monument;
                excavationViewModel.Name = u.First.First.Name;
                excavationViewModel.FieldNumber = u.Second.FieldNumber;
                excavationViewModel.CollectorsNumber = u.Second.CollectorsNumber;
                excavationViewModel.Clay = u.Second.Brand?.Clay;
                excavationViewModel.Admixture = u.Second.Brand?.Admixture;
                excavationViewModel.Safety = u.Second.Brand?.Safety;
                excavationViewModel.Relief = u.Second.Brand?.Relief;
                excavationViewModel.Dating = u.Second.DatingBound?.BoundData;
                excavationViewModel.Sprinkling = u.Second.Brand?.Sprinkling;
                excavationViewModel.ReconstructionReliability = u.Second.Brand?.ReconstructionReliability;
                excavationViewModel.Formation = u.Second.Formation;
                excavationViewModel.Depth = u.Second.Depth;
                excavationViewModel.Description = u.Second.Description;
                excavationViewModel.Note = u.Second.Note;
                excavationViewModel.Square = u.Second.Square;
                excavationViewModel.Analogy = u.Second.Analogy;

                excavationViewModels.Add(excavationViewModel);
            }

            return excavationViewModels;
        }

        public IEnumerable<Statistic1ViewModel> FillStatistic1(IList<Excavation> excavations)
        {
            if (excavations.Count == 0)
                return Enumerable.Empty<Statistic1ViewModel>();

            List<Statistic1ViewModel> statisticViewModels = new();
            var exv = Enumerable.Repeat(excavations.Select(e => new { e.Monument, e.Name }), excavations.SelectMany(f => f.FindsClasses)
                                                                                                    .SelectMany(c => c.Classifications)
                                                                                                    .SelectMany(f => f.Finds)
                                                                                                    .Count())
                                .SelectMany(e => e);

            var classifications = excavations.SelectMany(e => e.FindsClasses)
                                            .SelectMany(c => c.Classifications);

            List<IEnumerable<Classification>> cls = new();
            foreach (var classification in classifications)
                cls.Add(Enumerable.Repeat(classification, classification.Finds.Count));

            var filteredClassifications = cls.SelectMany(a => a);

            var finds = excavations.SelectMany(e => e.FindsClasses).SelectMany(c => c.Classifications).SelectMany(f => f.Finds);
            var union = exv.Zip(filteredClassifications).Zip(finds);
            foreach (var u in union)
            {
                Statistic1ViewModel statisticViewModel = new();
                statisticViewModel.Monument = u.First.First.Monument;
                statisticViewModel.Dating = u.Second.DatingBound?.BoundData;
                statisticViewModel.Sprinkling = u.Second.Brand?.Sprinkling;
                statisticViewModel.Formation = u.Second.Formation;
                statisticViewModel.Description = u.Second.Description;
                statisticViewModel.Analogy = u.Second.Analogy;

                statisticViewModels.Add(statisticViewModel);
            }

            return statisticViewModels.Where(s => s.Sprinkling.Split('/').FirstOrDefault() == "Горшок Венчик")
                .GroupBy(c => new { c.Monument, c.Dating, c.Sprinkling, c.Formation, c.Description })
                .Select(c => new Statistic1ViewModel() {
                Analogy = c.Select(a => {
                    if (decimal.TryParse(a.Analogy, out decimal result))
                    {
                        return result;
                    }
                    return 0;
                    }).Sum().ToString(),
                Monument = c.First()?.Monument,
                Dating = c.First()?.Dating,
                Sprinkling = c.First()?.Sprinkling,
                Formation = c.First()?.Formation,
                Description = c.First()?.Description
                }).Distinct();
        }

        public IEnumerable<Statistic2ViewModel> FillStatistic2(IList<Excavation> excavations)
        {
            if (excavations.Count == 0)
                return Enumerable.Empty<Statistic2ViewModel>();

            List<Statistic2ViewModel> statisticViewModels = new();
            var exv = Enumerable.Repeat(excavations.Select(e => new { e.Monument, e.Name }), excavations.SelectMany(f => f.FindsClasses)
                                                                                                    .SelectMany(c => c.Classifications)
                                                                                                    .SelectMany(f => f.Finds)
                                                                                                    .Count())
                                .SelectMany(e => e);

            var classifications = excavations.SelectMany(e => e.FindsClasses)
                                            .SelectMany(c => c.Classifications);

            List<IEnumerable<Classification>> cls = new();
            foreach (var classification in classifications)
                cls.Add(Enumerable.Repeat(classification, classification.Finds.Count));

            var filteredClassifications = cls.SelectMany(a => a);

            var finds = excavations.SelectMany(e => e.FindsClasses).SelectMany(c => c.Classifications).SelectMany(f => f.Finds);
            var union = exv.Zip(filteredClassifications).Zip(finds);
            foreach (var u in union)
            {
                Statistic2ViewModel statisticViewModel = new();
                statisticViewModel.Monument = u.First.First.Monument;
                statisticViewModel.Sprinkling = u.Second.Brand?.Sprinkling;
                statisticViewModel.Formation = u.Second.Formation;
                statisticViewModel.Description = u.Second.Description;
                statisticViewModel.Analogy = u.Second.Analogy;
                statisticViewModel.Admixture = u.Second.Brand.Admixture;
                statisticViewModel.ReconstructionReliability = u.Second.Brand.ReconstructionReliability;
                statisticViewModel.Clay = u.Second.Brand.Clay;
                statisticViewModel.Safety = u.Second.Brand.Safety;
                statisticViewModel.Relief = u.Second.Brand.Relief;

                statisticViewModels.Add(statisticViewModel);
            }

            return statisticViewModels.GroupBy(c => new {
                c.Monument,
                c.Sprinkling,
                c.Formation,
                c.Description,
                c.Admixture,
                c.ReconstructionReliability,
                c.Clay,
                c.Safety,
                c.Relief
            }).Select(c => new Statistic2ViewModel()
            {
                Analogy = c.Select(a => {
                    if (decimal.TryParse(a.Analogy, out decimal result))
                    {
                        return result;
                    }
                    return 0;
                }).Sum().ToString(),
                Monument = c.First()?.Monument,
                Sprinkling = c.First()?.Sprinkling,
                Formation = c.First()?.Formation,
                Description = c.First()?.Description,
                Admixture = c.First()?.Admixture,
                ReconstructionReliability = c.First()?.ReconstructionReliability,
                Clay = c.First()?.Clay,
                Safety = c.First()?.Safety,
                Relief = c.First()?.Relief
            }).Distinct();
        }

        public IEnumerable<Statistic3ViewModel> FillStatistic3(IList<Excavation> excavations)
        {
            if (excavations.Count == 0)
                return Enumerable.Empty<Statistic3ViewModel>();

            List<Statistic3ViewModel> statisticViewModels = new();
            var exv = Enumerable.Repeat(excavations.Select(e => new { e.Monument, e.Name }), excavations.SelectMany(f => f.FindsClasses)
                                                                                                    .SelectMany(c => c.Classifications)
                                                                                                    .SelectMany(f => f.Finds)
                                                                                                    .Count())
                                .SelectMany(e => e);

            var classifications = excavations.SelectMany(e => e.FindsClasses)
                                            .SelectMany(c => c.Classifications);

            List<IEnumerable<Classification>> cls = new();
            foreach (var classification in classifications)
                cls.Add(Enumerable.Repeat(classification, classification.Finds.Count));

            var filteredClassifications = cls.SelectMany(a => a);

            var finds = excavations.SelectMany(e => e.FindsClasses).SelectMany(c => c.Classifications).SelectMany(f => f.Finds);
            var union = exv.Zip(filteredClassifications).Zip(finds);
            foreach (var u in union)
            {
                Statistic3ViewModel statisticViewModel = new();
                statisticViewModel.Monument = u.First.First.Monument;
                statisticViewModel.Dating = u.Second.DatingBound?.BoundData;
                statisticViewModel.Sprinkling = u.Second.Brand?.Sprinkling;
                statisticViewModel.Formation = u.Second.Formation;
                statisticViewModel.Analogy = u.Second.Analogy;

                statisticViewModels.Add(statisticViewModel);
            }

            return statisticViewModels.Where(s => s.Sprinkling.Split('/').FirstOrDefault() == "Горшок Венчик")
                .GroupBy(c => new {
                c.Monument,
                c.Dating,
                c.Sprinkling,
                c.Formation
            }).Select(c => new Statistic3ViewModel()
            {
                Analogy = c.Select(a => {
                    if (decimal.TryParse(a.Analogy, out decimal result))
                    {
                        return result;
                    }
                    return 0;
                }).Sum().ToString(),
                Monument = c.First()?.Monument,
                Dating = c.First()?.Dating,
                Sprinkling = c.First()?.Sprinkling,
                Formation = c.First()?.Formation
            }).Distinct();
        }

        public IEnumerable<Statistic4ViewModel> FillStatistic4(IList<Excavation> excavations)
        {
            if (excavations.Count == 0)
                return Enumerable.Empty<Statistic4ViewModel>();

            List<Statistic4ViewModel> statisticViewModels = new();
            var exv = Enumerable.Repeat(excavations.Select(e => new { e.Monument, e.Name }), excavations.SelectMany(f => f.FindsClasses)
                                                                                                    .SelectMany(c => c.Classifications)
                                                                                                    .SelectMany(f => f.Finds)
                                                                                                    .Count())
                                .SelectMany(e => e);

            var classifications = excavations.SelectMany(e => e.FindsClasses)
                                            .SelectMany(c => c.Classifications);

            List<IEnumerable<Classification>> cls = new();
            foreach (var classification in classifications)
                cls.Add(Enumerable.Repeat(classification, classification.Finds.Count));

            var filteredClassifications = cls.SelectMany(a => a);

            var finds = excavations.SelectMany(e => e.FindsClasses).SelectMany(c => c.Classifications).SelectMany(f => f.Finds);
            var union = exv.Zip(filteredClassifications).Zip(finds);
            foreach (var u in union)
            {
                Statistic4ViewModel statisticViewModel = new();
                statisticViewModel.Monument = u.First.First.Monument;
                statisticViewModel.Sprinkling = u.Second.Brand?.Sprinkling;
                statisticViewModel.Formation = u.Second.Formation;
                statisticViewModel.Analogy = u.Second.Analogy;
                statisticViewModel.Admixture = u.Second.Brand.Admixture;
                statisticViewModel.ReconstructionReliability = u.Second.Brand.ReconstructionReliability;
                statisticViewModel.Clay = u.Second.Brand.Clay;
                statisticViewModel.Safety = u.Second.Brand.Safety;
                statisticViewModel.Relief = u.Second.Brand.Relief;

                statisticViewModels.Add(statisticViewModel);
            }

            return statisticViewModels.GroupBy(c => new {
                c.Monument,
                c.Sprinkling,
                c.Formation,
                c.Admixture,
                c.ReconstructionReliability,
                c.Clay,
                c.Safety,
                c.Relief
            }).Select(c => new Statistic4ViewModel()
            {
                Analogy = c.Select(a => {
                    if (decimal.TryParse(a.Analogy, out decimal result))
                    {
                        return result;
                    }
                    return 0;
                }).Sum().ToString(),
                Monument = c.First()?.Monument,
                Sprinkling = c.First()?.Sprinkling,
                Formation = c.First()?.Formation,
                Admixture = c.First()?.Admixture,
                ReconstructionReliability = c.First()?.ReconstructionReliability,
                Clay = c.First()?.Clay,
                Safety = c.First()?.Safety,
                Relief = c.First()?.Relief
            }).Distinct();
        }

        public IEnumerable<Statistic5ViewModel> FillStatistic5(IList<Excavation> excavations)
        {
            if (excavations.Count == 0)
                return Enumerable.Empty<Statistic5ViewModel>();

            List<Statistic5ViewModel> statisticViewModels = new();
            var exv = Enumerable.Repeat(excavations.Select(e => new { e.Monument, e.Name }), excavations.SelectMany(f => f.FindsClasses)
                                                                                                    .SelectMany(c => c.Classifications)
                                                                                                    .SelectMany(f => f.Finds)
                                                                                                    .Count())
                                .SelectMany(e => e);

            var classifications = excavations.SelectMany(e => e.FindsClasses)
                                            .SelectMany(c => c.Classifications);

            List<IEnumerable<Classification>> cls = new();
            foreach (var classification in classifications)
                cls.Add(Enumerable.Repeat(classification, classification.Finds.Count));

            var filteredClassifications = cls.SelectMany(a => a);

            var finds = excavations.SelectMany(e => e.FindsClasses).SelectMany(c => c.Classifications).SelectMany(f => f.Finds);
            var union = exv.Zip(filteredClassifications).Zip(finds);
            foreach (var u in union)
            {
                Statistic5ViewModel statisticViewModel = new();
                statisticViewModel.Monument = u.First.First.Monument;
                statisticViewModel.Dating = u.Second.DatingBound?.BoundData;
                statisticViewModel.Sprinkling = u.Second.Brand?.Sprinkling;
                statisticViewModel.Analogy = u.Second.Analogy;
                statisticViewModels.Add(statisticViewModel);
            }

            return statisticViewModels.Where(s => s.Sprinkling.Split('/').FirstOrDefault() == "Горшок Венчик")
                .GroupBy(c => new {
                c.Monument,
                c.Dating,
                c.Sprinkling
            }).Select(c => new Statistic5ViewModel()
            {
                Analogy = c.Select(a => {
                    if (decimal.TryParse(a.Analogy, out decimal result))
                    {
                        return result;
                    }
                    return 0;
                }).Sum().ToString(),
                Monument = c.First()?.Monument,
                Dating = c.First()?.Dating,
                Sprinkling = c.First()?.Sprinkling
            }).Distinct();
        }

        public IEnumerable<Statistic6ViewModel> FillStatistic6(IList<Excavation> excavations)
        {
            if (excavations.Count == 0)
                return Enumerable.Empty<Statistic6ViewModel>();

            List<Statistic6ViewModel> statisticViewModels = new();
            var exv = Enumerable.Repeat(excavations.Select(e => new { e.Monument, e.Name }), excavations.SelectMany(f => f.FindsClasses)
                                                                                                    .SelectMany(c => c.Classifications)
                                                                                                    .SelectMany(f => f.Finds)
                                                                                                    .Count())
                                .SelectMany(e => e);

            var classifications = excavations.SelectMany(e => e.FindsClasses)
                                            .SelectMany(c => c.Classifications);

            List<IEnumerable<Classification>> cls = new();
            foreach (var classification in classifications)
                cls.Add(Enumerable.Repeat(classification, classification.Finds.Count));

            var filteredClassifications = cls.SelectMany(a => a);

            var finds = excavations.SelectMany(e => e.FindsClasses).SelectMany(c => c.Classifications).SelectMany(f => f.Finds);
            var union = exv.Zip(filteredClassifications).Zip(finds);
            foreach (var u in union)
            {
                Statistic6ViewModel statisticViewModel = new();
                statisticViewModel.Monument = u.First.First.Monument;
                statisticViewModel.Sprinkling = u.Second.Brand?.Sprinkling;
                statisticViewModel.Analogy = u.Second.Analogy;
                statisticViewModel.Admixture = u.Second.Brand.Admixture;
                statisticViewModel.ReconstructionReliability = u.Second.Brand.ReconstructionReliability;
                statisticViewModel.Clay = u.Second.Brand.Clay;
                statisticViewModel.Safety = u.Second.Brand.Safety;
                statisticViewModel.Relief = u.Second.Brand.Relief;

                statisticViewModels.Add(statisticViewModel);
            }

            return statisticViewModels.GroupBy(c => new {
                c.Monument,
                c.Sprinkling,
                c.Admixture,
                c.ReconstructionReliability,
                c.Clay,
                c.Safety,
                c.Relief
            }).Select(c => new Statistic6ViewModel()
            {
                Analogy = c.Select(a => {
                    if (decimal.TryParse(a.Analogy, out decimal result))
                    {
                        return result;
                    }
                    return 0;
                }).Sum().ToString(),
                Monument = c.First()?.Monument,
                Sprinkling = c.First()?.Sprinkling,
                Admixture = c.First()?.Admixture,
                ReconstructionReliability = c.First()?.ReconstructionReliability,
                Clay = c.First()?.Clay,
                Safety = c.First()?.Safety,
                Relief = c.First()?.Relief
            }).Distinct();
        }
    }
}
