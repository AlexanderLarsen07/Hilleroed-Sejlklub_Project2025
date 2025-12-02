using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Models
{
    public class Boat
    {
        public  int Id { get; set; }
        public void PrintAlex()
        {
            Console.WriteLine(Id);
        }
    }
}
