using System;
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

        public FindsClassPresenter(ISearchView view)
        {
            this.view = view;
            this.view.FindsClassCrud.FillExcavationsList += View_FillExcavationsList;
            this.view.FindsClassCrud.AddExcavation += FindsClassCrud_AddExcavation;
            this.view.FindsClassCrud.UpdateExcavation += FindsClassCrud_UpdateExcavation;
            this.view.FindsClassCrud.DeleteExcavation += FindsClassCrud_DeleteExcavation;
        }

        private void FindsClassCrud_DeleteExcavation(object sender, DeleteEventArgs<AddBrandDataUI.ViewModels.FindsClass> e)
        {
            repository = new FindsClassLocal(e.FilePath);
            int id = GetFindsClassId(findsClasses, e.DeletedBrandData.Class);
            repository.Delete(id);
            RefreshExcavationsList();
        }

        private void FindsClassCrud_UpdateExcavation(object sender, UpdateEventArgs<AddBrandDataUI.ViewModels.FindsClass> e)
        {
            repository = new FindsClassLocal(e.FilePath);
            FindsClass findsClass = GetFindsClass(findsClasses, e.SourceBrandData.Class);

            //  TODO: create mapper.
            findsClass.Class = e.UpdatedBrandData.Class;

            repository.Update(findsClass);
            RefreshExcavationsList();
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

            repository.Add(findsClass);
            RefreshExcavationsList();
        }

        private void View_FillExcavationsList(object sender, FillEventArgs e)
        {
            repository = new FindsClassLocal(e.FilePath);
            RefreshExcavationsList();
        }

        private void RefreshExcavationsList()
        {
            findsClasses = repository.GetAll();

            view.BrandDataList = findsClasses.Select(c => new { c.Class, c.Classifications.Count})
                                            .ToList();
        }
    }
}
