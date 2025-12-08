using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Models.Boats
{
    public class MotorInfo
    {
        public FuelTypeEnum FuelType {get; private set;}

        public BrandEnum Brand { get; private set; }

        public int HP {get; private set;}

        public int Weight {get; private set;}

        public MotorInfo(FuelTypeEnum fuelType, BrandEnum brand, int hp, int weight)
        {
            
            FuelType = fuelType;
            Brand = brand;
            HP = hp;
            Weight = weight;
           
        }

        public override string ToString()   
        {
            {
                return $"FuelType: {FuelType}\nBrand: {Brand}\nHousePower: {HP}\nWeight: {Weight}";
            }
        }
    }
}
