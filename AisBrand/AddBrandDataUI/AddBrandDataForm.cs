using AddBrandDataUI.ViewModels;
using System;
using System.Windows.Forms;

namespace AddBrandDataUI
{
    public partial class AddBrandDataForm : Form
    {
        public Excavation Excavation { get; set; }

        public AddBrandDataForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddExcavation();
        }

        private void AddExcavation()
        {
            Excavation = excAdd.Add();

            DialogResult = Excavation != null ? DialogResult.OK : DialogResult.None;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
            this.Close();
        }
    }
}
