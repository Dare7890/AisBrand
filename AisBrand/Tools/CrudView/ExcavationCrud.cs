using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<string> Classes { get; set; }
        public int ExcavationId { get; set; }

        public event EventHandler<System.EventArgs> GetMonuments;
        public event EventHandler<AddFindsClassEventArgs> AddFindsClass;

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

        public override void Add(Form owner, IMapper<Excavation> mapper, IEnumerable<string> types = null)
        {
            OnGetMonuments();
            base.Add(owner, mapper, ExistingMonuments);

            if (Classes.Any())
                OnAddFindsClass(FilePath, Classes, ExcavationId);
        }

        private void OnAddFindsClass(string filePath, IEnumerable<string> classes, int parentId)
        {
            if (AddFindsClass != null)
                AddFindsClass.Invoke(this, new AddFindsClassEventArgs(filePath, classes, parentId));
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
