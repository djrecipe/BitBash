using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Abaci.JPI.Tests.Stubs
{
    [JsonObject(MemberSerialization.OptIn)]
    [Endpoint(SubPath = "testpayloadretrieval", ListToken = "data")]
    public class TestPayload
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
