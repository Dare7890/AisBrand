using BrandDataProcessing.DAL;
using BrandDataProcessing.Models;
using GenericFilters;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GenericFilterTests
{
    [TestFixture]
    public class GenericFilterTests
    {
        private const string fileName = @"D:\Work\AisBrand\AisBrand\BrandDataProcessingTests\bin\Debug\net5.0\Test.xml";

        [Test]
        public void TestCheckOnEmpty_NullFieldNumberBrand_Success()
        {
            const int expectedExcavationsCount = 1;
            const int expectedExcavationId = 3;

            BrandLocal brandLocal = new BrandLocal(fileName);
            IEnumerable<Brand> brands = brandLocal.GetWithEmptyName();
            GenericFilter<Brand> filter = new GenericFilter<Brand>();
            filter.CheckOnEmpty("FieldNumber");
            filter.Apply(brands);

            int actualExcavationCount = brands.Count();
            int actualExcavationId = brands.Single().ID;

            Assert.AreEqual(expectedExcavationsCount, actualExcavationCount);
            Assert.AreEqual(expectedExcavationId, actualExcavationId);
        }
    }
}
