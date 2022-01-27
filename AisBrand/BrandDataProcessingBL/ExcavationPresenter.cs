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
    public class ExcavationPresenter : IPresenter
    {
        private IRepository<Excavation> repository;
        private readonly ISearchView view;

        private IEnumerable<Excavation> excavations;

        public ExcavationPresenter(ISearchView view)
        {
            this.view = view;
            this.view.ExcavationCrud.FillExcavationsList += View_FillExcavationsList;
            this.view.ExcavationCrud.DeleteExcavation += View_DeleteExcavation;
            this.view.ExcavationCrud.AddExcavation += View_AddExcavation;
            this.view.ExcavationCrud.UpdateExcavation += View_UpdateExcavation;
            this.view.ExcavationCrud.GetIdExcavation += ExcavationCrud_GetIdExcavation;
        }

        private void ExcavationCrud_GetIdExcavation(object sender, GetIdEventArgs<AddBrandDataUI.ViewModels.Excavation> e)
        {
            repository = new ExcavationLocal(e.FilePath);
            view.SelectedParentId = GetExcavationId(excavations, e.BrandData.Name, e.BrandData.Monument);
        }

        private void View_UpdateExcavation(object sender, UpdateEventArgs<AddBrandDataUI.ViewModels.Excavation> e)
        {
            repository = new ExcavationLocal(e.FilePath);
            Excavation updatedExcavation = GetExcavation(excavations, e.SourceBrandData.Name, e.SourceBrandData.Monument);

            //  TODO: create mapper.
            updatedExcavation.Name = e.UpdatedBrandData.Name;
            updatedExcavation.Monument = e.UpdatedBrandData.Monument;
            CheckOnSameExcavation(updatedExcavation);

            repository.Update(updatedExcavation);
            RefreshExcavationsList();
        }

        private void View_AddExcavation(object sender, AddEventArgs<AddBrandDataUI.ViewModels.Excavation> e)
        {
            repository = new ExcavationLocal(e.FilePath);

            Excavation excavation = new Excavation();
            excavation.Name = e.BrandData.Name;
            excavation.Monument = e.BrandData.Monument;
            CheckOnSameExcavation(excavation);

            repository.Add(excavation);
            RefreshExcavationsList();
        }

        private void CheckOnSameExcavation(Excavation excavation)
        {
            if (HasSameExcavation(excavations, excavation))
                throw new InvalidOperationException("This excavation already exists");
        }

        private bool HasSameExcavation(IEnumerable<Excavation> excavations, Excavation searchedExcavation)
        {
            Excavation sameExcavation = excavations.FirstOrDefault(e => e.Name == searchedExcavation.Name && e.Monument == searchedExcavation.Monument);
            return sameExcavation != null;
        }

        private void View_DeleteExcavation(object sender, DeleteEventArgs<AddBrandDataUI.ViewModels.Excavation> e)
        {
            repository = new ExcavationLocal(e.FilePath);
            int deletedId = GetExcavationId(excavations, e.DeletedBrandData.Name, e.DeletedBrandData.Monument);
            repository.Delete(deletedId);
            RefreshExcavationsList();
        }

        private Excavation GetExcavation(IEnumerable<Excavation> excavations, string deletedName, string deletedMonument)
        {
            return excavations.SingleOrDefault(e => e.Name == deletedName && e.Monument == deletedMonument);
        }

        private int GetExcavationId(IEnumerable<Excavation> excavations, string deletedName, string deletedMonument)
        {
            return GetExcavation(excavations, deletedName, deletedMonument).ID;
        }

        private void View_FillExcavationsList(object sender, FillEventArgs e)
        {
            repository = new ExcavationLocal(e.FilePath);
            RefreshExcavationsList();
        }

        private void RefreshExcavationsList()
        {
            excavations = repository.GetAll(null);

            view.BrandDataList = excavations.Select(e => new { e.Name, e.Monument, e.FindsClasses.Count })
                                            .ToList();
        }
    }
}
