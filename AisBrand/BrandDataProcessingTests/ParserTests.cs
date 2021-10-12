using System;
using System.Collections.Generic;
using NUnit.Framework;
using BrandDataProcessing;

namespace BrandDataProcessingTests
{
    [TestFixture]
    public class ParserTests
    {
        [TestCaseSource(nameof(ParsingDatingBoundCases))]
        public DatingBound TestParse(string line)
        {
            return Parser.Parse(line);
        }

        public static IEnumerable<TestCaseData> ParsingDatingBoundCases()
        {
            yield return new TestCaseData("1799 г. н.э").Returns(new DatingBound("1799 г. н.э") { DatingLowerBound = 1799, DatingUpperBound = 1799 });
            yield return new TestCaseData("1400 г. н.э - 1799 г. н.э").Returns(new DatingBound("1400 г. н.э - 1799 г. н.э") { DatingLowerBound = 1400, DatingUpperBound = 1799 });

            yield return new TestCaseData("2 пол. XV в. н.э - 1 пол. XVIII в. н.э").Returns(new DatingBound("2 пол. XV в. н.э - 1 пол. XVIII в. н.э") { DatingLowerBound = 1450, DatingUpperBound = 1750 });
            yield return new TestCaseData("2 пол. XVIII в. до н.э - 1 пол. XV в. до н.э").Returns(new DatingBound("2 пол. XVIII в. до н.э - 1 пол. XV в. до н.э") { DatingLowerBound = -1750, DatingUpperBound = -1450 });
            yield return new TestCaseData("1799 г. до н.э - 1400 г. до н.э").Returns(new DatingBound("1799 г. до н.э - 1400 г. до н.э") { DatingLowerBound = -1799, DatingUpperBound = -1400 });
            yield return new TestCaseData("XVIII в. до н.э - XV в. до н.э").Returns(new DatingBound("XVIII в. до н.э - XV в. до н.э") { DatingLowerBound = -1800, DatingUpperBound = -1400 });
            yield return new TestCaseData("XV в. н.э - XVIII в. н.э").Returns(new DatingBound("XV в. н.э - XVIII в. н.э") { DatingLowerBound = 1500, DatingUpperBound = 1800 });
            yield return new TestCaseData("XV в н.э - XVIII в н.э").Returns(new DatingBound("XV в н.э - XVIII в н.э") { DatingLowerBound = 1400, DatingUpperBound = 1800 });
            yield return new TestCaseData("1799 г. до н.э").Returns(new DatingBound("1799 г. до н.э") { DatingLowerBound = -1799, DatingUpperBound = -1799 });
            yield return new TestCaseData("1799 г. до н.э - 1400 г. до н.э").Returns(new DatingBound("1799 г. до н.э - 1400 г. до н.э") { DatingLowerBound = -1400, DatingUpperBound = -1799 });
            yield return new TestCaseData("кон. XV в. н.э - нач. XVIII в. н.э").Returns(new DatingBound("кон. XV в. н.э - нач. XVIII в. н.э") { DatingLowerBound = 1490, DatingUpperBound = 1710 });
            yield return new TestCaseData("сер. XV в. н.э").Returns(new DatingBound("сер. XV в. н.э") { DatingLowerBound = 1440, DatingUpperBound = 1460 });
            yield return new TestCaseData("1 пол. XV в. н.э").Returns(new DatingBound("1 пол. XV в. н.э") { DatingLowerBound = 1400, DatingUpperBound = 1450 });
            yield return new TestCaseData("кон. XV в. н.э").Returns(new DatingBound("кон. XV в. н.э") { DatingLowerBound = 1490, DatingUpperBound = 1500 });
        }

        [Test]
        public void TestParse_LowerBoundMoreThanUpper_Exception()
        {
            const string line = "1799 г. н.э - 1400 г. н.э";

            void Parse()
            {
                DatingBound datingBound = Parser.Parse(line);
            }

            Assert.Throws<ArgumentException>(Parse);
        }
    }
}
