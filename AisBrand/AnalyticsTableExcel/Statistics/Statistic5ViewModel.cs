using System;

namespace AnalyticsTableExcel.Statistics
{
    public class Statistic5ViewModel : IEquatable<Statistic5ViewModel>
    {
        public string Monument { get; set; }

        public string Formation { get; set; }

        public string Sprinkling { get; set; }

        public string Dating { get; set; }

        public string Analogy { get; set; }

        public override bool Equals(object obj)
        {
            Statistic5ViewModel statistic = obj as Statistic5ViewModel;

            return Equals(statistic);
        }

        public bool Equals(Statistic5ViewModel other)
        {
            if (object.ReferenceEquals(other, null))
                return false;

            return Monument == other.Monument && Formation == other.Formation &&
                Sprinkling == other.Sprinkling && Dating == other.Dating;
        }

        public override int GetHashCode()
        {
            int monumentHash = Monument.GetHashCode();
            int formationHash = Formation.GetHashCode();
            int sprinklingHash = Sprinkling.GetHashCode();
            int datingHash = Dating.GetHashCode();

            return monumentHash ^ formationHash ^ sprinklingHash ^ datingHash;
        }

        public static bool operator ==(Statistic5ViewModel a, Statistic5ViewModel b)
        {
            if (object.ReferenceEquals(a, b))
                return true;

            if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Statistic5ViewModel a, Statistic5ViewModel b)
        {
            return !(a == b);
        }
    }
}
