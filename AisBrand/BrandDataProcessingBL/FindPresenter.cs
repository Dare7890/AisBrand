﻿using System.Linq;
using BrandDataProcessing;
using BrandDataProcessing.DAL;
using System.Collections.Generic;
using BrandDataProcessing.Models;
using Tools;
using System;
using Tools.Map;

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
            this.view.FindCrud.GetFullFindInfo += FindCrud_GetFullFindInfo;
            this.view.FindCrud.UpdateExcavation += FindCrud_UpdateExcavation;
        }

        private void FindCrud_UpdateExcavation(object sender, Tools.EventArgs.UpdateEventArgs<AddBrandDataUI.ViewModels.Find> e)
        {
            repository = new FindLocal(e.FilePath);
            this.view.FindCrud.Delete(e.SourceBrandData);

            FindsClass findsClass = view.FindsClassCrud.GetFindClassById(view.SelectedParentId.Value);
            AddBrandDataUI.AddBrandDataForm<AddBrandDataUI.ViewModels.Find> addForm = (AddBrandDataUI.AddBrandDataForm<AddBrandDataUI.ViewModels.Find>)sender;
            this.view.FindCrud.Add((System.Windows.Forms.Form)view, new FindMapper(), form: addForm, findsClass: findsClass);
        }

        private void FindCrud_GetFullFindInfo(object sender, Tools.EventArgs.FindInfoEventArgs e)
        {
            repository = new FindLocal(e.FilePath);

            Find find = GetFind(finds, e.Find.FieldNumber);
            AddBrandDataUI.ViewModels.Brand brand = null;
            if (find.Brand != null)
                brand = new(find.Brand.Clay, find.Brand.Admixture, find.Brand.Sprinkling, find.Brand.Safety, find.Brand.Relief, find.Brand.ReconstructionReliability);

            AddBrandDataUI.ViewModels.Find viewModelFind = new AddBrandDataUI.ViewModels.Find(find.FieldNumber, find.Formation, find.Square, find.Depth, find.CollectorsNumber,
                find.DatingLowerBound, find.DatingUpperBound, find.Description, find.Analogy, find.Note, find.Image, find.Photo, brand);
            view.FindCrud.Update((System.Windows.Forms.Form)view, new FindMapper(), viewModelFind, e.FindsClass);
        }

        private void FindCrud_DeleteExcavation(object sender, Tools.EventArgs.DeleteEventArgs<AddBrandDataUI.ViewModels.Find> e)
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

        private void FindCrud_GetClassificationId(object sender, Tools.EventArgs.GetIdEventArgs<AddBrandDataUI.ViewModels.Classification> e)
        {
            this.view.ClassificationCrud.GetId(e.BrandData);
        }

        private void FindCrud_AddExcavation(object sender, Tools.EventArgs.AddEventArgs<AddBrandDataUI.ViewModels.Find> e)
        {
            repository = new FindLocal(e.FilePath);

            Find find = new();
            find.Formation = e.BrandData.Formation;
            find.Square = e.BrandData.Square;
            find.Depth = e.BrandData.Depth;
            find.FieldNumber = e.BrandData.FieldNumber;
            find.CollectorsNumber = e.BrandData.CollectorsNumber;
            find.DatingLowerBound = e.BrandData.DatingLowerBound;
            find.DatingUpperBound = e.BrandData.DatingUpperBound;
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

        private void FindCrud_FillExcavationsList(object sender, Tools.EventArgs.FillEventArgs e)
        {
            repository = new FindLocal(e.FilePath);

            int parentId = view.SelectedParentId.Value;
            RefreshFinds(parentId);
        }

        private void RefreshFinds(int? id = null)
        {
            finds = repository.GetAll(id);

            view.BrandDataList = finds.Select(c => new { c.FieldNumber, c.CollectorsNumber, c.Formation, c.Square })
                                        .OrderBy(c => c.FieldNumber)
                                        .ToList();
        }
    }
}