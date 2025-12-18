using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Exceptions
{
    public class BlogException : Exception
    {
        public BlogException(string message)
            : base(message)
        {
            message = "IOExpection, OutOfMemoryException or ArgumentOutOfRangeException";
        }
    }
}
