using System;
using System.Collections.Generic;
using System.Linq;
using BrandDataProcessing;
using BrandDataProcessing.DAL;
using BrandDataProcessing.Models;
using BrandDataProcessingBL.EventArgs;

namespace BrandDataProcessingBL
{
    public class ExcavationPresenter
    {
        private IRepository<Excavation> repository;
        private readonly ISearchView view;

        private IEnumerable<Excavation> excavations;

        public ExcavationPresenter(ISearchView view)
        {
            this.view = view;
            this.view.FillExcavationsList += View_FillExcavationsList;
            this.view.DeleteExcavation += View_DeleteExcavation;
            this.view.AddExcavation += View_AddExcavation;
            this.view.UpdateExcavation += View_UpdateExcavation;
        }

        private void View_UpdateExcavation(object sender, UpdateExcavationEventArgs e)
        {
            repository = new ExcavationLocal(e.FilePath);
            Excavation updatedExcavation = GetExcavation(excavations, e.SourceExcavation.Name, e.SourceExcavation.Monument);

            //  TODO: create mapper.
            updatedExcavation.Name = e.UpdatedExcavation.Name;
            updatedExcavation.Monument = e.UpdatedExcavation.Monument;

            repository.Update(updatedExcavation);
            RefreshExcavationsList();
        }

        private void View_AddExcavation(object sender, AddExcavationEventArgs e)
        {
            repository = new ExcavationLocal(e.FilePath);

            Excavation excavation = new Excavation();
            excavation.Name = e.Excavation.Name;
            excavation.Monument = e.Excavation.Monument;

            repository.Add(excavation);
            RefreshExcavationsList();
        }

        private void View_DeleteExcavation(object sender, DeleteExcavationEventArgs e)
        {
            repository = new ExcavationLocal(e.FilePath);
            int deletedId = GetExcavationId(excavations, e.DeletedExcavation.Name, e.DeletedExcavation.Monument);
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
            excavations = repository.GetAll();

            view.BrandDataList = excavations.Select(e => new { e.Name, e.Monument })
                                            .ToList();
        }
    }
}
