using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Models
{
    public class MotorInfo
    {
        public FuelTypeEnum FuelType {get; private set;}

        public BrandEnum Mærke { get; private set; }

        public int HP {get; private set;}

        public int Weight {get; private set;}

        public MotorInfo(FuelTypeEnum fuelType, BrandEnum mærke, int hp, int weight)
        {
            FuelType = fuelType;
            Mærke = mærke;
            HP = hp;
            Weight = weight;
            
        }


        public override string ToString()
        {
            return $"FuelType: {FuelType} \nMærke: {Mærke}\nHousePower: {HP}\n Weight: {Weight}";
        }
    }
}
