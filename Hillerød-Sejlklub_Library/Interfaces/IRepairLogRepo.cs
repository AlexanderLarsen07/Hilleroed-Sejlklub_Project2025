using Hillerød_Sejlklub_Library.Models.Boats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Interfaces
{
    public interface IRepairLogRepo
    {
        List<RepairLog> GetAll();
        void AddRepair(RepairLog repairLog);
        RepairLog GetRepairLog(int number);
        void RemoveRepairLog(RepairLog repairLog);
        void PrintAllRepairs();

        void PrintAllTheRepairsToEachBoat();
    }
}
