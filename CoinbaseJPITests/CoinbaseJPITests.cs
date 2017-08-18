using System.Collections.Generic;
using System.Linq;
using Abaci.JPI.Coinbase.JSON;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abaci.JPI.Coinbase.Tests
{
    [TestClass]
    public class CoinbaseJPITests
    {
        [TestMethod]
        public void TestCurrencyRetrieval()
        {
            CoinbaseJPI jpi = new CoinbaseJPI();
            List<CoinbaseCurrency> currencies = jpi.Get();
            Assert.IsTrue(currencies.Any(c => c.ID.ToUpper() == "BTC"), "Failed to find BTC currency");
            return;
        }
    }
}
