using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abaci.JPI
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class EndpointAttribute : Attribute
    {
        public string SubPath { get; set; }
        public string Token { get; set; }
    }
}
