using System;

namespace Abaci.JPI
{
    public class EndpointPath
    {
        public static implicit operator string(EndpointPath path)
        {
            return path.GetFullPath();
        }

        EndpointPath Parent { get; }
        string Path { get; }

        public EndpointPath(string path, EndpointPath parent = null)
        {
            if(string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Invalid endpoint path", nameof(path));
            this.Path = path;
            this.Parent = parent;
            return;
        }

        public string GetFullPath()
        {
            if (this.Parent != null)
            {
                return string.Format("{0}/{1}", this.Parent.GetFullPath(), this.Path);
            }
            else
            {
                return this.Path;
            }
        }
    }
}
