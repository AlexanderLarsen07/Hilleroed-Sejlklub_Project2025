using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Models.Boats
{
    public class InheritanceMotorExample : Boat
    {
        public FuelTypeEnum FuelType { get; private set; }

        public BrandEnum Brand { get; private set; }

        public int HP { get; private set; }

        public int Weight { get; private set; }


        public InheritanceMotorExample(string sailNumber, string name, string description, BoatTypeEnum boatType, ModelEnum theModel, int maxPassengers,
            int lenght, int width, int draft, int yearBuilt, MotorInfo motorInfo, FuelTypeEnum fuelType, BrandEnum brand, int hp, int weight) : base
            (sailNumber, name, description, boatType, theModel, maxPassengers, lenght, width, draft, yearBuilt, motorInfo)
        {
            FuelType = fuelType;
            Brand = brand;
            HP = hp;
            Weight = weight;
        }

        public override string ToString()
        {
            return base.ToString() + $"FuelType: {FuelType} Brand: {Brand} HP: {HP} Weight: {Weight}";
        }
    }
}
