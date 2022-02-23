using BrandDataProcessing.Models;

namespace AddBrandDataUI.ViewModels
{
    public class Find
    {
        public string Formation { get; set; }

        public int? Square { get; set; }

        public int? Depth { get; set; }

        public string FieldNumber { get; set; }

        public string CollectorsNumber { get; set; }

        public DatingBound Dating { get; set; }

        public string Description { get; set; }

        public string Analogy { get; set; }

        public string Note { get; set; }

        public byte[] Image { get; set; }

        public byte[] Photo { get; set; }

        public Brand Brand { get; set; }

        public AdditionalBrand AdditionalBrand { get; set; }

        public Find(string fieldNumber, string formation = null, int? square = null, int? depth = null, string collectorsNumber = null, DatingBound dating = null, string description = null,
            string analogy = null, string note = null, byte[] image = null, byte[] photo = null, Brand brand = null, AdditionalBrand additionalBrand = null)
        {
            FieldNumber = fieldNumber;
            Formation = formation;
            Square = square;
            Depth = depth;
            CollectorsNumber = collectorsNumber;
            Dating = new DatingBound(dating);
            Description = description;
            Analogy = analogy;
            Note = note;
            Image = image;
            Photo = photo;
            Brand = brand;
            AdditionalBrand = additionalBrand;
        }
    }
}
