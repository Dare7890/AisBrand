namespace AddBrandDataUI
{
    public interface IUserControl<T> where T : class
    {
        T Add();
    }
}