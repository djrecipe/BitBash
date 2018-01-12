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
        private CoinbaseJPI jpi = null;
        [TestInitialize]
        public void TestInitialize()
        {
            this.jpi = new CoinbaseJPI();
        }
        [TestMethod]
        public void TestCurrenciesRetrieval()
        {
            List<CoinbaseCurrency> currencies = this.jpi.GetCurrencies();
            Assert.IsNotNull(currencies, "Failed to retrieve currency list");
            foreach(CoinbaseCurrency currency in currencies)
            {
                Console.WriteLine(currency.Name);
            }
            Assert.IsTrue(currencies.Count > 0, "Retrieved an empty currency list");
            Assert.IsTrue(currencies.Any(c => c.ID.ToUpper() == "BTC"), "Failed to find BTC currency");
            return;
        }
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
        [TestMethod]
        public void TestUnitBuyPriceRetrieval()
        {
            double price = this.jpi.GetUnitPrice(CoinbaseJPI.Currency.BTC, CoinbaseJPI.PriceType.Buy);
            Console.WriteLine("{0:0.00}", price);
            return;
        }
        [TestMethod]
        public void TestUnitSellPriceRetrieval()
        {
            double price = this.jpi.GetUnitPrice(CoinbaseJPI.Currency.BTC, CoinbaseJPI.PriceType.Sell);
            Console.WriteLine("{0:0.00}", price);
            return;
        }
    }
}
