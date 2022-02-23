using System;
using System.Text.RegularExpressions;
using System.Linq;
using BrandDataProcessing.Models;

namespace BrandDataProcessing
{
    public static class Parser
    {
        private const int oneDateBoundaryAmount = 1;
        private const int twoDateBoundaryAmount = 2;
        private const int maxDateBoundaryAmount = 2;
        private const int minDateBoundaryPartsAmount = 3;

        private const int firstDateBoundaryIndex = 0;

        private const int halfCenturyNumberIndex = 0;
        private const int halfCenturyIndex = 1;

        private const int yearIndex = 0;
        private const int periodIndex = 1;
        private const int BCDeterminantIndex = 2;

        private const char dateBoundaryLineSeparator = ' ';
        private const char dateBoundaryRangeSeparator = '-';

        private const string BCDeterminant = "до";
        private const string halfCenturyText = "пол.";

        private const string centuryText = "в.";
        private const string millenniumText = "тыс.";

        private const int halfCentury = 50;
        private const int lastCenturyYear = 100;
        private const int halfMillennium = 500;
        private const int lastMillenniumYear = 1000;

        private const int firstHalfCenturyNumber = 1;
        private const int secondHalfCenturyNumber = 2;

        public static DatingBound Parse(string line)
        {
            if (line == null)
                throw new ArgumentNullException(nameof(line));

            if (string.IsNullOrEmpty(line))
                return null;

            string[] lineParts = line.Split(dateBoundaryRangeSeparator);

            int dateBoundaryAmount = lineParts.Length;
            if (dateBoundaryAmount > maxDateBoundaryAmount)
            {
                string exceptionMessage = string.Format("The date boundary amount must be {0} or {1}. Current date boundary amount is {2}", oneDateBoundaryAmount, twoDateBoundaryAmount, dateBoundaryAmount);
                throw new FormatException(exceptionMessage);
            }

            int secondDateBoundaryIndex = dateBoundaryAmount - 1;
            DatingBound datingBound = new DatingBound(line);
            datingBound.DatingLowerBound = ParseDateBoundary(lineParts[firstDateBoundaryIndex]);
            datingBound.DatingUpperBound = ParseDateBoundary(lineParts[secondDateBoundaryIndex], false);
            ValidationDateBound(datingBound.DatingLowerBound, datingBound.DatingUpperBound);

            return datingBound;
        }

        private static void ValidationDateBound(int datingLowerBound, int datingUpperBound)
        {
            if (datingLowerBound > datingUpperBound)
            {
                string exceptionMessage = string.Format("The lower bound must be less or equal than upper bound. Lower bound is {0}. Upper bound is {1}", datingLowerBound, datingUpperBound);
                throw new ArgumentException(exceptionMessage);
            }
        }

        private static int ParseDateBoundary(string dateBoundaryLine, bool isFirstDateBoundary = true)
        {
            string[] dateBoundaryLineParts = dateBoundaryLine.TrimStart().TrimEnd().Split(dateBoundaryLineSeparator);

            if (dateBoundaryLineParts.Length < minDateBoundaryPartsAmount)
                throw new FormatException($"Date format is incorrect. Minimum parts amount is {minDateBoundaryPartsAmount}");

            int? halfCenturyNumber = null;
            if (dateBoundaryLineParts[halfCenturyIndex] == halfCenturyText)
            {
                string halfCenturyNumberLine = dateBoundaryLineParts[halfCenturyNumberIndex];
                halfCenturyNumber = ParseHalfCenturyNumber(halfCenturyNumberLine);
                dateBoundaryLineParts = ExtractWholeDateBoundary(dateBoundaryLineParts);
            }

            return ParseWholeDateBoundary(isFirstDateBoundary, dateBoundaryLineParts, halfCenturyNumber);
        }

        private static int TakeIntoAccountPeriodHalf(bool isFirstDateBoundary, int halfNumber, int half, int wholeDateBoundary, bool isBC)
        {
            if (halfNumber == firstHalfCenturyNumber && !isFirstDateBoundary && isBC || halfNumber == secondHalfCenturyNumber && isFirstDateBoundary && !isBC)
                wholeDateBoundary += half;
            else if (halfNumber == secondHalfCenturyNumber && isFirstDateBoundary && isBC || halfNumber == firstHalfCenturyNumber && !isFirstDateBoundary && !isBC)
                wholeDateBoundary -= half;

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

        private static int ParseWholeDateBoundary(bool isFirstDateBoundary, string[] dateBoundaryLineParts, int? halfNumber = null)
        {
            string yearValue = dateBoundaryLineParts[yearIndex];
            bool isBc = dateBoundaryLineParts[BCDeterminantIndex] == BCDeterminant;
            int year;
            if (IsRomanNumerals(yearValue))
            {
                string period = dateBoundaryLineParts[periodIndex];
                int lastYear;
                int halfPeriod;
                switch (period)
                {
                    case millenniumText:
                        year = ParseMillenniumByRomanNumerals(yearValue);
                        lastYear = lastMillenniumYear;
                        halfPeriod = halfMillennium;
                        break;
                    case centuryText:
                        year = ParseYearByRomanNumerals(yearValue);
                        lastYear = lastCenturyYear;
                        halfPeriod = halfCentury;
                        break;
                    default:
                        throw new InvalidOperationException("Incorrect name of period. Must be \"тыс.\" or \"в.\"");
                }

                if (!isFirstDateBoundary && isBc || isFirstDateBoundary && !isBc)
                    year = ConvertToPeriodBeginning(year, lastYear);

                if (halfNumber.HasValue)
                    year = TakeIntoAccountPeriodHalf(isFirstDateBoundary, halfNumber.Value, halfPeriod, year, isBc);
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

        private static int ConvertToPeriodBeginning(int year, int lastPeriodAge)
        {
            return year -= lastPeriodAge;
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

            if (year > maxYear)
            {
                string exceptionMessage = string.Format("The year {0} must be less than {1}", year, maxYear);
                throw new FormatException(exceptionMessage);
            }
        }

        private static bool InputInteger(string line, out int value)
        {
            return int.TryParse(line, out value);
        }

        private static int ParseYearByRomanNumerals(string romanNumber)
        {
            int century = ParseCenturyByRomanNumerals(romanNumber);

            return century * lastCenturyYear;
        }

        private static int ParseMillenniumByRomanNumerals(string romanNumber)
        {
            int century = ParseCenturyByRomanNumerals(romanNumber);

            return century * lastMillenniumYear;
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
                int number = EnumParse(romanNumber[i].ToString());
                if (number >= EnumParse(romanNumber[i + 1].ToString()))
                    arabicNumber += number;
                else
                    arabicNumber -= number;
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
