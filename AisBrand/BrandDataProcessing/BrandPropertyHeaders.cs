using System.Collections.Generic;

namespace BrandDataProcessing
{
    public class BrandPropertyHeaders
    {
        public IEnumerable<string> ClayHeaders { get; }

        public IEnumerable<string> AdmixtureHeaders { get; }

        public IEnumerable<string> SprinklingHeaders { get; }

        public IEnumerable<string> ReliabilityHeaders { get; }

        public BrandPropertyHeaders(
            IEnumerable<string> clayHeaders,
            IEnumerable<string> admixtureHeaders,
            IEnumerable<string> sprinklingHeaders,
            IEnumerable<string> reliabilityHeaders)
        {
            ClayHeaders = new List<string>(clayHeaders);
            AdmixtureHeaders = new List<string>(admixtureHeaders);
            SprinklingHeaders = new List<string>(sprinklingHeaders);
            ReliabilityHeaders = new List<string>(reliabilityHeaders);
        }
    }
}
