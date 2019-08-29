using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Abaci.JPI.Tests.Stubs
{
    public class RemotePayloadFactoryStub : RemotePayloadFactory
    {
        private readonly Dictionary<string, string> payloads = null;
        public RemotePayloadFactoryStub(string path, Dictionary<string, string> payloads) : base(path)
        {
            this.payloads = payloads;
            return;
        }
        protected override JObject RetrieveRemote(string remote_path, bool authenticated)
        {
            if (!this.payloads.ContainsKey(remote_path))
                return null;
            string text = this.payloads[remote_path];
            JObject obj = JObject.Parse(text);
            return obj;
        }
    }
}
