using AddBrandDataUI.ViewModels;
using System.Windows.Forms;

namespace AddBrandDataUI
{
    public partial class AddBrandUserControl : UserControl, IUserControl<Brand>
    {
        public AddBrandUserControl(Brand brand = null)
        {
            InitializeComponent();

            if (brand != null)
                FillTextFields(brand);
        }

        public Brand Add()
        {
            string clay = cboClay.SelectedItem?.ToString().Trim() ?? cboClay.Text.Trim();
            string admixture = cboAdmixture.SelectedItem?.ToString().Trim() ?? cboAdmixture.Text.Trim();
            string sprinkling = cboSprinkling.SelectedItem?.ToString().Trim() ?? cboSprinkling.Text.Trim();
            string safety = txtSafety.Text.Trim();
            string relief = txtRelief.Text.Trim();
            string reliability = cboReliability.SelectedItem?.ToString().Trim() ?? cboReliability.Text.Trim();

            return new Brand(clay, admixture, sprinkling, safety, relief, reliability);
        }

        private void FillTextFields(Brand brand)
        {
            cboClay.SelectedItem = brand.Clay;
            cboSprinkling.SelectedItem = brand.Sprinkling;
            cboAdmixture.SelectedItem = brand.Admixture;
            cboReliability.SelectedItem = brand.ReconstructionReliability;

            txtRelief.Text = brand.Relief;
            txtSafety.Text = brand.Safety;
        }
    }
}
