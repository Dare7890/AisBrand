namespace AddBrandDataUI.ViewModels
{
    public class Classification
    {
        public string Type { get; }

        public string Variant { get; }

        public string Description { get; }

        public byte[] Image { get; }

        public Classification(string type, string variant, string description = null, byte[] image = null)
        {
            Type = type;
            Variant = variant;
            Description = description;
            Image = image;
        }
    }
}
