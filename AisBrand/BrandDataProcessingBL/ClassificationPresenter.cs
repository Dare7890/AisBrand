using BrandDataProcessing;
using BrandDataProcessing.DAL;
using BrandDataProcessing.Models;
using GenericFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using Tools;
using Tools.EventArgs;
using Tools.Map;

namespace BrandDataProcessingBL
{
    public class ClassificationPresenter : IPresenter
    {
        private IRepository<Classification> repository;
        private readonly ISearchView view;

        private IEnumerable<Classification> classifications;

        public ClassificationPresenter(ISearchView view)
        {
            this.view = view;
            this.view.ClassificationCrud.FillExcavationsList += ClassificationCrud_FillExcavationsList;
            this.view.ClassificationCrud.AddExcavation += ClassificationCrud_AddExcavation;
            this.view.ClassificationCrud.UpdateExcavation += ClassificationCrud_UpdateExcavation;
            this.view.ClassificationCrud.FillClassificationInfo += ClassificationCrud_FillClassificationInfo;
            this.view.ClassificationCrud.GetIdExcavation += ClassificationCrud_GetIdExcavation;
            this.view.ClassificationCrud.Filter += ClassificationCrud_Filter;
            this.view.ClassificationCrud.DeleteExcavation += ClassificationCrud_DeleteExcavation;
        }

        private void ClassificationCrud_DeleteExcavation(object sender, DeleteEventArgs<AddBrandDataUI.ViewModels.Classification> e)
        {
            repository = new ClassificationLocal(e.FilePath);

            int id = GetClassificationId(classifications, e.DeletedBrandData.Type, e.DeletedBrandData.Variant);
            repository.Delete(id);

            int parentId = view.SelectedParentId.Value;
            RefreshExcavationsList(parentId);
        }

        private void ClassificationCrud_GetIdExcavation(object sender, GetIdEventArgs<AddBrandDataUI.ViewModels.Classification> e)
        {
            repository = new ClassificationLocal(e.FilePath);
            classifications = repository.GetAll(view.SelectedParentId);

            this.view.FindCrud.ClassificationId = GetClassificationId(classifications, e.BrandData.Type, e.BrandData.Variant);
        }

        private int GetClassificationId(IEnumerable<Classification> classifications, string type, string variant)
        {
            return GetClassification(classifications, type, variant).ID;
        }

        private void ClassificationCrud_FillClassificationInfo(object sender, FillClassificationEventArgs e)
        {
            repository = new ClassificationLocal(e.FilePath);
            Classification classification = GetClassification(classifications, e.Type, e.Variant);
            AddBrandDataUI.ViewModels.Classification viewModelClassification = new AddBrandDataUI.ViewModels.Classification(classification.Type, classification.Variant, classification.Description, classification.Image);
            view.ClassificationCrud.Update((System.Windows.Forms.Form)view, new ClassificationMapper(), viewModelClassification);
        }

        private void ClassificationCrud_UpdateExcavation(object sender, UpdateEventArgs<AddBrandDataUI.ViewModels.Classification> e)
        {
            repository = new ClassificationLocal(e.FilePath);
            Classification classification = GetClassification(classifications, e.SourceBrandData.Type, e.SourceBrandData.Variant);

            CheckOnSameClassification(e.UpdatedBrandData.Type, e.UpdatedBrandData.Variant);

            //  TODO: create mapper.
            classification.Type = e.UpdatedBrandData.Type;
            classification.Variant = e.UpdatedBrandData.Variant;
            classification.Description = e.UpdatedBrandData.Description;
            classification.Image = (byte[])e.UpdatedBrandData.Image?.Clone() ?? null;

            repository.Update(classification);

            int parentId = view.SelectedParentId.Value;
            RefreshExcavationsList(parentId);
        }

        private void CheckOnSameClassification(string type, string variant)
        {
            if (HasSameClassification(classifications, type, variant))
                throw new InvalidOperationException("This classification already exists");
        }

        private bool HasSameClassification(IEnumerable<Classification> classifications, string type, string variant)
        {
            Classification sameClassification = classifications.FirstOrDefault(c => c.Type == type && c.Variant == variant);
            return sameClassification != null;
        }

        private Classification GetClassification(IEnumerable<Classification> classifications, string type, string variant)
        {
            return classifications.SingleOrDefault(c => c.Type == type && c.Variant == variant);
        }

        private void ClassificationCrud_AddExcavation(object sender, AddEventArgs<AddBrandDataUI.ViewModels.Classification> e)
        {
            repository = new ClassificationLocal(e.FilePath);

            CheckOnSameClassification(e.BrandData.Type, e.BrandData.Variant);

            Classification classification = new();
            classification.Type = e.BrandData.Type;
            classification.Variant = e.BrandData.Variant;
            classification.Description = e.BrandData.Description;

            if (e.BrandData.Image != null)
                classification.Image = (byte[])e.BrandData.Image.Clone();

            if (!view.SelectedParentId.HasValue)
                throw new ArgumentNullException("Add error. Parent id is null");

            int parentId = view.SelectedParentId.Value;
            repository.Add(classification, parentId);
            RefreshExcavationsList(parentId);
        }

        private void ClassificationCrud_FillExcavationsList(object sender, FillEventArgs e)
        {
            repository = new ClassificationLocal(e.FilePath);

            int parentId = view.SelectedParentId.Value;
            RefreshExcavationsList(parentId);
            FillPropertiesList();
        }

        private void ClassificationCrud_Filter(object sender, FilterEventArgs<AddBrandDataUI.ViewModels.Classification> e)
        {
            GenericFilter<Classification> genericFilter = new();
            IEnumerable<Classification> filteredClassification = genericFilter.CheckStartsWith(classifications, e.Property, e.Text);
            RefreshBrandDataList(filteredClassification);
        }

        private void FillPropertiesList()
        {
            view.Properties = PropertiesRetriever.Classification.Retrieve();
        }

        private void RefreshExcavationsList(int id)
        {
            classifications = repository.GetAll(id);
            RefreshBrandDataList(classifications);
        }

        private void RefreshBrandDataList(IEnumerable<Classification> filteredClassification)
        {
            view.BrandDataList = filteredClassification.Select(c => new { c.Type, c.Variant, findsAmount = c.Finds.Count() })
                                                .OrderBy(c => c.Type)
                                                .ThenBy(c => c.Variant)
                                                .ToList();
        }
    }
}
