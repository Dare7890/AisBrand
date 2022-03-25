using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BrandDataProcessingUI
{
    public partial class AnalyseOpenForm : Form
    {
        public string SelectedSubclass { get; set; }

        public AnalyseOpenForm(IEnumerable<string> subclasses)
        {
            InitializeComponent();
            InitSubclassesList(subclasses);
        }

        private void InitSubclassesList(IEnumerable<string> subclasses)
        {
            cboSublasses.Items.AddRange(subclasses.Distinct()
                                                .ToArray());
            SelectFirstItem(cboSublasses);
        }

        private void SelectFirstItem(ComboBox cboSublasses)
        {
            if (cboSublasses.Items.Count > 0)
                cboSublasses.SelectedIndex = 0;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            SelectSubclass();

            DialogResult = SelectedSubclass != string.Empty ? DialogResult.OK : DialogResult.None;
        }

        private void SelectSubclass()
        {
            SelectedSubclass = cboSublasses.SelectedItem.ToString();
        }
    }
}
