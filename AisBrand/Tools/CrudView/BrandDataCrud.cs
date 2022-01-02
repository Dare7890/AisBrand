using AddBrandDataUI;
using System;
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

        public string FilePath { get; set; }

        public BrandDataCrud() { }

        public void Add(Form owner, IMapper<T> mapper)
        {
            if (FilePath == null)
                return;

            using (AddBrandDataForm<T> form = new AddBrandDataForm<T>())
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

        public void Update(Form owner, IMapper<T> mapper, T sourceData)
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
    }
}
