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
        public List<RepairLog> GetAll();
        public void AddRepair(RepairLog repairLog);
        public RepairLog GetRepairLog(int number);
        public void RemoveRepairLog(RepairLog repairLog);
        public void PrintAllRepairs();

        public void PrintAllTheRepairsToEachBoat();
    }
}
