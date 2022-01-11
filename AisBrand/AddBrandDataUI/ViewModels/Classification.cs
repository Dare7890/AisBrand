namespace AddBrandDataUI.ViewModels
{
    public class Classification
    {
        public string Type { get; }

        public string Variant { get; }

        public Classification(string type, string variant)
        {
            Type = type;
            Variant = variant;
        }
    }
}
