using System;

namespace BrandDataProcessing
{
    public class DatingBound : IEquatable<DatingBound>
    {
        public string BoundData { get; private set; }

        public int DatingLowerBound { get; set; }
        public int DatingUpperBound { get; set; }

        public DatingBound() { }

        public DatingBound(string boundData)
        {
            BoundData = boundData;
        }

        public override bool Equals(object obj)
        {
            DatingBound datingBound = obj as DatingBound;

            return Equals(datingBound);
        }

        public bool Equals(DatingBound other)
        {
            if (object.ReferenceEquals(other, null))
                return false;

            return BoundData == other.BoundData && DatingLowerBound == other.DatingLowerBound && DatingUpperBound == other.DatingUpperBound;
        }

        public static bool operator ==(DatingBound a, DatingBound b)
        {
            if (object.ReferenceEquals(a, b))
                return true;

            if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(DatingBound a, DatingBound b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            int hash = 0;
            hash = (hash << 4) ^ (hash >> 28) ^ DatingLowerBound;
            hash = (hash << 4) ^ (hash >> 28) ^ DatingUpperBound;

            return hash;
        }

        public override string ToString()
        {
            return string.Format("Data is: {0}. LowerBound is {1}. UpperBound is {2}", BoundData, DatingLowerBound, DatingUpperBound);
        }
    }
}
