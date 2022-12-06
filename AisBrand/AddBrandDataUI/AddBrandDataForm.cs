using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AddBrandDataUI.ViewModels;
using FindsClassModel = BrandDataProcessing.Models.FindsClass;

namespace AddBrandDataUI
{
    public partial class AddBrandDataForm<T> : Form where T : class
    {
        private IUserControl<T> userControl;

        public T BrandData { get; set; }

        public AddBrandDataForm(T brandData = null, IEnumerable<string> types = null, FindsClassModel parent = null)
        {
            InitializeComponent();

            InitElementsName(brandData);
            InitUserControl(brandData, types, parent);
            ShowUserControl();
        }

        private void InitUserControl(T brandData = null, IEnumerable<string> types = null, FindsClassModel parent = null)
        {
            if (parent != null)
                InitUserControl(brandData, parent);
            else
                InitUserControl(brandData, types);
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
                default:
                    break;
            }
        }

        private void InitUserControl(T brandData, FindsClassModel parent)
        {
            userControl = (IUserControl<T>)new AddFindUserControl(parent, brandData as Find);
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

        public bool IsCopyData()
        {
            switch (userControl)
            {
                case AddExcavationUserControl:
                    AddExcavationUserControl excavationUserControl = (AddExcavationUserControl)userControl;
                    return excavationUserControl.IsCopyData;
                case AddFindsClassUserControl:
                    AddFindsClassUserControl findClassUserControl = (AddFindsClassUserControl)userControl;
                    return findClassUserControl.IsCopyData;
                default:
                    return false;
            }
        }

        public Classification GetParentClassification()
        {
            if (userControl is AddFindUserControl)
            {
                AddFindUserControl findUserControl = (AddFindUserControl)userControl;
                return findUserControl.ParentClassification;
            }

            return null;
        }

        public IEnumerable<string> GetPropertyItems(string propertyName)
        {
            return userControl is AddFindUserControl ?
                ((AddFindUserControl)userControl).GetPropertyItems(propertyName) :
                Enumerable.Empty<string>();
        }
    }
}
