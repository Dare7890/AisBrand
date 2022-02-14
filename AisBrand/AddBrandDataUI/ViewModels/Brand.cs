namespace AddBrandDataUI.ViewModels
{
    public class Brand
    {
        public string Clay { get; set; }

        public string Admixture { get; set; }

        public string Sprinkling { get; set; }

        public string Safety { get; set; }

        public string Relief { get; set; }

        public string ReconstructionReliability { get; set; }

        public Brand(string clay, string admixtute, string sprinkling, string safety, string relief, string reliability)
        {
            Clay = clay;
            Admixture = admixtute;
            Sprinkling = sprinkling;
            Safety = safety;
            Relief = relief;
            ReconstructionReliability = reliability;
        }
    }
}
