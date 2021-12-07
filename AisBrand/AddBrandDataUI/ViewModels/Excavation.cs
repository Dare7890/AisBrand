namespace AddBrandDataUI.ViewModels
{
    public class Excavation
    {
        public string Name { get; }

        public string Monument { get; }

        public Excavation(string name, string monument)
        {
            Name = name;
            Monument = monument;
        }
    }
}
