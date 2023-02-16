using System;

namespace AnalyticsTableExcel
{
    public class Statistic1ViewModel : IEquatable<Statistic1ViewModel>
    {
        public string Monument { get; set; }

        public string Formation { get; set; }

        public string Description { get; set; }

        public string Square { get; set; }

        public string Sprinkling { get; set; }

        public string Dating { get; set; }

        public string Analogy { get; set; }

        public override bool Equals(object obj)
        {
            Statistic1ViewModel statistic = obj as Statistic1ViewModel;

            return Equals(statistic);
        }

        public bool Equals(Statistic1ViewModel other)
        {
            if (object.ReferenceEquals(other, null))
                return false;

            return Monument == other.Monument && Formation == other.Formation &&
                Description == other.Description && Sprinkling == other.Sprinkling &&
                Dating == other.Dating && Square == other.Square;
        }

        public override int GetHashCode()
        {
            int monumentHash = Monument.GetHashCode();
            int formationHash = Formation.GetHashCode();
            int descriptionHash = Description.GetHashCode();
            int sprinklingHash = Sprinkling.GetHashCode();
            int datingHash = Dating.GetHashCode();
            int squareHash = Square == null ? string.Empty.GetHashCode() : Square.GetHashCode();

            return monumentHash ^ formationHash ^ descriptionHash ^ sprinklingHash ^ datingHash
                ^ squareHash;
        }

        public static bool operator ==(Statistic1ViewModel a, Statistic1ViewModel b)
        {
            if (object.ReferenceEquals(a, b))
                return true;

            if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Statistic1ViewModel a, Statistic1ViewModel b)
        {
            return !(a == b);
        }
    }
}
