using System.Collections.Generic;

namespace BrandDataProcessing
{
    public class BrandPropertyHeaders
    {
        public IEnumerable<string> ClayHeaders { get; }

        public IEnumerable<string> AdmixtureHeaders { get; }

        public IEnumerable<string> ReliabilityHeaders { get; }

        public IEnumerable<string> ReliefHeaders { get; }

        public IEnumerable<string> SafetyHeaders { get; }

        public BrandPropertyHeaders(
            IEnumerable<string> clayHeaders,
            IEnumerable<string> admixtureHeaders,
            IEnumerable<string> reliabilityHeaders,
            IEnumerable<string> reliefHeaders,
            IEnumerable<string> safetyHeaders)
        {
            ClayHeaders = new List<string>(clayHeaders);
            AdmixtureHeaders = new List<string>(admixtureHeaders);
            ReliabilityHeaders = new List<string>(reliabilityHeaders);
            ReliefHeaders = new List<string>(reliefHeaders);
            SafetyHeaders = new List<string>(safetyHeaders);
        }
    }
}
