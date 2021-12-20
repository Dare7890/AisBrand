using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddBrandDataUI.ViewModels
{
    public class Classification
    {
        public string FindsClass { get; }

        public int FindsAmount { get; }

        public Classification(string findsClass, int findsAmount)
        {
            FindsClass = findsClass;
            FindsAmount = findsAmount;
        }
    }
}
