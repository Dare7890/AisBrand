using AddBrandDataUI;

namespace BrandDataProcessingUI.Map
{
    public interface IMapper<T> where T : class
    {
        T Map(AddBrandDataForm<T> form);
    }
}
