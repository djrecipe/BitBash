using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Abaci.JPI
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class PayloadCollection<T>
    {
        public static implicit operator List<T>(PayloadCollection<T> collection)
        {
            return collection.Payloads;
        }
        [JsonProperty("data")]
        public List<T> Payloads { get; set; }
    }
}
