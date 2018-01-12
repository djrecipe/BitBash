using System.Collections.Generic;
using Abaci.JPI.Coinbase.JSON;

namespace Abaci.JPI.Coinbase
{
    public class CoinbaseJPI
    {
        public enum Currency { BTC=0 }
        public enum PriceType { Buy=0, Sell=1}
        private RemotePayloadFactory payloadFactory = new RemotePayloadFactory("https://api.coinbase.com/v2");

        public List<CoinbaseCurrency> GetCurrencies()
        {
            return this.payloadFactory.Get<List<CoinbaseCurrency>>();
        }
        public CoinbaseExchangeRate GetExchangeRate(string currency)
        {
            return this.payloadFactory.Get<CoinbaseExchangeRate>("currency", currency);
        }
        public double GetUnitPrice(Currency currency, PriceType type)
        {
            string sub_url = string.Format("/{0}-USD/{1}", currency.ToString().ToLower(), type.ToString().ToLower());
            return this.payloadFactory.Get<CoinbaseUnitPrice>(sub_url).Price;
        }
    }
}
