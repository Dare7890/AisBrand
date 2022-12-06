using System;

namespace AnalyticsTableExcel
{
    public class StatisticViewModel : IEquatable<StatisticViewModel>
    {
        public string Type { get; set; }

        public string Variant { get; set; }

        public string Dating { get; set; }

        public override bool Equals(object obj)
        {
            StatisticViewModel statistic = obj as StatisticViewModel;

            return Equals(statistic);
        }

        public bool Equals(StatisticViewModel other)
        {
            if (object.ReferenceEquals(other, null))
                return false;

            return Type == other.Type && Variant == other.Variant && Dating == other.Dating;
        }

        public override int GetHashCode()
        {
            int typeHash = Type.GetHashCode();
            int variantHash = Variant.GetHashCode();
            int datingHash = Dating.GetHashCode();

            return typeHash ^ variantHash ^ datingHash;
        }

        public static bool operator ==(StatisticViewModel a, StatisticViewModel b)
        {
            if (object.ReferenceEquals(a, b))
                return true;

            if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(StatisticViewModel a, StatisticViewModel b)
        {
            return !(a == b);
        }
    }
}
