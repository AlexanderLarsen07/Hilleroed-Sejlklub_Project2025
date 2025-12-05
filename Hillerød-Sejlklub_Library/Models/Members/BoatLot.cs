using Hillerød_Sejlklub_Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Models.Members
{
    public class BoatLot//Oplysninger om båden
    {
        private static int _lotID = 1;
        public int LotID { get { return _lotID; } private set { value = _lotID; } }
        public int Length { get; }
        public int Width { get; }
        public BoatLot(int length, int width)
        {
            Length = length;
            Width = width;
            LotID = _lotID++;
        }
        public override string ToString() //implement those above
        {
            return $"ID: {LotID}\n" +
                $"Length:{Length}cm.\n" +
                $"Bredden:{Width}cm.";
        }
    }
}
