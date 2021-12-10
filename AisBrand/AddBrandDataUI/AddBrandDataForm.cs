using AddBrandDataUI.ViewModels;
using System;
using System.Windows.Forms;

namespace AddBrandDataUI
{
    public partial class AddBrandDataForm : Form
    {
        private AddExcavationUserControl addExcavationUserControl;

        public Excavation Excavation { get; set; }

        public AddBrandDataForm(Excavation excavation = null)
        {
            InitializeComponent();

            InitElementsName(excavation);
            ShowExcavationAddFields(excavation);
        }

        private void InitElementsName(Excavation excavation)
        {
            if (excavation == null)
                SetElementsName("Добавить раскопы", "Добавить");
            else
                SetElementsName("Обновить раскопы", "Обновить");
        }

        private void SetElementsName(string formName, string buttonText)
        {
            Text = formName;
            btnAdd.Text = buttonText;
        }

        private void ShowExcavationAddFields(Excavation excavation)
        {
            addExcavationUserControl = new AddExcavationUserControl(excavation);
            tlpAddPanel.Controls.Add(addExcavationUserControl, 0, 0);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddExcavation();
        }

        private void AddExcavation()
        {
            Excavation = addExcavationUserControl.Add();

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
