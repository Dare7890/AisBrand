using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace BrandDataProcessing
{
    public static class Parser
    {
        private const int oneDateBoundaryAmount = 1;
        private const int twoDateBoundaryAmount = 2;

        private const int firstDateBoundaryIndex = 0;
        private const int secondDateBoundaryIndex = 1;

        private const int halfCenturyNumberIndex = 0;
        private const int halfCenturyIndex = 1;

        private const int yearIndex = 0;
        private const int periodIndex = 1;
        private const int BCDeterminantIndex = 2;

        private const char dateBoundaryLineSeparator = ' ';
        private const char dateBoundaryRangeSeparator = '-';

        private const string BCDeterminant = "до";
        private const string halfCenturyText = "пол.";

        private const int halfCentury = 50;
        private const int halfMillennium = 500;
        private const int firstHalfCenturyNumber = 1;
        private const int secondHalfCenturyNumber = 2;

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
                datingBound.DatingUpperBound = ParseDateBoundary(lineParts[firstDateBoundaryIndex], false);
                ValidationDateBound(datingBound.DatingLowerBound, datingBound.DatingUpperBound);

                return datingBound;
            }

            if (dateBoundaryAmount == twoDateBoundaryAmount)
            {
                datingBound.DatingLowerBound = ParseDateBoundary(lineParts[firstDateBoundaryIndex]);
                datingBound.DatingUpperBound = ParseDateBoundary(lineParts[secondDateBoundaryIndex], false);
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

        public static int ParseDateBoundary(string dateBoundaryLine, bool isFirstDateBoundary = true)
        {
            string[] dateBoundaryLineParts = dateBoundaryLine.TrimStart().TrimEnd().Split(dateBoundaryLineSeparator);
            string[] wholeDateBoundaryParts;
            if (dateBoundaryLineParts[halfCenturyIndex] == halfCenturyText)
            {
                string halfCenturyNumberLine = dateBoundaryLineParts[halfCenturyNumberIndex];
                int halfCenturyNumber = ParseHalfCenturyNumber(halfCenturyNumberLine);
                // TODO: Добавить строчку с вычислением тысячелетия и с проверкой.

                wholeDateBoundaryParts = ExtractWholeDateBoundary(dateBoundaryLineParts);
                int wholeDateBoundary = ParseWholeDateBoundary(isFirstDateBoundary, wholeDateBoundaryParts);
                return TakeIntoAccountCenturyHalf(isFirstDateBoundary, halfCenturyNumber, halfCentury, wholeDateBoundary);
            }

            return ParseWholeDateBoundary(isFirstDateBoundary, dateBoundaryLineParts);
        }

        private static int TakeIntoAccountCenturyHalf(bool isFirstDateBoundary, int halfNumber, int half, int wholeDateBoundary)
        {
            if (halfNumber == firstHalfCenturyNumber && !isFirstDateBoundary)
                wholeDateBoundary -= half;
            else if (halfNumber == secondHalfCenturyNumber && isFirstDateBoundary)
                wholeDateBoundary += half;

            return wholeDateBoundary;
        }

        private static string[] ExtractWholeDateBoundary(string[] dateBoundaryLineParts)
        {
            return dateBoundaryLineParts.Where((p, i) => i > 1).ToArray();
        }

        private static int ParseHalfCenturyNumber(string value)
        {
            if (!InputInteger(value, out int halfCenturyNumber))
            {
                string exceptionMessage = string.Format("The value {0} is not number", value);
                throw new FormatException(exceptionMessage);
            }

            ValidationHalfCenturyNumber(halfCenturyNumber);
            return halfCenturyNumber;
        }

        private static void ValidationHalfCenturyNumber(int halfCenturyNumber)
        {
            int maxHalfCenturyNumber = 3;
            int minHalfCenturyNumber = 0;

            if (halfCenturyNumber > maxHalfCenturyNumber || halfCenturyNumber < minHalfCenturyNumber)
            {
                string exceptionMessage = string.Format("The half century number {0} must be more than {1} and less than {2}", halfCenturyNumber, minHalfCenturyNumber, maxHalfCenturyNumber);
                throw new FormatException(exceptionMessage);
            }
        }

        private static int ParseWholeDateBoundary(bool isFirstDateBoundary, string[] dateBoundaryLineParts)
        {
            string yearValue = dateBoundaryLineParts[yearIndex];
            bool isBc = dateBoundaryLineParts[BCDeterminantIndex] == BCDeterminant;
            int year;
            if (IsRomanNumerals(yearValue))
            {
                string period = dateBoundaryLineParts[periodIndex];
                switch (period)
                {
                    case "тыс.":
                        year = ParseMillenniumByRomanNumerals(yearValue);
                        break;
                    case "в.":
                        year = ParseYearByRomanNumerals(yearValue);
                        break;
                    default:
                        throw new InvalidOperationException("Incorrect name of period. Must be \"тыс.\" or \"в.\"");
                }

                if (!isFirstDateBoundary && isBc || isFirstDateBoundary && !isBc)
                    year = ConvertToCenturyBeginning(year);
            }
            else
            {
                year = ParseYear(yearValue);
            }

            if (isBc)
                year = InvertYear(year);

            ValidationYear(year);
            return year;
        }

        private static int InvertYear(int year)
        {
            return year *= -1;
        }

        private static int ConvertToCenturyBeginning(int year)
        {
            return year -= 100;
        }

        private static bool IsRomanNumerals(string yearValue)
        {
            string romanNumeralsPattern = "^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
            return Regex.IsMatch(yearValue, romanNumeralsPattern);
        }

        private static int ParseYear(string value)
        {
            if (!InputInteger(value, out int year))
            {
                string exceptionMessage = string.Format("The value {0} is not year", value);
                throw new FormatException(exceptionMessage);
            }

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
            const int centuryNumber = 100;
            int century = ParseCenturyByRomanNumerals(romanNumber);

            return century * centuryNumber;
        }

        private static int ParseMillenniumByRomanNumerals(string romanNumber)
        {
            const int millenniumNumber = 1000;
            int century = ParseCenturyByRomanNumerals(romanNumber);

            return century * millenniumNumber;
        }

        private static int ParseCenturyByRomanNumerals(string romanNumber)
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

            return arabicNumber;
        }

        private static int EnumParse(string romanNumber)
        {
            return (int)Enum.Parse<RomanNumerals>(romanNumber);
        }
    }
}
