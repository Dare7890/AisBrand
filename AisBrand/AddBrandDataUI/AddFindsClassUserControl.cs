using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AddBrandDataUI.ViewModels;

namespace AddBrandDataUI
{
    public partial class AddFindsClassUserControl : UserControl, IUserControl<FindsClass>
    {
        public AddFindsClassUserControl(IEnumerable<string> findTypes, FindsClass findsClass = null)
        {
            InitializeComponent();

            if (findsClass != null)
                FillTextFields(findsClass);

            InitFindTypes(findTypes);
        }

        private void InitFindTypes(IEnumerable<string> findTypes)
        {
            foreach (string type in findTypes)
                cboClass.Items.Add(type);

            SelectFirstItem(cboClass);
        }

        private void SelectFirstItem(ComboBox cboClass)
        {
            if (cboClass.Items.Count > 0)
                cboClass.SelectedIndex = 0;
        }

        private void FillTextFields(FindsClass findsClass)
        {
            cboClass.SelectedItem = findsClass.Class.Trim();
        }

        public FindsClass Add()
        {
            string findsClass = cboClass.SelectedItem.ToString();

            return new FindsClass(findsClass);
        }
    }
}
