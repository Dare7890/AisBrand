using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AddBrandDataUI
{
    public partial class AddNumberFieldForm : Form
    {
        public string FieldNumber { get; set; }

        public AddNumberFieldForm()
        {
            InitializeComponent();
        }

        private void txtFieldNumber_Validating(object sender, CancelEventArgs e)
        {
            ValidatingFieldNumber(e);
        }

        private void ValidatingFieldNumber(CancelEventArgs e)
        {
            string fieldNumber = txtFieldNumber.Text.Trim();
            bool isValid = Validator.Find.ValidFieldNumber(fieldNumber, out string errorMessage);
            ValidatingProperty(isValid, txtFieldNumber, e, errorMessage);
        }

        private void ValidatingProperty(bool isValid, TextBox textBox, CancelEventArgs e, string errorMessage)
        {
            if (!isValid)
            {
                e.Cancel = true;
                textBox.Select(0, textBox.Text.Length);

                errValidating.SetError(textBox, errorMessage);
            }
            else
            {
                errValidating.SetError(textBox, string.Empty);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            InputFieldNumber();

            DialogResult = ValidateChildren() ? DialogResult.OK : DialogResult.None;
        }

        private void InputFieldNumber()
        {
            FieldNumber = txtFieldNumber.Text.Trim();
        }
    }
}
