using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AddBrandDataUI.ViewModels;

namespace AddBrandDataUI
{
    public partial class AddBrandUserControl : UserControl, IBrandUserControl
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

        public IEnumerable<string> GetPropertyItems(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(Brand.Clay):
                    return cboClay.Items.Cast<string>();
                case nameof(Brand.Admixture):
                    return cboAdmixture.Items.Cast<string>();
                case nameof(Brand.Sprinkling):
                    return cboSprinkling.Items.Cast<string>();
                case nameof(Brand.ReconstructionReliability):
                    return cboReliability.Items.Cast<string>();
                default:
                    throw new InvalidOperationException(propertyName);
            }
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
