using System.Windows.Forms;
using AddBrandDataUI.ViewModels;

namespace AddBrandDataUI
{
    public partial class AddExcavationUserControl : UserControl
    {
        public AddExcavationUserControl()
        {
            InitializeComponent();
        }

        public Excavation Add()
        {
            string name = txtName.Text.Trim();
            string monument = txtMonument.Text.Trim();

            return new Excavation(name, monument);
        }
    }
}
