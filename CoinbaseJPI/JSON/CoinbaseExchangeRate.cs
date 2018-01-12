using System.Collections.Generic;
using Newtonsoft.Json;

namespace Abaci.JPI.Coinbase.JSON
{
    [JsonObject(MemberSerialization.OptIn)]
    [Endpoint(SubPath = "exchange-rates", SingleToken = "data")]
    public class CoinbaseExchangeRate
    {
        public class ExchangeRateValue
        {
            public string TargetCurrency { get; set; }
            public string Value { get; set; }
        }
        [JsonProperty("currency")]
        public string ID { get; set; }
        public Dictionary<string, double> Rates { get; private set; } = new Dictionary<string, double>();
        [JsonProperty("rates", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        private Dictionary<string, string> RatesData
        {
            set
            {
                this.Rates.Clear();
                if (value == null)
                    return;
                foreach(KeyValuePair<string, string> pair in value)
                {
                    double dbl_value = 0.0;
                    double.TryParse(pair.Value, out dbl_value);
                    this.Rates.Add(pair.Key, dbl_value);
                }
            }
        }
    }
}
