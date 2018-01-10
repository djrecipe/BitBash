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
        [JsonProperty("rates", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public Dictionary<string, string> Rates { get; set; } = new Dictionary<string, string>();
    }
}
