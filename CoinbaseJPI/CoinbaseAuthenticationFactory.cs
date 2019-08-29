using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Abaci.JPI.Coinbase
{
    public class CoinbaseAuthenticationFactory
    {
        private static HttpWebRequest CreateRequest()
        {
            string url =
                "https://www.coinbase.com/oauth/authorize?response_type=code&client_id=2fe7ae2ade4d2b941f4598ddf3b6fa8d8f111ed9500b03f7480617bae9fdc782";
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            return request;
        }

        internal string RequestTemporaryCode()
        {
            HttpWebRequest request = CoinbaseAuthenticationFactory.CreateRequest();
            WebResponse response = request.GetResponse();
            // read from web request stream
            using (StreamReader stream_reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                string text = stream_reader.ReadToEnd();
                return text;
            }
        }
    }
}
