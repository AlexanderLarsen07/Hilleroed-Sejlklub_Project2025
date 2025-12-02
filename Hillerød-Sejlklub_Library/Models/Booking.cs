using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Models
{
    public class Booking
    {
        public string Destination { get; private set; }

            
        public bool Overdue { get; }
        public override string ToString()
        {
            return $"{}";
        }
    }
}

   