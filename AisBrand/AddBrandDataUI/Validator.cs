using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddBrandDataUI
{
    public static class Validator
    {
        public static class Excavation
        {
            public static bool ValidName(string name, out string errorMessage)
            {
                errorMessage = "";
                if (name.Length == 0)
                {
                    errorMessage = "Заполните поле";
                    return false;
                }

                return true;
            }
        }
    }
}
