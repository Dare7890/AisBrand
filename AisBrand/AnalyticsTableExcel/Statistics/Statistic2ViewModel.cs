using System;

namespace AnalyticsTableExcel.Statistics
{
    public class Statistic2ViewModel : IEquatable<Statistic2ViewModel>
    {
        public string Monument { get; set; }

        public string Formation { get; set; }

        public string Description { get; set; }

        public string Square { get; set; }

        public string Sprinkling { get; set; }

        public string ReconstructionReliability { get; set; }

        public string Clay { get; set; }

        public string Admixture { get; set; }

        public string Safety { get; set; }

        public string Relief { get; set; }

        public string Dating { get; set; }

        public string Analogy { get; set; }

        public override bool Equals(object obj)
        {
            Statistic2ViewModel statistic = obj as Statistic2ViewModel;

            return Equals(statistic);
        }

        public bool Equals(Statistic2ViewModel other)
        {
            if (object.ReferenceEquals(other, null))
                return false;

            return Monument == other.Monument && Formation == other.Formation &&
                Description == other.Description && Sprinkling == other.Sprinkling &&
                Dating == other.Dating && Square == other.Square && ReconstructionReliability == other.ReconstructionReliability
                && Clay == other.Clay && Admixture == other.Admixture && Safety == other.Safety
                && Relief == other.Relief;
        }

        public override int GetHashCode()
        {
            int monumentHash = Monument.GetHashCode();
            int formationHash = Formation.GetHashCode();
            int descriptionHash = Description.GetHashCode();
            int sprinklingHash = Sprinkling.GetHashCode();
            int datingHash = Dating.GetHashCode();
            int squareHash = Square == null ? string.Empty.GetHashCode() : Square.GetHashCode();
            int reconstructionReliabilityHash = ReconstructionReliability.GetHashCode();
            int clayHash = Clay.GetHashCode();
            int admixtureHash = Admixture.GetHashCode();
            int safetyHash = Safety.GetHashCode();
            int reliefHash = Relief.GetHashCode();

            return monumentHash ^ formationHash ^ descriptionHash ^ sprinklingHash ^ datingHash
                ^ squareHash ^ reconstructionReliabilityHash ^ clayHash ^ admixtureHash
                ^ safetyHash ^ reliefHash;
        }

        public static bool operator ==(Statistic2ViewModel a, Statistic2ViewModel b)
        {
            if (object.ReferenceEquals(a, b))
                return true;

            if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Statistic2ViewModel a, Statistic2ViewModel b)
        {
            return !(a == b);
        }
    }
}
