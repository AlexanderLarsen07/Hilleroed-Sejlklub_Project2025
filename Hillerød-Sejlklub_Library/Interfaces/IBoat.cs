using Hillerød_Sejlklub_Library.Models;
using Hillerød_Sejlklub_Library.Models.Boats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Interfaces
{
    public interface IBoat
    {
        public List<Boat> GetAll();
        public void AddBoat(Boat boat);
        public Boat GetBoatBySailNumber(string SailNumber);
        public void RemoveBySailNumber(string SailNumber);

        public void PrintAllBoats();

    }
}
