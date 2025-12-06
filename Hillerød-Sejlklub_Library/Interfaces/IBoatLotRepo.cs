using Hillerød_Sejlklub_Library.Models.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Interfaces
{
    public interface IBoatLotRepo
    {
        List<BoatLot> GetAll();
        void AddBoatLot(BoatLot boatLot);
        BoatLot GetBoatLotById(int id);
        void RemoveBoatLot(int id);
        void PrintAllBoatLots();
    }
}
