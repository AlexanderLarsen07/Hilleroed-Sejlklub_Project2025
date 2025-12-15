using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Boats;
using Hillerød_Sejlklub_Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Methods__Controllers.Boats
{
    public class AddRepairController
    {
        IRepairRepo _repairLogList;

        IBoatRepo _boat;

        public Repair TheRepair { get; set; }
        
        public AddRepairController(int number, string comment, Boat theBoat, bool isFixed, bool haveToBeSolved, RepairRepo repairRepo, BoatRepo boatRepo)
        {
            TheRepair = new Repair(number, comment, theBoat, isFixed, haveToBeSolved);
            _repairLogList = repairRepo;
            _boat = boatRepo;
        }

        public void AddTheCreatedRepair()
        {
            _repairLogList.AddRepair(TheRepair);
        }

    }
}
