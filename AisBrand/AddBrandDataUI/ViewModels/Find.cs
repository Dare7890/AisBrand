namespace AddBrandDataUI.ViewModels
{
    public class Find
    {
        public string Formation { get; set; }

        public int? Square { get; set; }

        public int? Depth { get; set; }

        public string FieldNumber { get; set; }

        public string CollectorsNumber { get; set; }

        public int? DatingLowerBound { get; set; }

        public int? DatingUpperBound { get; set; }

        public string Description { get; set; }

        public string Analogy { get; set; }

        public string Note { get; set; }

        public byte[] Image { get; set; }

        public byte[] Photo { get; set; }

        public Find(string fieldNumber, string formation = null, int? square = null, int? depth = null, string collectorsNumber = null, int? datingLowerBound = null,
            int? datingUpperBound = null, string description = null, string analogy = null, string note = null, byte[] image = null, byte[] photo = null)
        {
            FieldNumber = fieldNumber;
            Formation = formation;
            Square = square;
            Depth = depth;
            CollectorsNumber = collectorsNumber;
            DatingLowerBound = datingLowerBound;
            DatingUpperBound = datingUpperBound;
            Description = description;
            Analogy = analogy;
            Note = note;
            Image = image;
            Photo = photo;
    }
    }
}
