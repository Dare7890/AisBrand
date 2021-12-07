﻿using System;
using System.Linq;
using BrandDataProcessing;
using BrandDataProcessing.DAL;
using BrandDataProcessing.Models;

namespace BrandDataProcessingBL
{
    public class ExcavationPresenter
    {
        private IRepository<Excavation> repository;
        private readonly ISearchView view;

        public ExcavationPresenter(ISearchView view)
        {
            this.view = view;
            this.view.FillExcavationsList += View_FillExcavationsList;
            this.view.DeleteExcavation += View_DeleteExcavation;
            this.view.AddExcavation += View_AddExcavation;
        }

        private void View_AddExcavation(object sender, AddExcavationEventArgs e)
        {
            repository = new ExcavationLocal(e.FilePath);
            repository.Add(e.Excavation);
            RefreshExcavationsList();
        }

        private void View_DeleteExcavation(object sender, DeleteExcavationEventArgs e)
        {
            repository = new ExcavationLocal(e.FilePath);
            Excavation deletedExcavation = view.CustomerList.Where((ex, i) => i == e.DeletedLineIndex)
                                                            .FirstOrDefault();

            repository.Delete(deletedExcavation.ID);
            RefreshExcavationsList();
        }

        private void View_FillExcavationsList(object sender, FillExcavationsEventArgs e)
        {
            repository = new ExcavationLocal(e.FilePath);
            RefreshExcavationsList();
        }

        private void RefreshExcavationsList()
        {
            view.CustomerList = repository.GetAll()
                                        .ToList();
        }
    }
}
