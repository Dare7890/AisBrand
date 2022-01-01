using AddBrandDataUI.ViewModels;
using System.Windows.Forms;

namespace AddBrandDataUI
{
    public interface IUserControl<T> where T : class
    {
        T Add();
    }
}