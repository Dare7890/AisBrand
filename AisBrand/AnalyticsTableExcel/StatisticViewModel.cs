using System;

namespace AnalyticsTableExcel
{
    public class StatisticViewModel : IEquatable<StatisticViewModel>
    {
        public string Sprinkling { get; set; }

        public string Monument { get; set; }

        public string Name { get; set; }

        public string Formation { get; set; }

        public int? Square { get; set; }

        public string Dating { get; set; }

        public string Analogy { get; set; }

        public override bool Equals(object obj)
        {
            StatisticViewModel statistic = obj as StatisticViewModel;

            return Equals(statistic);
        }

        public bool Equals(StatisticViewModel other)
        {
            if (object.ReferenceEquals(other, null))
                return false;

            return Monument == other.Monument && Name == other.Name && Formation == other.Formation &&
                Square == other.Square && Sprinkling == other.Sprinkling &&
                Dating == other.Dating;
        }

        public override int GetHashCode()
        {
            int monumentHash = Monument.GetHashCode();
            int nameHash = Name.GetHashCode();
            int formationHash = Formation.GetHashCode();
            int squareHash = Square.GetHashCode();
            int sprinklingHash = Sprinkling.GetHashCode();
            int datingHash = Dating.GetHashCode();

            return monumentHash ^ nameHash ^ formationHash ^ squareHash ^ sprinklingHash ^ datingHash;
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
