using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Abaci.JPI.Coinbase.JSON
{
    [JsonObject(MemberSerialization.OptIn)]
    public struct CoinbaseCurrency
    {
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("min_size")]
        public double Minimum { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
