using System;
using System.Collections.Generic;
using System.Linq;
using BrandDataProcessing;
using BrandDataProcessing.DAL;
using BrandDataProcessing.Models;
using BrandDataProcessingBL.EventArgs;

namespace BrandDataProcessingBL
{
    public class FindsClassPresenter
    {
        private IRepository<FindsClass> repository;
        private readonly ISearchView view;

        private IEnumerable<FindsClass> findsClasses;

        public FindsClassPresenter(ISearchView view)
        {
            this.view = view;
            this.view.FillFindsClassListEvent += View_FillExcavationsList;
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
