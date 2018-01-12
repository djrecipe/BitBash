using System;
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
        public void TestCurrenciesRetrieval()
        {
            CoinbaseJPI jpi = new CoinbaseJPI();
            List<CoinbaseCurrency> currencies = jpi.GetCurrencies();
            foreach(CoinbaseCurrency currency in currencies)
            {
                Console.WriteLine(currency.Name);
            }
            Assert.IsTrue(currencies.Count > 0, "Retrieved an empty currency list");
            Assert.IsTrue(currencies.Any(c => c.ID.ToUpper() == "BTC"), "Failed to find BTC currency");
            return;
        }
        [TestMethod]
        public void TestExchangeRatesRetrieval()
        {
            CoinbaseJPI jpi = new CoinbaseJPI();
            CoinbaseExchangeRate exchange_rate = jpi.GetExchangeRate("USD");
            Assert.IsNotNull(exchange_rate, "Failed to retrieve exchange rate");
            Assert.IsNotNull(exchange_rate.Rates, "Failed to retrieve exchange rate values");
            Assert.IsTrue(exchange_rate.Rates.Count > 0, "Retrieved an empty exchange rate value list");
            foreach (KeyValuePair<string, double> pair in exchange_rate.Rates)
            {
                Console.WriteLine("{0}: {1:0.00000}", pair.Key, pair.Value);
            }
            return;
        }
    }
}
