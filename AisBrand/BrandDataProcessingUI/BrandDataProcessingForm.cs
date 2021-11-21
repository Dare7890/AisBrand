using BrandDataProcessing.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BrandDataProcessingBL;

namespace BrandDataProcessingUI
{
    public partial class BrandDataProcessingForm : Form, ISearchView
    {
        public event EventHandler<FillExcavationsEventArgs> FillExcavationsList;

        //private IEnumerable<Excavation> excavations;

        public IList<Excavation> CustomerList
        {
            get { return (IList<Excavation>)dgvTable.DataSource; }
            set { dgvTable.DataSource = value; }
        }

        public BrandDataProcessingForm()
        {
            InitializeComponent();
        }

        public string GetFilePath()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "xml files (*.xml)|*.xml";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    throw new InvalidOperationException("Cant opan file.");

                return openFileDialog.FileName;
            }
        }

        private void mnsOpenFile_Click(object sender, EventArgs e)
        {
            string filePath = GetFilePath();

            if (FillExcavationsList != null)
                FillExcavationsList.Invoke(this, new FillExcavationsEventArgs(filePath));
            //OpenFile();
            //dgvTable.DataSource = excavations.Select(e => new { e.ID, e.Name, e.Monument }).ToList();
            //const int idIndex = 0;
            //dgvTable.Columns[idIndex].Width = 50;
            //dgvTable.Columns[idIndex].HeaderText = "Индекс";
        }

        //private void OpenFile()
        //{
        //    using (OpenFileDialog openFileDialog = new OpenFileDialog())
        //    {
        //        openFileDialog.Filter = "xml files (*.xml)|*.xml";
        //        openFileDialog.RestoreDirectory = true;

        //        if (openFileDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            string filePath = openFileDialog.FileName;
        //            //IEnumerable<XElement> excavationsElements = XDocument.Load(filePath).Descendants(nameof(Excavation));
        //            //excavations = Serializated<Excavation>.XmlDeserialization(excavationsElements);
        //        }
        //    }
        //}
    }
}
