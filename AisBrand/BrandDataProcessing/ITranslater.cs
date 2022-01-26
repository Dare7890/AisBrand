using System.Collections.Generic;

namespace BrandDataProcessing
{
    public interface ITranslater
    {
        IEnumerable<string> Translate(IEnumerable<string> names);
        string Translate(string name);
    }
}