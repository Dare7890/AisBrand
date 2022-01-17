using System;
using System.ComponentModel;
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

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            ValidatingName(e);
        }

        public void ValidatingName(CancelEventArgs e)
        {
            string name = txtName.Text.Trim();
            if (!Validator.Excavation.ValidName(name, out string errorMasage))
            {
                e.Cancel = true;
                txtName.Select(0, txtName.Text.Length);

                errValidating.SetError(txtName, errorMasage);
            }
            else
            {
                errValidating.SetError(txtName, string.Empty);
            }
        }
    }
}
