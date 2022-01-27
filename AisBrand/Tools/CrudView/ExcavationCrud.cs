﻿using AddBrandDataUI;
using AddBrandDataUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tools.Map;

namespace Tools.CrudView
{
    public class ExcavationCrud : BrandDataCrud<Excavation>
    {
        public List<string> ExistingMonuments { get; set; }

        public event EventHandler<System.EventArgs> GetMonuments;

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
