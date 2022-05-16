using System.Linq;
using BrandDataProcessing;
using BrandDataProcessing.DAL;
using System.Collections.Generic;
using BrandDataProcessing.Models;
using Tools;
using System;
using Tools.Map;
using Tools.EventArgs;
using GenericFilters;

namespace BrandDataProcessingBL
{
    public class FindPresenter : IPresenter
    {
        private IRepository<Find> repository;
        private readonly ISearchView view;

        private IEnumerable<Find> finds;

        public FindPresenter(ISearchView view)
        {
            this.view = view;
            this.view.FindCrud.FillExcavationsList += FindCrud_FillExcavationsList;
            this.view.FindCrud.AddExcavation += FindCrud_AddExcavation;
            this.view.FindCrud.GetClassificationId += FindCrud_GetClassificationId;
            this.view.FindCrud.DeleteExcavation += FindCrud_DeleteExcavation;
            this.view.FindCrud.UpdateByViewModel += FindCrud_UpdateByViewModel;
            this.view.FindCrud.UpdateExcavation += FindCrud_UpdateExcavation;
            this.view.FindCrud.AddByViewModel += FindCrud_AddByViewModel;
            this.view.FindCrud.Filter += FindCrud_Filter; ;
        }

        private void FindCrud_AddByViewModel(object sender, FindInfoEventArgs e)
        {
            AddBrandDataUI.ViewModels.Classification classification = new(e.FindsClass, e.Find.FieldNumber);
            this.view.ClassificationCrud.GetId(classification);
            AddBrandDataUI.ViewModels.Find viewModelFind = GetFullFindInfo(e.Find.FieldNumber);
            viewModelFind.FieldNumber = e.FieldNumber;

            view.FindCrud.Add(viewModelFind, view.FindCrud.ClassificationId);
        }

        private void FindCrud_UpdateExcavation(object sender, UpdateEventArgs<AddBrandDataUI.ViewModels.Find> e)
        {
            this.view.FindCrud.Delete(e.SourceBrandData);

            FindsClass findsClass = view.FindsClassCrud.GetFindClassById(view.SelectedParentId.Value);
            AddBrandDataUI.AddBrandDataForm<AddBrandDataUI.ViewModels.Find> addForm = (AddBrandDataUI.AddBrandDataForm<AddBrandDataUI.ViewModels.Find>)sender;
            this.view.FindCrud.Add((System.Windows.Forms.Form)view, new FindMapper(), form: addForm, findsClass: findsClass);
        }

        private void FindCrud_UpdateByViewModel(object sender, FindInfoEventArgs e)
        {
            AddBrandDataUI.ViewModels.Find viewModelFind = GetFullFindInfo(e.Find.FieldNumber);
            view.FindCrud.Update((System.Windows.Forms.Form)view, new FindMapper(), viewModelFind, e.FindsClass);
        }

        private AddBrandDataUI.ViewModels.Find GetFullFindInfo(string fieldNumber)
        {
            Find find = GetFind(finds, fieldNumber);
            AddBrandDataUI.ViewModels.Brand brand = null;
            if (find.Brand != null)
                brand = new(find.Brand.Clay, find.Brand.Admixture, find.Brand.Sprinkling, find.Brand.Safety, find.Brand.Relief, find.Brand.ReconstructionReliability);

            return new AddBrandDataUI.ViewModels.Find(find.FieldNumber, find.Formation, find.Square, find.Depth, find.CollectorsNumber,
                new DatingBound(find.DatingBound), find.Description, find.Analogy, find.Note, find.Image, find.Photo, brand);
        }

        private void FindCrud_DeleteExcavation(object sender, DeleteEventArgs<AddBrandDataUI.ViewModels.Find> e)
        {
            repository = new FindLocal(e.FilePath);

            int id = GetFindId(finds, e.DeletedBrandData.FieldNumber);
            repository.Delete(id);

            int parentId = view.SelectedParentId.Value;
            RefreshFinds(parentId);
        }

        private int GetFindId(IEnumerable<Find> finds, string fieldNumber)
        {
            return GetFind(finds, fieldNumber).ID;
        }

        private Find GetFind(IEnumerable<Find> finds, string fieldNumber)
        {
            return finds.SingleOrDefault(e => e.FieldNumber == fieldNumber);
        }

        private void FindCrud_GetClassificationId(object sender, GetIdEventArgs<AddBrandDataUI.ViewModels.Classification> e)
        {
            this.view.ClassificationCrud.GetId(e.BrandData);
        }

        private void FindCrud_AddExcavation(object sender, AddEventArgs<AddBrandDataUI.ViewModels.Find> e)
        {
            repository = new FindLocal(e.FilePath);

            Find find = new();
            find.Formation = e.BrandData.Formation;
            find.Square = e.BrandData.Square;
            find.Depth = e.BrandData.Depth;
            find.FieldNumber = e.BrandData.FieldNumber;
            find.CollectorsNumber = e.BrandData.CollectorsNumber;
            find.DatingBound = new(e.BrandData.Dating);
            find.Description = e.BrandData.Description;
            find.Analogy = e.BrandData.Analogy;
            find.Note = e.BrandData.Note;

            if (e.BrandData.Image != null)
                find.Image = (byte[])e.BrandData.Image.Clone();

            if (e.BrandData.Photo != null)
                find.Photo = (byte[])e.BrandData.Photo.Clone();

            if (e.BrandData.Brand != null)
                find.Brand = new Brand(e.BrandData.Brand.Clay, e.BrandData.Brand.Admixture, e.BrandData.Brand.Sprinkling, e.BrandData.Brand.Safety, e.BrandData.Brand.Relief, e.BrandData.Brand.ReconstructionReliability);

            if (!view.SelectedParentId.HasValue)
                throw new ArgumentNullException("Add error. Parent id is null");

            CheckOnSameFind(find);

            int parentId = e.ParentId.Value;
            repository.Add(find, parentId);
            int parentFindClassId = view.SelectedParentId.Value;
            RefreshFinds(parentFindClassId);
        }

        private void CheckOnSameFind(Find find)
        {
            if (HasSameFindsFind(finds, find))
                throw new InvalidOperationException("This find already exists");
        }

        private bool HasSameFindsFind(IEnumerable<Find> finds, Find find)
        {
            Find sameFind = finds.FirstOrDefault(e => e.FieldNumber == find.FieldNumber);
            return sameFind != null;
        }

        private void FindCrud_FillExcavationsList(object sender, FillEventArgs e)
        {
            repository = new FindLocal(e.FilePath);

            int parentId = view.SelectedParentId.Value;
            RefreshFinds(parentId);
            FillPropertiesList();
        }

        private void FindCrud_Filter(object sender, FilterEventArgs<AddBrandDataUI.ViewModels.Find> e)
        {
            GenericFilter<Find> genericFilter = new();
            IEnumerable<Find> filteredFinds = genericFilter.CheckStartsWith(finds, e.Property, e.Text);
            RefreshBrandDataList(filteredFinds);
        }

        private void FillPropertiesList()
        {
            FindsClass parentFindsClass = view.FindsClassCrud.GetFindClassById(view.SelectedParentId.Value);
            view.Properties = PropertiesRetriever.Find.Retrieve(parentFindsClass?.Class);
        }

        private void RefreshFinds(int? id = null)
        {
            finds = repository.GetAll(id);
            RefreshBrandDataList(finds);
        }

        private void RefreshBrandDataList(IEnumerable<Find> filteredFinds)
        {
            view.BrandDataList = filteredFinds.Select(c => new { c.FieldNumber, c.CollectorsNumber, c.Formation, c.Square })
                                            .OrderBy(c => c.Formation)
                                            .ThenBy(c => c.Square)
                                            .ThenBy(c => c.FieldNumber)
                                            .ToList();
        }
    }
}
