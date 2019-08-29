using System;
using System.Collections.Generic;
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
        #region Static Methods
        private static EndpointAttribute GetEndpointAttribute(Type type, out bool is_array)
        {
            Type element_type = null;
            // get element type of array
            if (type.IsArray)
            {
                element_type = type.GetElementType();
                is_array = true;
            }
            // get element type of list
            else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
            {
                element_type = type.GetGenericArguments()[0];
                is_array = true;
            }
            // assume not in an array
            else
            {
                element_type = type;
                is_array = false;
            }
            // retrieve EndpointAttribute
            object[] attributes = element_type.GetCustomAttributes(typeof(EndpointAttribute), true);
            if (attributes.Length < 1)
                throw new JsonException(string.Format("Type '{0}' does not have an EndpointAttribute", type.FullName));
            EndpointAttribute attribute = attributes[0] as EndpointAttribute;
            return attribute;
        }
        #endregion
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
        /// <param name="name">Optional parameter name to append to the final url</param>
        /// <param name="value">Optional parameter value to append to the final url</param>
        /// <returns>Retrieved payload</returns>
        public T Get<T>(string name, object value)
        {
            return this.Get<T>(new Dictionary<string, object> { { name, value } });
        }
        /// <summary>
        /// Retrieve payload of the specified type from the specified remote endpoint
        /// </summary>
        /// <typeparam name="T">Payload type</typeparam>
        /// <param name="parameters">Optional parameter values to append to the final url</param>
        /// <returns>Retrieved payload</returns>
        public T Get<T>(Dictionary<string, object> parameters)
        {           
            // construct path
            string sub_url = "";
            if (parameters != null && parameters.Count > 0)
            {
                sub_url = "/?";
                foreach (KeyValuePair<string, object> pair in parameters)
                {
                    sub_url += string.Format("{0}={1}", pair.Key, pair.Value.ToString());
                }
            }
            return this.Get<T>(sub_url);
        }
        /// <summary>
        /// Retrieve payload of the specified type from the specified remote endpoint
        /// </summary>
        /// <typeparam name="T">Payload type</typeparam>
        /// <param name="sub_url">Optional sub url to append to the final url</param>
        /// <returns>Retrieved payload</returns>
        public T Get<T>(string sub_url = null)
        {
            // get endpoint attribute info
            Type type = typeof(T);
            bool is_array = false;
            EndpointAttribute attribute = RemotePayloadFactory.GetEndpointAttribute(type, out is_array);
            string path = string.Format("{0}/{1}{2}", this.RootPath, attribute.SubPath, sub_url ?? "");
            // retrieve from path
            JObject obj = this.RetrieveRemote(path, attribute.Authenticated);
            // select token
            string token = is_array ? attribute.ListToken : attribute.SingleToken;
            string result = string.IsNullOrWhiteSpace(token) ? obj.ToString() : obj.SelectToken(token).ToString();
            // deserialize into object
            return JsonConvert.DeserializeObject<T>(result, this.serializationSettings);
        }
        /// <summary>
        /// Retrieve a JSON object from the specified remote path
        /// </summary>
        /// <param name="remote_path">Remote retrieval path</param>
        /// <returns>Generic JSON object</returns>
        protected virtual JObject RetrieveRemote(string remote_path, bool authenticated)
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
