using AddBrandDataUI;
using AddBrandDataUI.ViewModels;

namespace BrandDataProcessingUI.Map
{
    public class ExcavationMapper : IMapper<Excavation>
    {
        public Excavation Map(AddBrandDataForm<Excavation> form)
        {
            string name = form.BrandData.Name;
            string monument = form.BrandData.Monument;
            return new Excavation(name, monument);
        }
    }
}
