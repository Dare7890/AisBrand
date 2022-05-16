using BrandDataProcessing.Models;
using System.Collections.Generic;
using System.Linq;

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
                excavationViewModel.Type = u.First.Second.Type;
                excavationViewModel.Variant = u.First.Second.Variant;
                excavationViewModel.FieldNumber = u.Second.FieldNumber;
                excavationViewModel.CollectorsNumber = u.Second.CollectorsNumber;
                excavationViewModel.Clay = u.Second.Brand?.Clay;
                excavationViewModel.Admixture = u.Second.Brand?.Admixture;
                excavationViewModel.Dating = u.Second.DatingBound?.BoundData;
                excavationViewModel.Sprinkling = u.Second.Brand?.Sprinkling;
                excavationViewModel.ReconstructionReliability = u.Second.Brand?.ReconstructionReliability;

                excavationViewModels.Add(excavationViewModel);
            }

            return excavationViewModels;
        }
    }
}
