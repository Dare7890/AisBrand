using AddBrandDataUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tools.EventArgs;
using Tools.Map;

namespace Tools.CrudView
{
    public class ClassificationCrud : BrandDataCrud<Classification>
    {
        public event EventHandler<FillClassificationEventArgs> FillClassificationInfo;

        public void Fill(Classification classification)
        {
            if (FilePath == null)
                return;

            if (FillClassificationInfo != null)
                FillClassificationInfo.Invoke(this, new FillClassificationEventArgs(FilePath, classification.Type, classification.Variant));
        }

        public override void Update(Form owner, IMapper<Classification> mapper, Classification sourceData)
        {
            base.Update(owner, mapper, sourceData);
        }
    }
}
