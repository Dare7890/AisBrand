using System.Windows.Forms;
using AddBrandDataUI.ViewModels;

namespace AddBrandDataUI
{
    public partial class AddExcavationUserControl : UserControl, IUserControl<Excavation>
    {
        public AddExcavationUserControl(Excavation excavation = null)
        {
            InitializeComponent();

            if (excavation != null)
                FillTextFields(excavation);
        }

        private void FillTextFields(Excavation excavation)
        {
            txtName.Text = excavation.Name.Trim();
            txtMonument.Text = excavation.Monument.Trim();
        }

        public Excavation Add()
        {
            string name = txtName.Text.Trim();
            string monument = txtMonument.Text.Trim();

            return new Excavation(name, monument);
        }
    }
}
