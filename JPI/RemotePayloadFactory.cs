using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Abaci.JPI
{
    /// <summary>
    /// Retrieves a payload from a remote location
    /// </summary>
    public class RemotePayloadFactory
    {
        #region Instance Members
        private readonly JsonSerializerSettings serializationSettings = new JsonSerializerSettings();
        #endregion
        #region Instance Properties
        #endregion
        #region Instance Methods
        /// <summary>
        /// Create a new instance associated with the specified remote path
        /// </summary>
        /// <param name="path">Root for remote retrieval requests</param>
        public RemotePayloadFactory()
        {
            this.serializationSettings = new JsonSerializerSettings
            {
                ObjectCreationHandling = ObjectCreationHandling.Reuse,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            return;
        }
        /// <summary>
        /// Retrieve payload of the specified type from the specified remote endpoint
        /// </summary>
        /// <typeparam name="T">Payload type</typeparam>
        /// <param name="endpoint">Remote endpoint information</param>
        /// <param name="token">Json token to select</param>
        /// <returns>Retrieved payload</returns>
        public T Get<T>(EndpointPath endpoint, string token)
        {
            string path = endpoint.GetFullPath();
            JObject obj = this.RetrieveRemote(path);
            string result = string.IsNullOrWhiteSpace(token) ? obj.ToString() : obj.SelectToken(token).ToString();
            return JsonConvert.DeserializeObject<T>(result, this.serializationSettings);
        }
        protected virtual JObject RetrieveRemote(string remote_path)
        {
            // create web request
            HttpWebRequest request = HttpWebRequest.Create(remote_path) as HttpWebRequest;
            // read from web request stream
            using (StreamReader stream_reader =
                new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8))
            {
                string text = stream_reader.ReadToEnd();
                JObject obj = JObject.Parse(text);
                return obj;
            }
        }
        #endregion
    }
}
