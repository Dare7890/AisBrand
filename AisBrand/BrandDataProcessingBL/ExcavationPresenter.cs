using BrandDataProcessing;
using BrandDataProcessing.DAL;
using BrandDataProcessing.Models;
using System.Linq;

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
        }

        private void View_FillExcavationsList(object sender, FillExcavationsEventArgs e)
        {
            repository = new ExcavationLocal(e.FilePath);
            RefreshExcavationsList();
        }

        private void RefreshExcavationsList()
        {
            view.CustomerList = repository.GetAll().ToList();
        }
    }
}
