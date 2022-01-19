using AddBrandDataUI;
using AddBrandDataUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tools.EventArgs;
using Tools.Map;

namespace Tools.CrudView
{
    public class BrandDataCrud<T> where T : class
    {
        public event EventHandler<FillEventArgs> FillExcavationsList;
        public event EventHandler<DeleteEventArgs<T>> DeleteExcavation;
        public event EventHandler<AddEventArgs<T>> AddExcavation;
        public event EventHandler<UpdateEventArgs<T>> UpdateExcavation;
        public event EventHandler<GetIdEventArgs<T>> GetIdExcavation;

        public string FilePath { get; set; }

        public BrandDataCrud() { }

        public void Add(Form owner, IMapper<T> mapper, IEnumerable<string> types = null)
        {
            if (FilePath == null)
                return;

            using (AddBrandDataForm<T> form = new AddBrandDataForm<T>(types: types))
            {
                if (form.ShowDialog(owner) == DialogResult.OK)
                {
                    T brandData = mapper.Map(form);
                    if (AddExcavation != null)
                        AddExcavation.Invoke(this, new AddEventArgs<T>(FilePath, brandData));
                }

                form.Close();
            }
        }

        public virtual void Update(Form owner, IMapper<T> mapper, T sourceData)
        {
            if (FilePath == null)
                return;
            //TODO: переделать связывание через фреймворк.
            using (AddBrandDataForm<T> form = new AddBrandDataForm<T>(sourceData))
            {
                if (form.ShowDialog(owner) == DialogResult.OK)
                {
                    T updatedData = mapper.Map(form);
                    if (UpdateExcavation != null)
                        UpdateExcavation.Invoke(this, new UpdateEventArgs<T>(FilePath, sourceData, updatedData));
                }

                form.Close();
            }
        }

        public void Delete(T deletedData)
        {
            if (FilePath == null)
                return;

            if (DeleteExcavation != null)
                DeleteExcavation.Invoke(this, new DeleteEventArgs<T>(FilePath, deletedData));
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
