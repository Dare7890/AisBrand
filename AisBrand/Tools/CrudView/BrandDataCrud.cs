using AddBrandDataUI;
using AddBrandDataUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tools.EventArgs;
using Tools.Map;

namespace Tools.CrudView
{
    public abstract class BrandDataCrud<T> where T : class
    {
        public event EventHandler<FillEventArgs> FillExcavationsList;
        public event EventHandler<DeleteEventArgs<T>> DeleteExcavation;
        public event EventHandler<AddEventArgs<T>> AddExcavation;
        public event EventHandler<UpdateEventArgs<T>> UpdateExcavation;
        public event EventHandler<GetIdEventArgs<T>> GetIdExcavation;

        public string FilePath { get; set; }

        public BrandDataCrud() { }

        public virtual void Add(Form owner, IMapper<T> mapper, IEnumerable<string> types = null, BrandDataProcessing.Models.FindsClass findsClass = null)
        {
            if (FilePath == null)
                return;

            using (AddBrandDataForm<T> form = new AddBrandDataForm<T>(types: types, parent: findsClass))
            {
                if (form.ShowDialog(owner) == DialogResult.OK)
                {
                    try
                    {
                        T brandData = mapper.Map(form);
                        OnAdd(brandData);
                    }
                    catch (InvalidOperationException)
                    {
                        NotifyAboutExistsSameExcavation();
                        Add(owner, mapper, types);
                    }
                }

                form.Close();
            }
        }

        public void Add(T data, int? parentId = null)
        {
            OnAdd(data, parentId);
        }

        protected virtual void OnAdd(T data, int? parentId = null)
        {
            if (AddExcavation != null)
                AddExcavation.Invoke(this, new AddEventArgs<T>(FilePath, data, parentId));
        }

        public virtual void Update(Form owner, IMapper<T> mapper, T sourceData)
        {
            if (FilePath == null)
                return;
            //TODO: переделать связывание через фреймворк.
            using (AddBrandDataForm<T> form = new AddBrandDataForm<T>(sourceData))
                Update(owner, mapper, sourceData, form);
        }

        protected void Update(Form owner, IMapper<T> mapper, T sourceData, AddBrandDataForm<T> form)
        {
            if (form.ShowDialog(owner) == DialogResult.OK)
            {
                try
                {
                    T updatedData = mapper.Map(form);
                    if (UpdateExcavation != null)
                        UpdateExcavation.Invoke(form, new UpdateEventArgs<T>(FilePath, sourceData, updatedData));
                }
                catch (InvalidOperationException)
                {
                    NotifyAboutExistsSameExcavation();
                    Update(owner, mapper, sourceData);
                }
            }

            form.Close();
        }

        protected static void NotifyAboutExistsSameExcavation()
        {
            MessageBox.Show("Такая запись уже существует.", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Delete(T deletedData)
        {
            if (FilePath == null)
                return;

            if (DeleteExcavation != null)
                DeleteExcavation.Invoke(this, new DeleteEventArgs<T>(FilePath, deletedData));
        }

        public void DeleteRange(List<T> data)
        {
            foreach (T element in data)
                Delete(element);
        }

        public void Fill()
        {
            if (FilePath == null)
                return;

            if (FillExcavationsList != null)
                FillExcavationsList.Invoke(this, new FillEventArgs(FilePath));
        }

        public void GetId(T viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(Excavation));

            if (GetIdExcavation != null)
                GetIdExcavation.Invoke(this, new GetIdEventArgs<T>(FilePath, viewModel));
        }
    }
}
