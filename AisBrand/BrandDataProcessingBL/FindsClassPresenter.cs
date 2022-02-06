﻿using System;
using System.Collections.Generic;
using System.Linq;
using BrandDataProcessing;
using BrandDataProcessing.DAL;
using BrandDataProcessing.Models;
using Tools;
using Tools.EventArgs;

namespace BrandDataProcessingBL
{
    public class FindsClassPresenter : IPresenter
    {
        private IRepository<FindsClass> repository;
        private readonly ISearchView view;

        private IEnumerable<FindsClass> findsClasses;

        private IClassificationsRetriever classificationsRetriever;

        public FindsClassPresenter(ISearchView view, IClassificationsRetriever classificationsRetriever)
        {
            this.view = view;
            this.view.FindsClassCrud.FillExcavationsList += View_FillExcavationsList;
            this.view.FindsClassCrud.AddExcavation += FindsClassCrud_AddExcavation;
            this.view.FindsClassCrud.UpdateExcavation += FindsClassCrud_UpdateExcavation;
            this.view.FindsClassCrud.DeleteExcavation += FindsClassCrud_DeleteExcavation;
            this.view.FindsClassCrud.GetIdExcavation += FindsClassCrud_GetIdExcavation;

            this.classificationsRetriever = classificationsRetriever;
        }

        private void FindsClassCrud_GetIdExcavation(object sender, GetIdEventArgs<AddBrandDataUI.ViewModels.FindsClass> e)
        {
            repository = new FindsClassLocal(e.FilePath);
            view.SelectedParentId = GetFindsClassId(findsClasses, e.BrandData.Class);
        }

        private void FindsClassCrud_DeleteExcavation(object sender, DeleteEventArgs<AddBrandDataUI.ViewModels.FindsClass> e)
        {
            repository = new FindsClassLocal(e.FilePath);
            int id = GetFindsClassId(findsClasses, e.DeletedBrandData.Class);
            repository.Delete(id);

            int parentId = view.SelectedParentId.Value;
            RefreshExcavationsList(parentId);
        }

        private void FindsClassCrud_UpdateExcavation(object sender, UpdateEventArgs<AddBrandDataUI.ViewModels.FindsClass> e)
        {
            repository = new FindsClassLocal(e.FilePath);
            FindsClass findsClass = GetFindsClass(findsClasses, e.SourceBrandData.Class);

            //  TODO: create mapper.
            findsClass.Class = e.UpdatedBrandData.Class;
            repository.Update(findsClass);

            int parentId = view.SelectedParentId.Value;
            RefreshExcavationsList(parentId);
        }

        private FindsClass GetFindsClass(IEnumerable<FindsClass> findsClasses, string className)
        {
            return findsClasses.SingleOrDefault(e => e.Class == className);
        }

        private int GetFindsClassId(IEnumerable<FindsClass> findsClasses, string className)
        {
            return GetFindsClass(findsClasses, className).ID;
        }

        private void FindsClassCrud_AddExcavation(object sender, AddEventArgs<AddBrandDataUI.ViewModels.FindsClass> e)
        {
            repository = new FindsClassLocal(e.FilePath);

            FindsClass findsClass = new();
            findsClass.Class = e.BrandData.Class;

            if (!view.SelectedParentId.HasValue)
                throw new ArgumentNullException("Add error. Parent id is null");

            CheckOnSameFindsClass(findsClass);

            string monument = GetExcavationMonument(view.AllExcavations, view.SelectedParentId.Value);
            int id = GetEnableClassificationId();
            classificationsRetriever.RetrieveFindsClassClassifications(view.AllExcavations, monument, id, findsClass);

            int parentId = view.SelectedParentId.Value;
            repository.Add(findsClass, parentId);
            RefreshExcavationsList(parentId);
        }

        private Excavation GetSelectedExcavation(IEnumerable<Excavation> excavations, int id)
        {
            return excavations.SingleOrDefault(e => e.ID == id);
        }

        private string GetExcavationMonument(IEnumerable<Excavation> excavations, int id)
        {
            Excavation selectedExcavation = GetSelectedExcavation(excavations, id);
            return selectedExcavation.Monument;
        }

        private int GetEnableClassificationId()
        {
            IEnumerable<Classification> classifications = classificationsRetriever.GetClassifications(findsClasses);
            return GetEnableId(classifications);
        }

        private static int GetEnableId(IEnumerable<IIdentifier> collection)
        {
            return collection.Max(c => c.ID) + 1;
        }

        private void CheckOnSameFindsClass(FindsClass findsClass)
        {
            if (HasSameFindsClass(findsClasses, findsClass))
                throw new InvalidOperationException("This class already exists");
        }

        private bool HasSameFindsClass(IEnumerable<FindsClass> findsClasses, FindsClass searchedFindsClass)
        {
            FindsClass sameFindsClass = findsClasses.FirstOrDefault(e => e.Class == searchedFindsClass.Class);
            return sameFindsClass != null;
        }

        private void View_FillExcavationsList(object sender, FillEventArgs e)
        {
            repository = new FindsClassLocal(e.FilePath);

            int parentId = view.SelectedParentId.Value;
            RefreshExcavationsList(parentId);
        }

        private void RefreshExcavationsList(int? id = null)
        {
            findsClasses = repository.GetAll(id);

            view.BrandDataList = findsClasses.Select(c => new { className = CategoryRetriever.Retrieve(c.Class), c.Class, c.Classifications.Count })
                                            .ToList();
        }
    }
}
