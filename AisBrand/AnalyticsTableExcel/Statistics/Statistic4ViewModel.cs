﻿using System;

namespace AnalyticsTableExcel.Statistics
{
    public class Statistic4ViewModel : IEquatable<Statistic4ViewModel>
    {
        public string Monument { get; set; }

        public string Formation { get; set; }

        public string Sprinkling { get; set; }

        public string ReconstructionReliability { get; set; }

        public string Clay { get; set; }

        public string Admixture { get; set; }

        public string Safety { get; set; }

        public string Relief { get; set; }

        public string Analogy { get; set; }

        public override bool Equals(object obj)
        {
            Statistic4ViewModel statistic = obj as Statistic4ViewModel;

            return Equals(statistic);
        }

        public bool Equals(Statistic4ViewModel other)
        {
            if (object.ReferenceEquals(other, null))
                return false;

            return Monument == other.Monument && Formation == other.Formation &&
                Sprinkling == other.Sprinkling &&
                ReconstructionReliability == other.ReconstructionReliability
                && Clay == other.Clay && Admixture == other.Admixture && Safety == other.Safety
                && Relief == other.Relief;
        }

        public override int GetHashCode()
        {
            int monumentHash = Monument.GetHashCode();
            int formationHash = Formation.GetHashCode();
            int sprinklingHash = Sprinkling.GetHashCode();
            int reconstructionReliabilityHash = ReconstructionReliability.GetHashCode();
            int clayHash = Clay.GetHashCode();
            int admixtureHash = Admixture.GetHashCode();
            int safetyHash = Safety.GetHashCode();
            int reliefHash = Relief.GetHashCode();

            return monumentHash ^ formationHash ^ sprinklingHash ^
                reconstructionReliabilityHash ^ clayHash ^ admixtureHash ^ safetyHash ^ reliefHash;
        }

        public static bool operator ==(Statistic4ViewModel a, Statistic4ViewModel b)
        {
            if (object.ReferenceEquals(a, b))
                return true;

            if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Statistic4ViewModel a, Statistic4ViewModel b)
        {
            return !(a == b);
        }
    }
}
