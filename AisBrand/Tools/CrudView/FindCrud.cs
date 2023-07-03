using AddBrandDataUI;
using AddBrandDataUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tools.EventArgs;
using Tools.Map;

namespace Tools.CrudView
{
    public class FindCrud : BrandDataCrud<Find>
    {
        public int ClassificationId { get; set; }

        public string AddedFieldNumber { get; set; }

        public event EventHandler<GetIdEventArgs<Classification>> GetClassificationId;
        public event EventHandler<FindInfoEventArgs> UpdateByViewModel;
        public event EventHandler<FindInfoEventArgs> AddByViewModel;

        public override void Add(Form owner, IMapper<Find> mapper, IEnumerable<string> types = null, BrandDataProcessing.Models.FindsClass findsClass = null)
        {
            if (FilePath == null)
                return;

            using (AddBrandDataForm<Find> form = new AddBrandDataForm<Find>(types: types, parent: findsClass))
            {
                if (form.ShowDialog(owner) == DialogResult.OK)
                    Add(owner, mapper, form, types, findsClass);

                form.Close();
            }
        }

        public void Add(Form owner, IMapper<Find> mapper, AddBrandDataForm<Find> form, IEnumerable<string> types = null, BrandDataProcessing.Models.FindsClass findsClass = null)
        {
            try
            {
                Find find = mapper.Map(form);
                GetParentClassificationId(form);
                OnAdd(find, ClassificationId);
            }
            catch (InvalidOperationException)
            {
                NotifyAboutExistsSameExcavation();
                Add(owner, mapper, form, types, findsClass);
            }
        }

        private void GetParentClassificationId(AddBrandDataForm<Find> form)
        {
            Classification classification = form.GetParentClassification();
            OnGetClassificationId(classification);
        }

        protected virtual void OnGetClassificationId(Classification classification)
        {
            if (GetClassificationId != null)
                GetClassificationId.Invoke(this, new GetIdEventArgs<Classification>(FilePath, classification));
        }

        public void OnGetFullFindInfo(Find find, BrandDataProcessing.Models.FindsClass findsClas)
        {
            if (FilePath == null)
                return;

            if (UpdateByViewModel != null)
                UpdateByViewModel.Invoke(this, new FindInfoEventArgs(FilePath, find, findsClas));
        }

        public virtual void Update(Form owner, IMapper<Find> mapper, Find find, BrandDataProcessing.Models.FindsClass findsClass)
        {
            if (FilePath == null)
                return;

            using (AddBrandDataForm<Find> form = new AddBrandDataForm<Find>(find, parent: findsClass))
                base.Update(owner, mapper, find, form);
        }

        public void Copy(Find find, BrandDataProcessing.Models.FindsClass parentFindsClass)
        {
            using (AddNumberFieldForm form = new())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string fieldNumber = form.FieldNumber;
                    OnAddByViewModel(FilePath, find, parentFindsClass, fieldNumber);


                    // TODO: создать новое событие с eventargs, принимающим новый fieldNumber, где сначала будет вызываться 2 метода для поиска
                    // типа и подтипа классификации, затем вызываться событие поиска id по классификации viewmodel, а затем вызываться метод OnAdd класса FindCrud.
                }
            }
        }

        public IEnumerable<string> GetPropertyItems(BrandDataProcessing.Models.FindsClass findsClass, string propertyName)
        {
            using (AddBrandDataForm<Find> form = new AddBrandDataForm<Find>(null, parent: findsClass))
            {
                return form.GetPropertyItems(propertyName);
            }
        }

        protected virtual void OnAddByViewModel(string filePath, Find find, BrandDataProcessing.Models.FindsClass findsClass, string fieldNumber)
        {
            if (AddByViewModel != null)
                AddByViewModel.Invoke(this, new FindInfoEventArgs(filePath, find, findsClass, fieldNumber));
        }
    }
}
