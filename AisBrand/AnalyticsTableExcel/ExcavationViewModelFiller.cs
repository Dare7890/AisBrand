using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<StatisticViewModel> FillStatistic(IList<Excavation> excavations)
        {
            if (excavations.Count == 0)
                return Enumerable.Empty<StatisticViewModel>();

            List<StatisticViewModel> statisticViewModels = new();
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
                StatisticViewModel statisticViewModel = new();
                statisticViewModel.Monument = u.First.First.Monument;
                statisticViewModel.Dating = u.Second.DatingBound?.BoundData;
                statisticViewModel.Sprinkling = u.Second.Brand?.Sprinkling;
                statisticViewModel.Formation = u.Second.Formation;
                statisticViewModel.Description = u.Second.Description;
                statisticViewModel.Analogy = u.Second.Analogy;

                statisticViewModels.Add(statisticViewModel);
            }

            return statisticViewModels.GroupBy(c => new { c.Monument, c.Dating, c.Sprinkling, c.Formation, c.Description, c.Analogy }).Select(c => new StatisticViewModel() {
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
    }
}
