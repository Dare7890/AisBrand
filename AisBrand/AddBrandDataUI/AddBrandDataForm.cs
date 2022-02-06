using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AddBrandDataUI.ViewModels;

namespace AddBrandDataUI
{
    public partial class AddBrandDataForm<T> : Form where T : class
    {
        private IUserControl<T> userControl;

        public T BrandData { get; set; }

        public AddBrandDataForm(T brandData = null, IEnumerable<string> types = null)
        {
            InitializeComponent();

            InitElementsName(brandData);
            ShowExcavationAddFields(brandData, types);
        }

        private void InitUserControl(T brandData, IEnumerable<string> types)
        {
            switch (typeof(T).Name)
            {
                case nameof(Excavation):
                    userControl = (IUserControl<T>)new AddExcavationUserControl(types, brandData as Excavation);
                    break;
                case nameof(FindsClass):
                    userControl = (IUserControl<T>)new AddFindsClassUserControl(types, brandData as FindsClass);
                    break;
                case nameof(Classification):
                    userControl = (IUserControl<T>)new AddClassificationUserControl(brandData as Classification);
                    break;
                case nameof(Find):
                    userControl = (IUserControl<T>)new AddFindUserControl(brandData as Find);
                    break;
                default:
                    break;
            }
        }

        private void InitElementsName(T excavation)
        {
            if (excavation == null)
                SetElementsName("Добавить");
            else
                SetElementsName("Обновить");
        }

        private void SetElementsName(string formName)
        {
            Text = formName;
        }

        private void ShowExcavationAddFields(T brandData, IEnumerable<string> types)
        {
            InitUserControl(brandData, types);
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
    }
}
