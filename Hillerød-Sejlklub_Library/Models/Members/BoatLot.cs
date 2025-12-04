using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Models.Members
{
    public class BoatLot
    {
        private int _lotID;
        public int LotID { get; }
        public int Length { get; }
        public int Width { get; }
        public BoatLot(int length, int width)
        {

        }
        public override string ToString()
        {
            return $"";
        }
    }
}
