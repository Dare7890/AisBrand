using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AddBrandDataUI;
using AddBrandDataUI.ViewModels;
using Tools.EventArgs;
using Tools.Map;

namespace Tools.CrudView
{
    public class ExcavationCrud : BrandDataCrud<Excavation>
    {
        public List<string> ExistingMonuments { get; set; }

        public event EventHandler<System.EventArgs> GetMonuments;
        public event EventHandler<System.EventArgs> GetAllExcavations;
        public event EventHandler<AddEventArgs<Excavation>> AddEmptyExcavation;

        public ExcavationCrud()
        {
            ExistingMonuments = new List<string>();
        }

        public void OnGetMonuments()
        {
            if (FilePath == null)
                return;

            if (GetMonuments != null)
                GetMonuments.Invoke(this, new System.EventArgs());
        }

        public void OnGetAllExcavations()
        {
            if (FilePath == null)
                return;

            if (GetAllExcavations != null)
                GetAllExcavations.Invoke(this, new System.EventArgs());
        }

        public override void Add(Form owner, IMapper<Excavation> mapper, IEnumerable<string> types = null, BrandDataProcessing.Models.FindsClass findsClass = null)
        {
            OnGetMonuments();

            if (FilePath == null)
                return;

            using (AddBrandDataForm<Excavation> form = new AddBrandDataForm<Excavation>(types: ExistingMonuments, parent: findsClass))
            {
                if (form.ShowDialog(owner) == DialogResult.OK)
                {
                    try
                    {
                        Excavation excavation = mapper.Map(form);

                        if (form.IsCopyData())
                            OnAdd(excavation);
                        else
                            OnAddOnlyExcavation(excavation);
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

        protected void OnAddOnlyExcavation(Excavation excavation, int? parentId = null)
        {
            if (AddEmptyExcavation != null)
                AddEmptyExcavation.Invoke(this, new AddEventArgs<Excavation>(FilePath, excavation, parentId));
        }

        public override void Update(Form owner, IMapper<Excavation> mapper, Excavation sourceData)
        {
            if (FilePath == null)
                return;

            OnGetMonuments();
            using (AddBrandDataForm<Excavation> form = new AddBrandDataForm<Excavation>(sourceData, ExistingMonuments))
                Update(owner, mapper, sourceData, form);
        }
    }
}
