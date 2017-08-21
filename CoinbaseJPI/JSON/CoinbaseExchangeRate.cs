using Newtonsoft.Json;

namespace Abaci.JPI.Coinbase.JSON
{
    [JsonObject(MemberSerialization.OptIn)]
    [Endpoint(SubPath = "currencies", ListToken = "data")]
    public class CoinbaseCurrency
    {
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("min_size")]
        public double Minimum { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
