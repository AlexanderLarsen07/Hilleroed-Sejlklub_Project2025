using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Boats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Services
{
    public class RepairRepo : IRepairRepo
    {
        private List<Repair> _repairLogList;

        public RepairRepo()
        {
            _repairLogList = new List<Repair>();
        }

        public List<Repair> GetAll()
        {
            return _repairLogList;
        }

        public void AddRepair(Repair repair)
        {
            for (int i = 0; _repairLogList.Count > i; i++)
            {
                if(repair.Number == _repairLogList[i].Number)
                {
                    throw new Exception(message: "Number already exist");
                }
            }
                _repairLogList.Add(repair);
                repair.TheBoat.AddRepairToBoat(repair);    
        }

        public Repair GetRepair(int number)
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

        public void RemoveRepair(Repair repair)
        { 
            for(int i = 0; _repairLogList.Count > i; i++)
            {
                if (repair.Number == _repairLogList[i].Number)
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
