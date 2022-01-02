using BrandDataProcessing.Models;
using System;
using System.Windows.Forms;
using AddBrandDataUI;
using ViewModelExcavation = AddBrandDataUI.ViewModels.Excavation;
using Excavation = BrandDataProcessing.Models.Excavation;
using System.Collections;
using Tools;
using Tools.EventArgs;
using Tools.CrudView;
using Tools.Map;

namespace BrandDataProcessingUI
{
    public partial class BrandDataProcessingForm : Form, ISearchView
    {
        private string currentTableName = nameof(Excavation);

        public event EventHandler<FillEventArgs> FillFindsClassListEvent;

        public BrandDataCrud<AddBrandDataUI.ViewModels.Excavation> ExcavationCrud { get; private set; }
        public BrandDataCrud<AddBrandDataUI.ViewModels.FindsClass> FindsClassCrud { get; private set; }
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

        private void mnsOpenFile_Click(object sender, System.EventArgs e)
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

        private void smiDelete_Click(object sender, System.EventArgs e)
        {
            Delete();
            ClearTableSelection();
        }

        private void Delete()
        {
            DialogResult isDelete = ConfirmDeletion();
            if (isDelete == DialogResult.No)
                return;

            switch (currentTableName)
            {
                case nameof(Excavation):
                    ViewModelExcavation deletedExcavation = GetSelectedExcavation();
                    ExcavationCrud.Delete(deletedExcavation);
                    break;
                case nameof(FindsClass):
                    AddBrandDataUI.ViewModels.FindsClass deletedFindsClass = GetSelectedFindsClass();
                    FindsClassCrud.Delete(deletedFindsClass);
                    break;
                default:
                    break;
            }
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

        private AddBrandDataUI.ViewModels.FindsClass GetSelectedFindsClass()
        {
            const int rowIndex = 0;
            const int classIndex = 0;
            string findsClass = dgvTable.SelectedRows[rowIndex].Cells[classIndex].Value.ToString();

            return new AddBrandDataUI.ViewModels.FindsClass(findsClass);
        }

        private static DialogResult ConfirmDeletion()
        {
            return MessageBox.Show("Вы уверены?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void mnsClose_Click(object sender, System.EventArgs e)
        {
            CloseWindow();
        }

        private void CloseWindow()
        {
            this.Close();
        }

        private void btnAddExcavation_Click(object sender, System.EventArgs e)
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

        private void smiUpdate_Click(object sender, System.EventArgs e)
        {
            switch (currentTableName)
            {
                case nameof(Excavation):
                    ViewModelExcavation updatedExcavation = GetSelectedExcavation();
                    IMapper<ViewModelExcavation> excavationMapper = new ExcavationMapper();
                    UpdateData(updatedExcavation, excavationMapper);
                    break;
                case nameof(FindsClass):
                    AddBrandDataUI.ViewModels.FindsClass updatedFindsClass = GetSelectedFindsClass();
                    IMapper<AddBrandDataUI.ViewModels.FindsClass> findsClassMapper = new FindsClassMapper();
                    UpdateData(updatedFindsClass,findsClassMapper);
                    break;
                default:
                    break;
            }
        }

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
                    FindsClassCrud.Update(this, (IMapper<AddBrandDataUI.ViewModels.FindsClass>)mapper, sourceBrandData as AddBrandDataUI.ViewModels.FindsClass);
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
                    FindsClassCrud.Fill();
                    currentTableName = nameof(FindsClass);
                    break;
                default:
                    break;
            }
        }
    }
}
