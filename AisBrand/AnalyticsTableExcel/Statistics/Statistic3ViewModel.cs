using System;

namespace AnalyticsTableExcel.Statistics
{
    public class Statistic3ViewModel : IEquatable<Statistic3ViewModel>
    {
        public string Monument { get; set; }

        public string Formation { get; set; }

        public string Description { get; set; }

        public string Sprinkling { get; set; }

        public string Dating { get; set; }

        public string Analogy { get; set; }

        public override bool Equals(object obj)
        {
            Statistic3ViewModel statistic = obj as Statistic3ViewModel;

            return Equals(statistic);
        }

        public bool Equals(Statistic3ViewModel other)
        {
            if (object.ReferenceEquals(other, null))
                return false;

            return Monument == other.Monument && Formation == other.Formation &&
                Description == other.Description && Sprinkling == other.Sprinkling &&
                Dating == other.Dating;
        }

        public override int GetHashCode()
        {
            int monumentHash = Monument.GetHashCode();
            int formationHash = Formation.GetHashCode();
            int descriptionHash = Description.GetHashCode();
            int sprinklingHash = Sprinkling.GetHashCode();
            int datingHash = Dating.GetHashCode();

            return monumentHash ^ formationHash ^ descriptionHash ^ sprinklingHash ^ datingHash;
        }

        public static bool operator ==(Statistic3ViewModel a, Statistic3ViewModel b)
        {
            if (object.ReferenceEquals(a, b))
                return true;

            if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Statistic3ViewModel a, Statistic3ViewModel b)
        {
            return !(a == b);
        }
    }
}
