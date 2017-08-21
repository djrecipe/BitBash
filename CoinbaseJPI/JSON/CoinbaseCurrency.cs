using System.Collections.Generic;
using Newtonsoft.Json;

namespace Abaci.JPI.Coinbase.JSON
{
    [JsonObject(MemberSerialization.OptIn)]
    [Endpoint(SubPath = "exchange-rates", ListToken = "data")]
    public class CoinbaseExchangeRate
    {
        [JsonProperty("currency")]
        public string ID { get; set; }
        [JsonProperty("rates")]
        public Dictionary<string, double> Rates { get; set; }
    }
}
