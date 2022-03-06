using AddBrandDataUI.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace AddBrandDataUI
{
    public partial class AddExcavationUserControl : UserControl, IUserControl<Excavation>
    {
        public bool IsCopyData { get; set; } = false;

        public AddExcavationUserControl(IEnumerable<string> monuments, Excavation excavation = null)
        {
            InitializeComponent();

            if (excavation != null)
                FillTextFields(excavation);

            InitMonuments(monuments);
        }

        private void FillTextFields(Excavation excavation)
        {
            txtName.Text = excavation.Name.Trim();
            cboMonument.SelectedItem = excavation.Monument.Trim();
        }

        private void InitMonuments(IEnumerable<string> monuments)
        {
            foreach (string monument in monuments)
                cboMonument.Items.Add(monument);

            SelectFirstItem(cboMonument);
        }

        private void SelectFirstItem(ComboBox cboClass)
        {
            if (cboClass.Items.Count > 0)
                cboClass.SelectedIndex = 0;
        }

        public Excavation Add()
        {
            IsCopyData = chkIsCopy.Checked;
            
            string name = txtName.Text.Trim();
            string monument = cboMonument.SelectedItem?.ToString().Trim() ?? cboMonument.Text.Trim();

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
