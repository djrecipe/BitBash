using System;
using System.Collections.Generic;
using System.Linq;
using Abaci.JPI.Coinbase.JSON;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abaci.JPI.Coinbase.Tests
{
    /// <summary>
    /// Test Coinbase-specific public (non-authenticated) API actions
    /// </summary>
    [TestClass]
    public class CoinbasePublicJPITests
    {
        private CoinbaseJPI jpi = null;
        /// <summary>
        /// Initialize the test infrastructure
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            this.jpi = new CoinbaseJPI();
        }
        /// <summary>
        /// Test retrieval of currency names
        /// </summary>
        [TestMethod]
        public void TestCurrenciesRetrieval()
        {
            List<CoinbaseCurrency> currencies = this.jpi.GetCurrencies();
            Assert.IsNotNull(currencies, "Failed to retrieve currency list");
            foreach(CoinbaseCurrency currency in currencies)
            {
                Console.WriteLine("{0} : {1}", currency.ID, currency.Name);
            }
            Assert.IsTrue(currencies.Count > 0, "Retrieved an empty currency list");
            Assert.IsTrue(currencies.Any(c => c.ID.ToUpper() == "USD"), "Failed to find USD currency");
            return;
        }
        /// <summary>
        /// Test retrieval of currency exchange rates (compared to USD)
        /// </summary>
        [TestMethod]
        public void TestSingleExchangeRatesRetrieval()
        {
            CoinbaseExchangeRate exchange_rate = this.jpi.GetExchangeRate("USD");
            Assert.IsNotNull(exchange_rate, "Failed to retrieve exchange rate");
            Assert.IsNotNull(exchange_rate.Rates, "Failed to retrieve exchange rate values");
            Assert.IsTrue(exchange_rate.Rates.Count > 0, "Retrieved an empty exchange rate value list");
            foreach (KeyValuePair<string, double> pair in exchange_rate.Rates)
            {
                Console.WriteLine("{0}: {1:0.00000}", pair.Key, pair.Value);
            }
            return;
        }
        /// <summary>
        /// Test retrieval of buy price for BTC
        /// </summary>
        [TestMethod]
        public void TestUnitBuyPriceRetrieval()
        {
            double price = this.jpi.GetUnitPrice(CoinbaseJPI.Currency.BTC, CoinbaseJPI.PriceType.Buy);
            Console.WriteLine("{0:0.00}", price);
            return;
        }
        /// <summary>
        /// Test retrieval of sell price for BTC
        /// </summary>
        [TestMethod]
        public void TestUnitSellPriceRetrieval()
        {
            double price = this.jpi.GetUnitPrice(CoinbaseJPI.Currency.BTC, CoinbaseJPI.PriceType.Sell);
            Console.WriteLine("{0:0.00}", price);
            return;
        }
    }
}
