using AddBrandDataUI;
using AddBrandDataUI.ViewModels;

namespace Tools.Map
{
    public class FindsClassMapper : IMapper<FindsClass>
    {
        public FindsClass Map(AddBrandDataForm<FindsClass> form)
        {
            string findsClass = form.BrandData.Class;
            return new FindsClass(findsClass);
        }
    }
}
