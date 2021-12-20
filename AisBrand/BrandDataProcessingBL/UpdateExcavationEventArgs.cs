using System;
using AddBrandDataUI.ViewModels;

namespace BrandDataProcessingBL
{
    public class UpdateExcavationEventArgs : EventArgs
    {
        public string FilePath { get; set; }

        public Excavation SourceExcavation { get; set; }

        public Excavation UpdatedExcavation { get; set; }

        public UpdateExcavationEventArgs(string filePath, Excavation sourceExcavation, Excavation updatedExcavation)
        {
            FilePath = filePath;
            SourceExcavation = sourceExcavation;
            UpdatedExcavation = updatedExcavation;
        }
    }
}
