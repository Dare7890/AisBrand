using System;

namespace AnalyticsTableExcel
{
    public class HardStatisticViewModel : IEquatable<HardStatisticViewModel>
    {
        public string Sprinkling { get; set; }

        public string ReconstructionReliability { get; set; }

        public string Clay { get; set; }

        public string Admixture { get; set; }

        public string Safety { get; set; }

        public string Relief { get; set; }

        public int SequencesNumber { get; set; }

        public override bool Equals(object obj)
        {
            HardStatisticViewModel statistic = obj as HardStatisticViewModel;

            return Equals(statistic);
        }

        public bool Equals(HardStatisticViewModel other)
        {
            if (object.ReferenceEquals(other, null))
                return false;

            return Sprinkling == other.Sprinkling && ReconstructionReliability == other.ReconstructionReliability
                && Clay == other.Clay && Admixture == other.Admixture && Safety == other.Safety && Relief == other.Relief;
        }

        public override int GetHashCode()
        {
            int sprinklingHash = Sprinkling.GetHashCode();
            int reliabilityHash = ReconstructionReliability.GetHashCode();
            int clayHash = Clay.GetHashCode();
            int admixtureHash = Admixture.GetHashCode();
            int safetyHash = Safety.GetHashCode();
            int reliefHash = Relief.GetHashCode();

            return sprinklingHash ^ reliabilityHash ^ clayHash ^ admixtureHash ^ safetyHash ^ reliefHash;
        }

        public static bool operator ==(HardStatisticViewModel a, HardStatisticViewModel b)
        {
            if (object.ReferenceEquals(a, b))
                return true;

            if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(HardStatisticViewModel a, HardStatisticViewModel b)
        {
            return !(a == b);
        }
    }
}
