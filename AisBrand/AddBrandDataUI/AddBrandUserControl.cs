using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddBrandDataUI.ViewModels;
using BrandDataProcessing;
using BrandDataProcessing.Constants;

namespace AddBrandDataUI
{
    public partial class AddBrandUserControl : UserControl, IBrandUserControl
    {
        public AddBrandUserControl(Brand brand = null, string form = null, string part = null)
        {
            InitializeComponent();

            InitSprinklingSubFields(part, form);
            InitSubFields();
            if (brand != null)
                FillTextFields(brand);
        }

        public Brand Add()
        {
            string clay = cboClay.SelectedItem?.ToString().Trim() ?? cboClay.Text.Trim();
            string admixture = cboAdmixture.SelectedItem?.ToString().Trim() ?? cboAdmixture.Text.Trim();
            string sprinkling = cboSprinkling.SelectedValue?.ToString().Trim() ?? cboSprinkling.Text.Trim();
            string safety = cboSafety.SelectedItem?.ToString().Trim() ?? cboSafety.Text.Trim();
            string relief = cboRelief.SelectedItem?.ToString().Trim() ?? cboRelief.Text.Trim();
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
                case nameof(Brand.ReconstructionReliability):
                    return cboReliability.Items.Cast<string>();
                case nameof(Brand.Relief):
                    return cboRelief.Items.Cast<string>();
                case nameof(Brand.Safety):
                    return cboSafety.Items.Cast<string>();
                default:
                    throw new InvalidOperationException(propertyName);
            }
        }

        private void FillTextFields(Brand brand)
        {
            cboClay.SelectedItem = brand.Clay;
            cboSprinkling.SelectedValue = brand.Sprinkling;
            cboAdmixture.SelectedItem = brand.Admixture;
            cboReliability.SelectedItem = brand.ReconstructionReliability;
            cboSafety.SelectedItem = brand.Safety;
            cboRelief.SelectedItem = brand.Relief;
        }

        private void InitSprinklingSubFields(string part, string form)
        {
            if (string.IsNullOrEmpty(part) || string.IsNullOrEmpty(form))
            {
                return;
            }

            string formFirstWord = form.Split(" ").FirstOrDefault();
            string partFirstWord = part.Split(" ").FirstOrDefault();

            string sprinklingsTemplate = $"{formFirstWord} {partFirstWord} ";
            var filteredSprinklings = SubFieldsRetriever.Retrieve().Sprinklings.Where(a => a.StartsWith(sprinklingsTemplate))
                .Select(a => new { Value = a, Display = a[sprinklingsTemplate.Length..] })
                .ToArray();

            cboSprinkling.DataSource = filteredSprinklings;
            cboSprinkling.DisplayMember = "Display";
            cboSprinkling.ValueMember = "Value";
        }

        private void InitSubFields()
        {
            SubFields subFields = SubFieldsRetriever.Retrieve();
            cboAdmixture.Items.AddRange(subFields.Admixtures.ToArray());
            cboClay.Items.AddRange(subFields.Clays.ToArray());
            cboReliability.Items.AddRange(subFields.Reliabilities.ToArray());
            cboRelief.Items.AddRange(subFields.Reliefs.ToArray());
            cboSafety.Items.AddRange(subFields.Safeties.ToArray());
        }
    }
}
