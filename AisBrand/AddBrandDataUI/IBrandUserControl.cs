using System.Collections.Generic;
using AddBrandDataUI.ViewModels;

namespace AddBrandDataUI
{
    public interface IBrandUserControl : IUserControl<Brand>
    {
        IEnumerable<string> GetPropertyItems(string propertyName);
    }
}
