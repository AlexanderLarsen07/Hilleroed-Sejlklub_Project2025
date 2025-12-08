using Hillerød_Sejlklub_Library.Models.Boats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Interfaces
{
    public interface IRepairRepo
    {
        public List<Repair> GetAll();
        public void AddRepair(Repair repair);
        public Repair GetRepair(int number);
        public void RemoveRepair(Repair repair);
        public void PrintAllRepairs();

        public void PrintAllTheRepairsToEachBoat();
    }
}
