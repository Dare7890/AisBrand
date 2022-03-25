using System;
using System.Collections.Generic;
using System.Linq;
using BrandDataProcessing;
using BrandDataProcessing.DAL;
using BrandDataProcessing.Models;
using GenericFilters;
using Tools;
using Tools.EventArgs;

namespace BrandDataProcessingBL
{
    public class ExcavationPresenter : IPresenter
    {
        private IRepository<Excavation> repository;
        private readonly ISearchView view;

        private IEnumerable<Excavation> excavations;

        private IClassificationsRetriever classificationsRetriever;

        public ExcavationPresenter(ISearchView view, IClassificationsRetriever classificationsRetriever)
        {
            this.view = view;
            this.view.ExcavationCrud.FillExcavationsList += View_FillExcavationsList;
            this.view.ExcavationCrud.DeleteExcavation += View_DeleteExcavation;
            this.view.ExcavationCrud.AddExcavation += View_AddExcavation;
            this.view.ExcavationCrud.UpdateExcavation += View_UpdateExcavation;
            this.view.ExcavationCrud.GetIdExcavation += ExcavationCrud_GetIdExcavation;
            this.view.ExcavationCrud.GetMonuments += ExcavationCrud_GetMonuments;
            this.view.ExcavationCrud.GetAllExcavations += ExcavationCrud_GetAllExcavations;
            this.view.ExcavationCrud.AddEmptyExcavation += ExcavationCrud_AddOnlyExcavation;
            this.view.ExcavationCrud.GetExcavationsByViewModel += ExcavationCrud_GetExcavationsByViewModel; ;
            this.view.ExcavationCrud.Filter += ExcavationCrud_Filter;

            this.classificationsRetriever = classificationsRetriever;
        }

        private void ExcavationCrud_GetExcavationsByViewModel(object sender, GetExcavationsEventArgs e)
        {
            IEnumerable<Excavation> excavations = GetExcavationByViewModel(e.ViewModelExcavations);
            this.view.ExcavationCrud.Excavations = new List<Excavation>(excavations);
        }

        private IEnumerable<Excavation> GetExcavationByViewModel(IEnumerable<AddBrandDataUI.ViewModels.Excavation> viewModelExcavations)
        {
            return viewModelExcavations.Select(e => GetExcavation(excavations, e.Name, e.Monument));
        }

        private void ExcavationCrud_Filter(object sender, FilterEventArgs<AddBrandDataUI.ViewModels.Excavation> e)
        {
            GenericFilter<Excavation> genericFilter = new();
            IEnumerable<Excavation> filteredExcavations = genericFilter.CheckStartsWith(excavations, e.Property, e.Text);
            RefreshBrandDataList(filteredExcavations);
        }

        private void ExcavationCrud_AddOnlyExcavation(object sender, AddEventArgs<AddBrandDataUI.ViewModels.Excavation> e)
        {
            repository = new ExcavationLocal(e.FilePath);
            Excavation excavation = Map(e.BrandData);
            CheckOnSameExcavation(excavation);

            repository.Add(excavation);
            RefreshExcavationsList();
        }

        private static Excavation Map(AddBrandDataUI.ViewModels.Excavation viewModelExcavation)
        {
            Excavation excavation = new();
            excavation.Name = viewModelExcavation.Name;
            excavation.Monument = viewModelExcavation.Monument;

            return excavation;
        }

        private void ExcavationCrud_GetAllExcavations(object sender, EventArgs e)
        {
            view.AllExcavations = repository.GetAll(null);
        }

        private void ExcavationCrud_GetMonuments(object sender, EventArgs e)
        {
            List<string> monuments = excavations?.Select(e => e.Monument)
                                                .Distinct()
                                                .ToList();

            this.view.ExcavationCrud.ExistingMonuments = monuments == null ? Enumerable.Empty<string>().ToList() : new List<string>(monuments);
        }

        private void ExcavationCrud_GetIdExcavation(object sender, GetIdEventArgs<AddBrandDataUI.ViewModels.Excavation> e)
        {
            repository = new ExcavationLocal(e.FilePath);
            view.SelectedParentId = GetExcavationId(excavations, e.BrandData.Name, e.BrandData.Monument);
        }

        private void View_UpdateExcavation(object sender, UpdateEventArgs<AddBrandDataUI.ViewModels.Excavation> e)
        {
            repository = new ExcavationLocal(e.FilePath);
            Excavation updatedExcavation = new Excavation(GetExcavation(excavations, e.SourceBrandData.Name, e.SourceBrandData.Monument));

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

            Excavation excavation = Map(e.BrandData);
            CheckOnSameExcavation(excavation);

            excavation.FindsClasses = RetrieveFindClassesByMonuments(excavation.Monument);
            RetrieveClassificationsByMonuments(excavation.FindsClasses, excavation.Monument);

            repository.Add(excavation);
            RefreshExcavationsList();
        }

        private void RetrieveClassificationsByMonuments(List<FindsClass> findsClasses, string monument)
        {
            IEnumerable<Classification> classifications;
            int id = GetEnableClassificationId(excavations);
            foreach (FindsClass findsClass in findsClasses)
                classifications = classificationsRetriever.RetrieveFindsClassClassifications(excavations, monument, ref id, findsClass);
        }

        private List<FindsClass> RetrieveFindClassesByMonuments(string monument)
        {
            List<FindsClass> findsClasses = new List<FindsClass>();
            IEnumerable<string> allClasses = GetClassesByMonuments(excavations, monument);
            int id = GetEnableFindsClassesId(excavations);
            foreach (string className in allClasses)
            {
                FindsClass findsClass = new FindsClass();
                findsClass.Class = className;
                findsClass.ID = id;
                findsClasses.Add(findsClass);

                id++;
            }

            return findsClasses;
        }

        private static int GetEnableFindsClassesId(IEnumerable<Excavation> excavations)
        {
            IEnumerable<FindsClass> findsClasses = GetFindsClasses(excavations);
            return GetEnableId(findsClasses);
        }

        private int GetEnableClassificationId(IEnumerable<Excavation> excavations)
        {
            IEnumerable<FindsClass> findsClasses = GetFindsClasses(excavations);
            IEnumerable<Classification> classifications = classificationsRetriever.GetClassifications(findsClasses);
            return GetEnableId(classifications);
        }

        private static int GetEnableId(IEnumerable<IIdentifier> collection)
        {
            return collection.Max(c => c.ID) + 1;
        }

        private static IEnumerable<FindsClass> GetFindsClasses(IEnumerable<Excavation> excavations)
        {
            return excavations.SelectMany(e => e.FindsClasses);
        }

        private IEnumerable<string> GetClassesByMonuments(IEnumerable<Excavation> excavations, string monument)
        {
            return excavations.Where(m => m.Monument == monument)
                            .SelectMany(f => f.FindsClasses)
                            .Select(f => f.Class)
                            .Distinct();
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
            FillPropertiesList();
        }

        private void FillPropertiesList()
        {
            view.Properties = PropertiesRetriever.Excavation.Retrieve();
        }

        private void RefreshExcavationsList()
        {
            excavations = repository.GetAll(null);
            RefreshBrandDataList(excavations);
        }

        private void RefreshBrandDataList(IEnumerable<Excavation> excavations)
        {
            view.BrandDataList = excavations.Select(e => new {e.Monument,e.Name,findsAmount = e.FindsClasses?.SelectMany(f => f?.Classifications)
                                                                                                                .SelectMany(c => c?.Finds)?
                                                                                                                .Count() ?? 0})
                                            .OrderBy(e => e.Monument)
                                            .ThenBy(e => e.Name)
                                            .ToList();
        }
    }
}
