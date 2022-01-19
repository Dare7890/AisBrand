namespace BrandDataProcessing.Models
{
    [TranslatedName("В разработке")]
    public class AditionalBrand : IIdentifier
    {
        public int ID { get; set; }

        public string Clay { get; set; }

        public string Admixture { get; set; }
    }
}
