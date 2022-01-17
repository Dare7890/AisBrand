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
                if (IsEmpty(name, out errorMessage))
                    return false;

                return true;
            }
        }

        public static class Classification
        {
            public static bool ValidType(string type, out string errorMessage)
            {
                if (IsEmpty(type, out errorMessage))
                    return false;

                return true;
            }
        }

        private static bool IsEmpty(string field, out string errorMessage)
        {
            errorMessage = "";
            if (field.Length == 0)
            {
                errorMessage = "Заполните поле";
                return true;
            }

            return false;
        }
    }
}
