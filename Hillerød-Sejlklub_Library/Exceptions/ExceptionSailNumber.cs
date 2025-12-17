using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Exceptions
{
    public class ExceptionSailNumber : Exception
    {
        public ExceptionSailNumber(string sailNumber)

           : base($"{sailNumber} sailnumber already exist")   
     
        {
        }
    }
}
