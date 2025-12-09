using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Boats;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Methods__Controllers.Boats
{
    public class AddBoatController
    {
        IBoatRepo _boat;
        public Boat TheBoat { get; set; }

        public AddBoatController(string sailNumber, string name, string description, BoatTypeEnum boatType, ModelEnum theModel, int maxPassengers, int lenght, int width, int draft, int yearBuilt, MotorInfo motor, IBoatRepo theBoat)
        {
            TheBoat = new Boat(sailNumber, name, description, boatType, theModel, maxPassengers, lenght, width, draft, yearBuilt, motor);
            _boat = theBoat;
        }
        public void Add()
        {
            _boat.AddBoat(TheBoat);
        }
    }
}
