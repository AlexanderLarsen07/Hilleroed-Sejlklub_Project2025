using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Boats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Services
{
    public class RepairLogRepo : IRepairLogRepo
    {
        private List<RepairLog> _repairLogList;

        public RepairLogRepo()
        {
            _repairLogList = new List<RepairLog>();
        }

        public void AddRepair(RepairLog repairLog)
        {
            for (int i = 0; _repairLogList.Count > i; i++)
            {
                if(repairLog.Number == _repairLogList[i].Number)
                {
                    throw new Exception(message: "Number already exist");
                }
            }
                _repairLogList.Add(repairLog);
        }

        public List<RepairLog> GetAll()
        {
            return _repairLogList;
        }

        public RepairLog GetRepairLog(int number)
        {
            for(int i = 0; _repairLogList.Count > i; i++)
            {
                if(number == _repairLogList[i].Number)
                {
                    return _repairLogList[i];
                }
            }
            throw new Exception(message: "Number does not exist");
        }

        public void RemoveRepairLog(RepairLog repairLog)
        { 
            for(int i = 0; _repairLogList.Count > i; i++)
            {
                if (repairLog.Number == _repairLogList[i].Number)
                {
                    _repairLogList.RemoveAt(i);
                }
            }
            throw new Exception(message: "The number does not exist");
        }

        public void PrintAllRepairs()
        {
            for (int i = 0; _repairLogList.Count > i; i++)
            {
                Console.WriteLine(_repairLogList[i]);
            }
        }

        public void PrintAllTheRepairsToEachBoat()
        {
            BoatRepo boatRepo = new BoatRepo();
            List<Boat> _boat = boatRepo.GetAll();
            for (int i = 0; _boat.Count > i; i++)
            {
                Console.WriteLine(_boat[i].Name);
                for (int j = 0; _repairLogList.Count > j; j++)
                {
                    if (_repairLogList[j].TheBoat.Name == _boat[i].Name)
                    {
                        Console.WriteLine(_repairLogList[j]);
                    }
                }
            }
        }
    }
}
