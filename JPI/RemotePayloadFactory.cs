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
        public string RootPath { get; }
        #endregion
        #region Instance Methods
        /// <summary>
        /// Create a new instance associated with the specified remote path
        /// </summary>
        /// <param name="path">Root for remote retrieval requests</param>
        public RemotePayloadFactory(string path)
        {
            if(string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Invalid root path for remote payload factory", nameof(path));
            this.RootPath = path;
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
        /// <returns>Retrieved payload</returns>
        public T Get<T>()
        {
            object[] attributes = typeof(T).GetCustomAttributes(typeof(EndpointAttribute), true);
            if(attributes.Length < 1)
                throw new ArgumentException("Endpoint does not have an EndpointAttribute");
            EndpointAttribute attribute = attributes[0] as EndpointAttribute;
            string path = string.Format("{0}/{1}", this.RootPath, attribute.SubPath);
            JObject obj = this.RetrieveRemote(path);
            string result = string.IsNullOrWhiteSpace(attribute.Token) ? obj.ToString() : obj.SelectToken(attribute.Token).ToString();
            return JsonConvert.DeserializeObject<T>(result, this.serializationSettings);
        }
        /// <summary>
        /// Retrieve a JSON object from the specified remote path
        /// </summary>
        /// <param name="remote_path">Remote retrieval path</param>
        /// <returns>Generic JSON object</returns>
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
