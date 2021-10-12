using System;

namespace BrandDataProcessing
{
    public static class Parser
    {
        private const int oneDateBoundaryAmount = 1;
        private const int twoDateBoundaryAmount = 2;

        private const int firstDateBoundaryIndex = 0;
        private const int secondDateBoundaryIndex = 1;

        private const int yearIndex = 0;
        private const int BCDeterminantIndex = 2;

        private const char dateBoundaryLineSeparator = ' ';
        private const char dateBoundaryRangeSeparator = '-';

        private const string BCDeterminant = "до";

        public static DatingBound Parse(string line)
        {
            if (line == null)
                throw new ArgumentNullException(nameof(line));

            if (string.IsNullOrEmpty(line))
                throw new FormatException("The line was empty");

            string[] lineParts = line.Split(dateBoundaryRangeSeparator);

            int dateBoundaryAmount = lineParts.Length;
            DatingBound datingBound = new DatingBound(line);

            // TODO : переписать.
            if (dateBoundaryAmount == oneDateBoundaryAmount)
            {
                datingBound.DatingLowerBound = ParseDateBoundary(lineParts[firstDateBoundaryIndex]);
                datingBound.DatingUpperBound = ParseDateBoundary(lineParts[firstDateBoundaryIndex]);
                ValidationDateBound(datingBound.DatingLowerBound, datingBound.DatingUpperBound);

                return datingBound;
            }

            if (dateBoundaryAmount == twoDateBoundaryAmount)
            {
                datingBound.DatingLowerBound = ParseDateBoundary(lineParts[firstDateBoundaryIndex]);
                datingBound.DatingUpperBound = ParseDateBoundary(lineParts[secondDateBoundaryIndex]);
                ValidationDateBound(datingBound.DatingLowerBound, datingBound.DatingUpperBound);

                return datingBound;
            }

            string exceptionMessage = string.Format("The date boundary amount must be {0} or {1}. Current date boundary amount is {2}", oneDateBoundaryAmount, twoDateBoundaryAmount, dateBoundaryAmount);
            throw new FormatException(exceptionMessage);
        }

        private static void ValidationDateBound(int datingLowerBound, int datingUpperBound)
        {
            if (datingLowerBound > datingUpperBound)
            {
                string exceptionMessage = string.Format("The lower bound must be less or equal than upper bound. Lower bound is {0}. Upper bound is {1}", datingLowerBound, datingUpperBound);
                throw new ArgumentException(exceptionMessage);
            }
        }

        public static int ParseDateBoundary(string dateBoundaryLine)
        {
            string[] dateBoundaryLineParts = dateBoundaryLine.TrimStart().TrimEnd().Split(dateBoundaryLineSeparator);

            string yearValue = dateBoundaryLineParts[yearIndex];
            int year = ParseYear(yearValue);

            return dateBoundaryLineParts[BCDeterminantIndex] == BCDeterminant ? year * (-1) : year;
        }

        private static int ParseYear(string value)
        {
            if (!InputInteger(value, out int year))
            {
                string exceptionMessage = string.Format("The value {0} is not year", value);
                throw new FormatException(exceptionMessage);
            }

            ValidationYear(year);
            return year;
        }

        private static void ValidationYear(int year)
        {
            int maxYear = DateTime.Now.Date.Year;
            int minYear = -5000;

            if (year > maxYear || year < minYear)
            {
                string exceptionMessage = string.Format("The year {0} must be more than {1} and less than {2}", year, minYear, maxYear);
                throw new FormatException(exceptionMessage);
            }
        }

        private static bool InputInteger(string line, out int value)
        {
            return int.TryParse(line, out value);
        }

        private static int ParseYearByRomanNumerals(string romanNumber)
        {
            int arabicNumber = 0;

            var orderRomanNumeral = Enum.GetValues(typeof(RomanNumerals));
            Array.Reverse(orderRomanNumeral);

            if (romanNumber.Length == 1)
                return EnumParse(romanNumber);

            for (int i = 0; i < romanNumber.Length - 1; i++)
            {
                if (EnumParse(romanNumber[i].ToString()) >= EnumParse(romanNumber[i + 1].ToString()))
                    arabicNumber += EnumParse(romanNumber[i].ToString());
                else
                    arabicNumber -= EnumParse(romanNumber[i].ToString());
            }

            arabicNumber += EnumParse(romanNumber[romanNumber.Length - 1].ToString());
            ValidationYear(arabicNumber);

            return arabicNumber;
        }

        private static int EnumParse(string romanNumber)
        {
            return (int)Enum.Parse<RomanNumerals>(romanNumber);
        }
    }
}
