using BrandDataProcessing;
using System;

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

        public static class Find
        {
            public static bool ValidSquare(string square, out string errorMessage)
            {
                if (square == "")
                {
                    errorMessage = "";
                    return true;
                }

                if (!IsInteger(square, out int squareInt, out errorMessage))
                    return false;

                if (!IsPositive(squareInt, out errorMessage))
                    return false;

                return true;
            }

            public static bool ValidDepth(string depth, out string errorMessage)
            {
                if (depth == "")
                {
                    errorMessage = "";
                    return true;
                }

                if (!IsInteger(depth, out int depthInt, out errorMessage))
                    return false;

                if (!IsPositive(depthInt, out errorMessage))
                    return false;

                return true;
            }

            public static bool ValidFieldNumber(string fieldNumber, out string errorMessage)
            {
                if (IsEmpty(fieldNumber, out errorMessage))
                    return false;

                return true;
            }

            public static bool ValidDating(string dating, out string errorMessage)
            {
                errorMessage = "";
                if (dating == string.Empty)
                    return true;

                try
                {
                    Parser.Parse(dating);
                    return true;
                }
                catch (Exception e)
                {
                    if (e is ArgumentNullException || e is InvalidOperationException || e is ArgumentException || e is FormatException)
                    {
                        errorMessage = e.Message;
                        return false;
                    }

                    errorMessage = "Incorrect value of dating";
                    return false;
                }
            }
        }

        private static bool IsInteger(string value, out int squareInt, out string errorMessage)
        {
            errorMessage = "";
            if (!int.TryParse(value, out squareInt))
            {
                errorMessage = "Значение не является числом!";
                return false;
            }

            return true;
        }

        private static bool IsPositive(int square, out string errorMessage)
        {
            errorMessage = "";
            const int minValue = 1;
            if (square < minValue)
            {
                errorMessage = string.Format($"Номер квадрата не должен быть меньше {minValue}");
                return false;
            }

            return true;
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
