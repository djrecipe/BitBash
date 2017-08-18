using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Abaci.JPI.Tests.Stubs
{
    [JsonObject(MemberSerialization.OptIn)]
    [Endpoint(SubPath = "testpayloadretrieval")]
    public class TestPayloadCollection : PayloadCollection<TestPayload>
    {
    }
}
