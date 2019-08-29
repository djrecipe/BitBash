using System;

namespace Abaci.JPI
{
    /// <summary>
    /// Attributes necessary to deserialize a class from data retrieved from a remote endpoint
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class EndpointAttribute : Attribute
    {
        #region Instance Properties
        /// <summary>
        /// Requires authentication to connect to remote endpoint
        /// </summary>
        public bool Authenticated { get; set; } = false;
        /// <summary>
        /// JSON token to select when deserializing a list of the associated type
        /// </summary>
        public string ListToken { get; set; }
        /// <summary>
        /// JSON token to select when deserializing a single instance of the associated type
        /// </summary>
        public string SingleToken { get; set; }
        /// <summary>
        /// Additional pathing to append to the root path for remote retrieval
        /// </summary>
        public string SubPath { get; set; }
        #endregion
    }
}
