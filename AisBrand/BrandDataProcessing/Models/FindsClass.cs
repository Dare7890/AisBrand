using System.Collections.Generic;

namespace BrandDataProcessing.Models
{
    [TranslatedName("Категории предметов")]
    public class FindsClass : IIdentifier
    {
        public int ID { get; set; }

        public string Class { get; set; }

        public List<Classification> Classifications { get; set; }
    }
}
