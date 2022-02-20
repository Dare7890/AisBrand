using BrandDataProcessing.Models;
using System;
using System.Linq;
using System.Windows.Forms;
using ViewModelExcavation = AddBrandDataUI.ViewModels.Excavation;
using ViewModelFindsClass = AddBrandDataUI.ViewModels.FindsClass;
using ViewModelClassification = AddBrandDataUI.ViewModels.Classification;
using ViewModelFind = AddBrandDataUI.ViewModels.Find;
using Excavation = BrandDataProcessing.Models.Excavation;
using System.Collections;
using Tools;
using Tools.CrudView;
using Tools.Map;
using BrandDataProcessing;
using System.Collections.Generic;
using System.IO;

namespace BrandDataProcessingUI
{
    public partial class BrandDataProcessingForm : Form, ISearchView
    {
        private int selectedRowIndex = 0;
        private string currentTableName;

        private Navigation navigation;
        private ITranslater translater;

        public int? SelectedParentId { get; set; }

        public ExcavationCrud ExcavationCrud { get; private set; }
        public FindsClassCrud FindsClassCrud { get; private set; }
        public ClassificationCrud ClassificationCrud { get; private set; }
        public FindCrud FindCrud { get; private set; }

        public string FilePath { get; private set; }

        public IEnumerable BrandDataList
        {
            get { return (IEnumerable)dgvTable.DataSource; }
            set { dgvTable.DataSource = value; }
        }

        public IEnumerable<Excavation> AllExcavations { get; set; }

        public BrandDataProcessingForm(ITranslater translater)
        {
            //TODO: create init method for Navigation and translater
            InitializeComponent();
            CreateModelsCrud();
            OpenDataFile();

            InitNavigation();
            InitTranslater(translater);
            ClearTableSelection();
            SetTableName(typeof(Excavation));
        }

        private void InitTranslater(ITranslater translater)
        {
            this.translater = translater;
        }

        private void SetTableName(Type modelType)
        {
            currentTableName = modelType.Name;

            lblFilter.Text = TranslateModelName(modelType.FullName);
        }

        private void BrandDataProcessingForm_Load(object sender, EventArgs e)
        {
            FillExcavationsData();
        }

        private void InitNavigation()
        {
            navigation = new Navigation();
        }

        private void CreateModelsCrud()
        {
            ExcavationCrud = new();
            FindsClassCrud = new();
            ClassificationCrud = new();
            FindCrud = new();
        }

        private void OpenDataFile()
        {
            if (FilePath == null || !File.Exists(FilePath))
                CreateDataFile();

            SetCrudsEntitiesFilePath();
        }

        private void CreateDataFile()
        {
            DataFileManager fileManager = new();
            fileManager.Create();

            FilePath = fileManager.FilePath;
        }

        private bool IsDataFileEmpty()
        {
            DataFileManager fileManager = new();
            return fileManager.IsEmpty();
        }

        private void SetCrudsEntitiesFilePath()
        {
            ExcavationCrud.FilePath = FilePath;
            FindsClassCrud.FilePath = FilePath;
            ClassificationCrud.FilePath = FilePath;
            FindCrud.FilePath = FilePath;
        }

        private void ClearTableSelection()
        {
            dgvTable.ClearSelection();
        }

        private void dgvTable_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            e.ContextMenuStrip = cmsContext;
            selectedRowIndex = e.RowIndex;
        }

        private void dgvTable_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            SelectRowByRightClick(e);
        }

        private void SelectRowByRightClick(DataGridViewCellMouseEventArgs e)
        {
            if (IsHeaderRow(e.RowIndex))
                return;

            DataGridViewRow selectedRow = dgvTable.Rows[e.RowIndex];
            if (IsRowAlreadySelected(selectedRow))
                return;

            if (e.Button == MouseButtons.Right)
            {
                foreach (DataGridViewRow row in dgvTable.SelectedRows)
                    DisableSelect(row);

                SelectRow(selectedRow);
            }
        }

        private bool IsRowAlreadySelected(DataGridViewRow row)
        {
            return row.Selected;
        }

        private static void DisableSelect(DataGridViewRow row)
        {
            row.Selected = false;
        }

        private static void SelectRow(DataGridViewRow row)
        {
            row.Selected = true;
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

            List<DataGridViewCellCollection> cells = GetSelectedRowsCells();
            switch (currentTableName)
            {
                case nameof(Excavation):
                    Delete(cells, RetrieverSelectedData.GetSelectedExcavation, ExcavationCrud);
                    break;
                case nameof(FindsClass):
                    Delete(cells, RetrieverSelectedData.GetSelectedFindsClass, FindsClassCrud);
                    break;
                case nameof(Find):
                    Delete(cells, RetrieverSelectedData.GetSelectedFind, FindCrud);
                    break;
                default:
                    break;
            }
        }

        private void Delete<T>(List<DataGridViewCellCollection> cells, Func<DataGridViewCellCollection, T> retrieverSelectedData, BrandDataCrud<T> dataCrud)
            where T : class
        {
            List<T> deletedModels = new();
            foreach (DataGridViewCellCollection cell in cells)
                deletedModels.Add(retrieverSelectedData(cell));

            dataCrud.DeleteRange(deletedModels);
        }

        private List<DataGridViewCellCollection> GetSelectedRowsCells()
        {
            List<DataGridViewCellCollection> allCells = new();
            foreach (DataGridViewRow row in dgvTable.SelectedRows)
            {
                DataGridViewCellCollection cells = GetSelectedRowCells(row);
                allCells.Add(cells);
            }

            return allCells;
        }

        private DataGridViewCellCollection GetSelectedRowCells(DataGridViewRow row)
        {
            return row.Cells;
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

        private void tlsAdd_Click(object sender, EventArgs e)
        {
            AddData();
        }

        private void AddData()
        {
            switch (currentTableName)
            {
                case nameof(Excavation):
                    ExcavationCrud.Add(this, new ExcavationMapper());
                    TableHeaders.Excavation.SetExcavationTitles(dgvTable);
                    break;
                case nameof(FindsClass):
                    IEnumerable<string> findTypes = ChildrenEntityRetriever.RetrieveTranslatedFindChildrenNames(translater);
                    FindsClassCrud.Add(this, new FindsClassMapper(), findTypes);
                    break;
                case nameof(Classification):
                    ClassificationCrud.Add(this, new ClassificationMapper());
                    break;
                case nameof(Find):
                    FindsClass parentFindsClass = GetParentFindsClass(SelectedParentId);
                    FindCrud.Add(this, new FindMapper(), findsClass: parentFindsClass);
                    break;
                default:
                    break;
            }
        }

        private FindsClass GetParentFindsClass(int? parentId)
        {
            return FindsClassCrud.GetFindClassById(parentId.Value);
        }

        private void smiUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            DataGridViewRow selectedRow = dgvTable.Rows[selectedRowIndex];
            DataGridViewCellCollection cells = GetSelectedRowCells(selectedRow);
            switch (currentTableName)
            {
                case nameof(Excavation):
                    UpdateExcavation(cells);
                    break;
                case nameof(FindsClass):
                    navigation.Forward(currentTableName, SelectedParentId);
                    ViewModelFindsClass viewModelFindsClass = new ViewModelFindsClass(dgvTable.Rows[dgvTable.CurrentCell.RowIndex].Cells[1].Value.ToString());
                    FindsClassCrud.GetId(viewModelFindsClass);
                    FillClassificationData();
                    SetTableName(typeof(Classification));
                    break;
                case nameof(Classification):
                    UpdateClassification(cells);
                    break;
                case nameof(Find):
                    UpdateFind(cells);
                    break;
                default:
                    break;
            }
        }

        private void UpdateFind(DataGridViewCellCollection cells)
        {
            ViewModelFind updatedFind = RetrieverSelectedData.GetSelectedFind(cells);
            IMapper<ViewModelFind> findMapper = new FindMapper();
            UpdateData(updatedFind, findMapper);
        }

        private void UpdateClassification(DataGridViewCellCollection cells)
        {
            ViewModelClassification updatedClassification = RetrieverSelectedData.GetSelectedClassification(cells);
            IMapper<ViewModelClassification> classificationMapper = new ClassificationMapper();
            UpdateData(updatedClassification, classificationMapper);
        }

        private void UpdateExcavation(DataGridViewCellCollection cells)
        {
            ViewModelExcavation updatedExcavation = RetrieverSelectedData.GetSelectedExcavation(cells);
            IMapper<ViewModelExcavation> excavationMapper = new ExcavationMapper();
            UpdateData(updatedExcavation, excavationMapper);
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
                case nameof(Classification):
                    //ClassificationCrud.Update(this, (IMapper<ViewModelClassification>)mapper, sourceBrandData as ViewModelClassification);
                    ClassificationCrud.Fill(sourceBrandData as ViewModelClassification);
                    break;
                case nameof(FindsClass):
                    FindsClassCrud.Update(this, (IMapper<ViewModelFindsClass>)mapper, sourceBrandData as ViewModelFindsClass);
                    break;
                case nameof(Find):
                    FindsClass parentFindsClass = GetParentFindsClass(SelectedParentId);
                    FindCrud.OnGetFullFindInfo(sourceBrandData as ViewModelFind, parentFindsClass);
                    break;
                default:
                    break;
            }
        }

        private void dgvTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsHeaderRow(e.RowIndex))
                return;

            Fill(e);
        }

        private bool IsHeaderRow(int rowIndex)
        {
            return rowIndex < 0;
        }

        private void Fill(DataGridViewCellEventArgs e)
        {
            switch (currentTableName)
            {
                case nameof(Excavation):
                    ViewModelExcavation viewModelExcavation = new ViewModelExcavation(dgvTable.Rows[e.RowIndex].Cells[1].Value.ToString(), dgvTable.Rows[e.RowIndex].Cells[0].Value.ToString());
                    ExcavationCrud.GetId(viewModelExcavation);
                    FillFindsClassData();
                    navigation.Forward(currentTableName, null);
                    SetTableName(typeof(FindsClass));
                    EnableBackButton();
                    ExcavationCrud.OnGetAllExcavations();
                    break;
                case nameof(Classification):
                    DataGridViewRow selectedRow = dgvTable.Rows[selectedRowIndex];
                    DataGridViewCellCollection cells = GetSelectedRowCells(selectedRow);
                    UpdateClassification(cells);
                    break;
                case nameof(FindsClass):
                    navigation.Forward(currentTableName, SelectedParentId);
                    ViewModelFindsClass viewModelFindsClass = new ViewModelFindsClass(dgvTable.Rows[dgvTable.CurrentCell.RowIndex].Cells[1].Value.ToString());
                    FindsClassCrud.GetId(viewModelFindsClass);
                    FillFindData();
                    SetTableName(typeof(Find));
                    break;
                default:
                    break;
            }
        }

        private void FillFindData()
        {
            FindCrud.Fill();
            TableHeaders.Find.SetFindTitles(dgvTable);
        }

        private void dgvTable_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();
        }

        private void tlsBack_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void Back()
        {
            NavigationInfo pastValue = navigation.Back();

            switch (pastValue.Page)
            {
                case nameof(Excavation):
                    FillExcavationsData();
                    SetTableName(typeof(Excavation));
                    break;
                case nameof(FindsClass):
                    SelectedParentId = pastValue.Id;
                    FillFindsClassData();
                    SetTableName(typeof(FindsClass));
                    break;
            }

            if (!navigation.IsExistsPages)
                DisableBackButton();
        }

        //TODO: one method for all fill
        private void FillFindsClassData()
        {
            FindsClassCrud.Fill();
            TableHeaders.FindsClass.SetFindsClassTitles(dgvTable);
        }

        private void FillExcavationsData()
        {
            ExcavationCrud.Fill();
            TableHeaders.Excavation.SetExcavationTitles(dgvTable);
            SelectedParentId = null;
        }

        private void FillClassificationData()
        {
            ClassificationCrud.Fill();
            TableHeaders.Classification.SetClassificationTitles(dgvTable);
        }

        private void DisableBackButton()
        {
            tlsBack.Enabled = false;
        }

        private void EnableBackButton()
        {
            tlsBack.Enabled = true;
        }

        private string TranslateModelName(string name)
        {
            return translater.Translate(name);
        }
    }
}
