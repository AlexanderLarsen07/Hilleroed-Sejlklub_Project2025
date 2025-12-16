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
        public Dictionary<int, BoatLotRepo> _boatLots;
        private static int _lotID = 1;
        private int _boatLotID;
        public int LotID { get { return _boatLotID; } }
        public int Length { get; }
        public int Width { get; }
        public bool IsRented { get; set; }
        public BoatLot(int length, int width)
        {
            _boatLots = new Dictionary<int, BoatLotRepo>();
            Length = length;
            Width = width;
            _boatLotID = _lotID++;
            IsRented = false;
        }
        public override string ToString() //implement those above
        {
            return $"\nID: {LotID}\n" +
                $"Length:{Length}cm.\n" +
                $"Bredden:{Width}cm.";
        }
    }
}
