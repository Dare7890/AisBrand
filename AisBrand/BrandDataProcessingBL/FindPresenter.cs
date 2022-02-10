﻿using System.Linq;
using BrandDataProcessing;
using BrandDataProcessing.DAL;
using System.Collections.Generic;
using BrandDataProcessing.Models;
using Tools;
using System;

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

            if (!view.SelectedParentId.HasValue)
                throw new ArgumentNullException("Add error. Parent id is null");

            CheckOnSameFind(find);

            int parentId = view.SelectedParentId.Value;
            repository.Add(find, parentId);
            RefreshFinds(parentId);
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
