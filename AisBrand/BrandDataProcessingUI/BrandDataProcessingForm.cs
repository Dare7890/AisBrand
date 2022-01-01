using BrandDataProcessing.Models;
using System;
using System.Windows.Forms;
using BrandDataProcessingBL;
using AddBrandDataUI;
using ViewModelExcavation = AddBrandDataUI.ViewModels.Excavation;
using Excavation = BrandDataProcessing.Models.Excavation;
using System.Collections;
using System.Collections.Generic;
using BrandDataProcessingBL.EventArgs;
using BrandDataProcessingUI.Map;

namespace BrandDataProcessingUI
{
    public partial class BrandDataProcessingForm : Form, ISearchView
    {
        private string currentTableName = nameof(Excavation);

        public event EventHandler<FillEventArgs> FillExcavationsList;
        public event EventHandler<DeleteExcavationEventArgs> DeleteExcavation;
        public event EventHandler<AddExcavationEventArgs> AddExcavation;
        public event EventHandler<UpdateExcavationEventArgs> UpdateExcavation;

        public event EventHandler<FillEventArgs> FillFindsClassListEvent;

        public string FilePath { get; private set; }

        public IEnumerable BrandDataList
        {
            get { return (IEnumerable)dgvTable.DataSource; }
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
            FillList();

            ClearTableSelection();
            EnableAddButton();
        }

        private void FillList()
        {
            string filePath = GetFilePath();
            // TODO: filePath as property, delete from eventArgs
            FilePath = filePath;

            if (FillExcavationsList != null)
                FillExcavationsList.Invoke(this, new FillEventArgs(filePath));
        }

        private void FillFindsClassList()
        {
            // TODO: filePath as property, delete from eventArgs

            if (FillFindsClassListEvent != null)
                FillFindsClassListEvent.Invoke(this, new FillEventArgs(FilePath));
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
            Delete();
            ClearTableSelection();
        }

        private void Delete()
        {
            DialogResult isDelete = ConfirmDeletion();
            if (isDelete == DialogResult.No)
                return;

            ViewModelExcavation deletedExcavation = GetSelectedExcavation();

            if (DeleteExcavation != null)
                DeleteExcavation.Invoke(this, new DeleteExcavationEventArgs(FilePath, deletedExcavation));
        }

        private ViewModelExcavation GetSelectedExcavation()
        {
            const int deletedRowIndex = 0;
            const int deletedNameIndex = 0;
            const int deletedMonumentIndex = 1;
            string deletedName = dgvTable.SelectedRows[deletedRowIndex].Cells[deletedNameIndex].Value.ToString();
            string deletedMonument = dgvTable.SelectedRows[deletedRowIndex].Cells[deletedMonumentIndex].Value.ToString();

            return new ViewModelExcavation(deletedName, deletedMonument);
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
            AddData();
        }

        private void AddData()
        {
            using (AddBrandDataForm<ViewModelExcavation> form = new AddBrandDataForm<ViewModelExcavation>())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    switch (currentTableName)
                    {
                        case nameof(AddBrandDataUI.ViewModels.Excavation):
                            IMapper<ViewModelExcavation> mapper = new ExcavationMapper();
                            ViewModelExcavation excavation = mapper.Map(form);
                            if (AddExcavation != null)
                                AddExcavation.Invoke(this, new AddExcavationEventArgs(FilePath, excavation));
                            break;
                        default:
                            break;
                    }
                }

                form.Close();
            }
        }

        private void smiUpdate_Click(object sender, EventArgs e)
        {
            ViewModelExcavation updatedExcavation = GetSelectedExcavation();
            UpdateExcavationData(updatedExcavation);
        }

        private void UpdateExcavationData(ViewModelExcavation sourceExcavation)
        {
            if (sourceExcavation == null)
                return;

            //TODO: переделать связывание через фреймворк.
            using (AddBrandDataForm<ViewModelExcavation> form = new AddBrandDataForm<ViewModelExcavation>(sourceExcavation))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    IMapper<ViewModelExcavation> mapper = new ExcavationMapper();
                    ViewModelExcavation updatedExcavation = mapper.Map(form);
                    if (UpdateExcavation != null)
                        UpdateExcavation.Invoke(this, new UpdateExcavationEventArgs(FilePath, sourceExcavation, updatedExcavation));
                }

                form.Close();
            }
        }

        private void dgvTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (currentTableName)
            {
                case nameof(Excavation):
                    FillFindsClassList();
                    currentTableName = nameof(FindsClass);
                    break;
                default:
                    break;
            }
        }
    }
}
