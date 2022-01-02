using System.Windows.Forms;
using AddBrandDataUI.ViewModels;

namespace AddBrandDataUI
{
    public partial class AddFindsClassUserControl : UserControl, IUserControl<FindsClass>
    {
        public AddFindsClassUserControl(FindsClass findsClass = null)
        {
            InitializeComponent();

            if (findsClass != null)
                FillTextFields(findsClass);
        }

        private void FillTextFields(FindsClass findsClass)
        {
            txtClass.Text = findsClass.Class.Trim();
        }

        public FindsClass Add()
        {
            string findsClass = txtClass.Text.Trim();

            return new FindsClass(findsClass);
        }
    }
}
