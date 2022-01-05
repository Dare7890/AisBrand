using BrandDataProcessing.Models;
using System;
using System.Windows.Forms;
using ViewModelExcavation = AddBrandDataUI.ViewModels.Excavation;
using ViewModelFindsClass = AddBrandDataUI.ViewModels.FindsClass;
using Excavation = BrandDataProcessing.Models.Excavation;
using System.Collections;
using Tools;
using Tools.CrudView;
using Tools.Map;
using System.Collections.Generic;
using System.Linq;

namespace BrandDataProcessingUI
{
    public partial class BrandDataProcessingForm : Form, ISearchView
    {
        private const int selectedRowIndex = 0;
        private string currentTableName = nameof(Excavation);

        public int? SelectedParentId { get; set; }

        public BrandDataCrud<ViewModelExcavation> ExcavationCrud { get; private set; }
        public BrandDataCrud<ViewModelFindsClass> FindsClassCrud { get; private set; }
        public string FilePath { get; private set; }

        public IEnumerable BrandDataList
        {
            get { return (IEnumerable)dgvTable.DataSource; }
            set { dgvTable.DataSource = value; }
        }

        public BrandDataProcessingForm()
        {
            InitializeComponent();

            ExcavationCrud = new();
            FindsClassCrud = new();
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
            if (FilePath == null)
            {
                string filePath = GetFilePath();
                // TODO: filePath as property, delete from eventArgs
                FilePath = filePath;
                SetCrudsEntitiesFilePath();
            }

            ExcavationCrud.Fill();
        }

        private void SetCrudsEntitiesFilePath()
        {
            ExcavationCrud.FilePath = FilePath;
            FindsClassCrud.FilePath = FilePath;
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

            DataGridViewCellCollection cells = GetSelectedCells();
            switch (currentTableName)
            {
                case nameof(Excavation):
                    ViewModelExcavation deletedExcavation = RetrieverSelectedData.GetSelectedExcavation(cells);
                    ExcavationCrud.Delete(deletedExcavation);
                    break;
                case nameof(FindsClass):
                    ViewModelFindsClass deletedFindsClass = RetrieverSelectedData.GetSelectedFindsClass(cells);
                    FindsClassCrud.Delete(deletedFindsClass);
                    break;
                default:
                    break;
            }
        }

        private DataGridViewCellCollection GetSelectedCells()
        {
            return dgvTable.SelectedRows[selectedRowIndex].Cells;
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
            switch (currentTableName)
            {
                case nameof(Excavation):
                    ExcavationCrud.Add(this, new ExcavationMapper());
                    break;
                case nameof(FindsClass):
                    FindsClassCrud.Add(this, new FindsClassMapper());
                    break;
                default:
                    break;
            }
        }

        private void smiUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewCellCollection cells = GetSelectedCells();
            switch (currentTableName)
            {
                case nameof(Excavation):
                    ViewModelExcavation updatedExcavation = RetrieverSelectedData.GetSelectedExcavation(cells);
                    IMapper<ViewModelExcavation> excavationMapper = new ExcavationMapper();
                    UpdateData(updatedExcavation, excavationMapper);
                    break;
                case nameof(FindsClass):
                    ViewModelFindsClass updatedFindsClass = RetrieverSelectedData.GetSelectedFindsClass(cells);
                    IMapper<ViewModelFindsClass> findsClassMapper = new FindsClassMapper();
                    UpdateData(updatedFindsClass,findsClassMapper);
                    break;
                default:
                    break;
            }
        }

        // TODO: убрать обобщенный метод, поместить код из обработчика.
        private void UpdateData<T>(T sourceBrandData, IMapper<T> mapper) where T : class
        {
            if (sourceBrandData == null)
                return;

            switch (currentTableName)
            {
                case nameof(Excavation):
                    ExcavationCrud.Update(this, (IMapper<ViewModelExcavation>)mapper, sourceBrandData as ViewModelExcavation);
                    break;
                case nameof(FindsClass):
                    FindsClassCrud.Update(this, (IMapper<ViewModelFindsClass>)mapper, sourceBrandData as ViewModelFindsClass);
                    break;
                default:
                    break;
            }
        }

        private void dgvTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (currentTableName)
            {
                case nameof(Excavation):
                    ViewModelExcavation viewModelExcavation = new ViewModelExcavation(dgvTable.Rows[e.RowIndex].Cells[0].Value.ToString(), dgvTable.Rows[e.RowIndex].Cells[1].Value.ToString());
                    ExcavationCrud.GetId(viewModelExcavation);
                    FindsClassCrud.Fill();
                    currentTableName = nameof(FindsClass);
                    break;
                default:
                    break;
            }
        }

        private void dgvTable_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();
        }
    }
}
