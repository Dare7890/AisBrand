using BrandDataProcessing;
using BrandDataProcessing.DAL;
using BrandDataProcessing.Models;
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
            // TODO: реализовать уникальность.
            Classification classification = GetClassification(classifications, e.SourceBrandData.Type, e.SourceBrandData.Variant);

            //  TODO: create mapper.
            classification.Type = e.UpdatedBrandData.Type;
            classification.Variant = e.UpdatedBrandData.Variant;
            classification.Description = e.UpdatedBrandData.Description;
            classification.Image = (byte[])e.UpdatedBrandData.Image?.Clone() ?? null;
            CheckOnSameClassification(classification);

            repository.Update(classification);

            int parentId = view.SelectedParentId.Value;
            RefreshExcavationsList(parentId);
        }

        private void CheckOnSameClassification(Classification classification)
        {
            if (HasSameClassification(classifications, classification))
                throw new InvalidOperationException("This classification already exists");
        }

        private bool HasSameClassification(IEnumerable<Classification> classifications, Classification searchedClassification)
        {
            Classification sameClassification = classifications.FirstOrDefault(c => c.Type == searchedClassification.Type && c.Variant == searchedClassification.Variant);
            return sameClassification != null;
        }

        private Classification GetClassification(IEnumerable<Classification> classifications, string type, string variant)
        {
            return classifications.SingleOrDefault(c => c.Type == type && c.Variant == variant);
        }

        private void ClassificationCrud_AddExcavation(object sender, AddEventArgs<AddBrandDataUI.ViewModels.Classification> e)
        {
            repository = new ClassificationLocal(e.FilePath);

            Classification classification = new();
            classification.Type = e.BrandData.Type;
            classification.Variant = e.BrandData.Variant;
            classification.Description = e.BrandData.Description;

            if (e.BrandData.Image != null)
                classification.Image = (byte[])e.BrandData.Image.Clone();

            if (!view.SelectedParentId.HasValue)
                throw new ArgumentNullException("Add error. Parent id is null");

            CheckOnSameClassification(classification);

            int parentId = view.SelectedParentId.Value;
            repository.Add(classification, parentId);
            RefreshExcavationsList(parentId);
        }

        private void ClassificationCrud_FillExcavationsList(object sender, FillEventArgs e)
        {
            repository = new ClassificationLocal(e.FilePath);

            int parentId = view.SelectedParentId.Value;
            RefreshExcavationsList(parentId);
        }

        private void RefreshExcavationsList(int id)
        {
            classifications = repository.GetAll(id);

            view.BrandDataList = classifications.Select(c => new { c.Type, c.Variant })
                                                .OrderBy(c => c.Type)
                                                .ThenBy(c => c.Variant)
                                                .ToList();
        }
    }
}
