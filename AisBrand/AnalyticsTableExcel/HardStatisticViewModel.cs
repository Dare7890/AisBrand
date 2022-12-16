using System;

namespace AnalyticsTableExcel
{
    public class HardStatisticViewModel : IEquatable<HardStatisticViewModel>
    {
        public string Type { get; set; }

        public string Variant { get; set; }

        public string Dating { get; set; }

        public string ReconstructionReliability { get; set; }

        public string Clay { get; set; }

        public string Admixture { get; set; }

        public string Sprinkling { get; set; }

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

            return Type == other.Type && Variant == other.Variant && Dating == other.Dating &&
                ReconstructionReliability == other.ReconstructionReliability && Clay == other.Clay && Admixture == other.Admixture && Sprinkling == other.Sprinkling;
        }

        public override int GetHashCode()
        {
            int typeHash = Type.GetHashCode();
            int variantHash = Variant.GetHashCode();
            int datingHash = Dating.GetHashCode();
            int reliabilityHash = ReconstructionReliability.GetHashCode();
            int clayHash = Clay.GetHashCode();
            int admixtureHash = Admixture.GetHashCode();
            int sprinklingHash = Sprinkling.GetHashCode();

            return typeHash ^ variantHash ^ datingHash ^ reliabilityHash ^ clayHash ^ admixtureHash ^ sprinklingHash;
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
