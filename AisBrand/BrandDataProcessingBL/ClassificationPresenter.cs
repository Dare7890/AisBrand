using BrandDataProcessing;
using BrandDataProcessing.DAL;
using BrandDataProcessing.Models;
using System.Collections.Generic;
using System.Linq;
using Tools;
using Tools.EventArgs;

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
                                                .ToList();
        }
    }
}
