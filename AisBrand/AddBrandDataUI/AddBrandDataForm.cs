using AddBrandDataUI.ViewModels;
using System;
using System.Windows.Forms;

namespace AddBrandDataUI
{
    public partial class AddBrandDataForm<T> : Form where T : class
    {
        private IUserControl<T> userControl;

        public T BrandData { get; set; }

        public AddBrandDataForm(T brandData = null)
        {
            InitializeComponent();

            InitElementsName(brandData);
            ShowExcavationAddFields(brandData);
        }

        private void InitUserControl(T brandData)
        {
            switch (typeof(T).Name)
            {
                case nameof(Excavation):
                    userControl = (IUserControl<T>)new AddExcavationUserControl(brandData as Excavation);
                    break;
                case nameof(FindsClass):
                    userControl = (IUserControl<T>)new AddFindsClassUserControl(brandData as FindsClass);
                    break;
                case nameof(Classification):
                    userControl = (IUserControl<T>)new AddClassificationUserControl(brandData as Classification);
                    break;
                default:
                    break;
            }
        }

        private void InitElementsName(T excavation)
        {
            if (excavation == null)
                SetElementsName("Добавить", "Добавить");
            else
                SetElementsName("Обновить", "Обновить");
        }

        private void SetElementsName(string formName, string buttonText)
        {
            Text = formName;
            btnAdd.Text = buttonText;
        }

        private void ShowExcavationAddFields(T brandData)
        {
            InitUserControl(brandData);
            ShowUserControl();
        }

        private void ShowUserControl()
        {
            Control control = userControl as Control;
            if (control != null)
                tlpAddPanel.Controls.Add(control, 0, 0);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void Add()
        {
            BrandData = userControl.Add();

            UserControl control = (UserControl)userControl;
            DialogResult = BrandData != null && control.ValidateChildren() ? DialogResult.OK : DialogResult.None;
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
