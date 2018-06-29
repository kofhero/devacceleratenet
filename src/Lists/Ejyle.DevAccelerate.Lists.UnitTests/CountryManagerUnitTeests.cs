using System;
using Ejyle.DevAccelerate.Lists.Geography;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ejyle.DevAccelerate.Lists.UnitTests
{
    [TestClass]
    public class CountryManagerUnitTeests
    {
        [TestMethod]
        public void FindCountryByIdTest()
        {
            var countryManager = new CountryManager(new CountryRepository(new ListsDbContext()));
            var country = countryManager.FindById(1);

            Assert.IsNotNull(country, "Country not found.");
        }
    }
}
