using System.Collections.Generic;
using AddBrandDataUI.ViewModels;

namespace Tools.EventArgs
{
    public class GetExcavationsEventArgs : System.EventArgs
    {
        public IEnumerable<Excavation> ViewModelExcavations { get; set; }

        public GetExcavationsEventArgs(IEnumerable<Excavation> viewModelExcavations)
        {
            ViewModelExcavations = viewModelExcavations;
        }
    }
}
