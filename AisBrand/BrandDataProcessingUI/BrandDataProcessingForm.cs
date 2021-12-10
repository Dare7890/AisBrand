﻿using BrandDataProcessing.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using BrandDataProcessingBL;
using AddBrandDataUI;
using ViewModelExcavation = AddBrandDataUI.ViewModels.Excavation;
using Excavation = BrandDataProcessing.Models.Excavation;

namespace BrandDataProcessingUI
{
    public partial class BrandDataProcessingForm : Form, ISearchView
    {
        public event EventHandler<FillExcavationsEventArgs> FillExcavationsList;
        public event EventHandler<DeleteExcavationEventArgs> DeleteExcavation;
        public event EventHandler<AddExcavationEventArgs> AddExcavation;
        public event EventHandler<AddExcavationEventArgs> UpdateExcavation;

        public string FilePath { get; private set; }

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

        // TODO: filePath as property, delete from eventArgs

        private void mnsOpenFile_Click(object sender, EventArgs e)
        {
            string filePath = GetFilePath();
            // TODO: filePath as property, delete from eventArgs
            FilePath = filePath;

            if (FillExcavationsList != null)
                FillExcavationsList.Invoke(this, new FillExcavationsEventArgs(filePath));

            ClearTableSelection();
            EnableAddButton();
        }

        private void EnableAddButton()
        {
            btnAddExcavation.Enabled = true;
        }

        private void ClearTableSelection()
        {
            dgvTable.ClearSelection();
        }

        private void dgvTable_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            e.ContextMenuStrip = cmsContext;
        }

        private void dgvTable_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            SelectRowByRightClick(e);
        }

        private void SelectRowByRightClick(DataGridViewCellMouseEventArgs e)
        {
            const int headerIndex = -1;
            if (e.Button == MouseButtons.Right && e.RowIndex != headerIndex)
            {
                dgvTable.ClearSelection();
                dgvTable.Rows[e.RowIndex].Selected = true;
            }
        }

        private void smiDelete_Click(object sender, EventArgs e)
        {
            DialogResult isDelete = ConfirmDeletion();
            if (isDelete == DialogResult.No)
                return;

            int deletedIndex = dgvTable.CurrentCell.RowIndex;

            if (DeleteExcavation != null)
                DeleteExcavation.Invoke(this, new DeleteExcavationEventArgs(FilePath, deletedIndex));

            ClearTableSelection();
        }

        private static DialogResult ConfirmDeletion()
        {
            return MessageBox.Show("Вы уверены?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void mnsClose_Click(object sender, EventArgs e)
        {
            CloseWindow();
        }

        private void CloseWindow()
        {
            this.Close();
        }

        private void btnAddExcavation_Click(object sender, EventArgs e)
        {
            AddExcavationData();
        }

        private void AddExcavationData()
        {
            using (AddBrandDataForm addForm = new AddBrandDataForm())
            {
                if (addForm.ShowDialog(this) == DialogResult.OK)
                {
                    Excavation excavation = new Excavation();
                    excavation.Name = addForm.Excavation.Name;
                    excavation.Monument = addForm.Excavation.Monument;
                    excavation.Classifications = new List<Classification>();

                    if (AddExcavation != null)
                        AddExcavation.Invoke(this, new AddExcavationEventArgs(FilePath, excavation));
                }

                addForm.Close();
            }
        }

        private void smiUpdate_Click(object sender, EventArgs e)
        {
            int selectedExcavationID = GetSelectedExcavationID();
            Excavation selectedExcavation = GetSelectedExcavation(selectedExcavationID);
            UpdateExcavationData(selectedExcavation);
        }

        private Excavation GetSelectedExcavation(int id)
        {
            return CustomerList.Where(c => c.ID == id).FirstOrDefault();
        }

        private int GetSelectedExcavationID()
        {
            const int selectedRowIndex = 0;
            const int selectedIdCellIndex = 0;
            return (int)dgvTable.SelectedRows[selectedRowIndex].Cells[selectedIdCellIndex].Value;
        }

        private void UpdateExcavationData(Excavation excavation)
        {
            if (excavation == null)
                return;

            //TODO: переделать связывание через фреймворк.
            ViewModelExcavation viewModelExcavation = new ViewModelExcavation(excavation.Name, excavation.Monument);

            using (AddBrandDataForm updateForm = new AddBrandDataForm(viewModelExcavation))
            {
                if (updateForm.ShowDialog(this) == DialogResult.OK)
                {
                    Excavation updatedExcavation = new Excavation();
                    //TODO: add id, need not viewModel
                    updatedExcavation.ID = excavation.ID;
                    updatedExcavation.Name = updateForm.Excavation.Name;
                    updatedExcavation.Monument = updateForm.Excavation.Monument;
                    updatedExcavation.Classifications = new List<Classification>();

                    if (UpdateExcavation != null)
                        UpdateExcavation.Invoke(this, new AddExcavationEventArgs(FilePath, updatedExcavation));
                }

                updateForm.Close();
            }
        }
    }
}
