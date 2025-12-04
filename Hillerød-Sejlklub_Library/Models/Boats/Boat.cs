using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Models.Boats
{
    public class Boat
    {
        public  int SailNumber { get; private set; }
        
        public string Name { get; private set; }

        public string Description { get; private set; }

        public BoatTypeEnum BoatType {get; private set; }

        public ModelEnum TheModel {get; private set; }

        public int MaxPassengers { get; private set; }
        
        public MotorInfo Motor { get; private set; }

        public int Lenght { get; private set; }
        
        public int Width {get; private set; }
        
        public int Draft { get; private set; }

        public int YearBuilt { get; private set; }

        public bool CanSail { get; private set;}

        public List<string> RepairLog;
        
      
        public Boat(int sailNumber, string name, string description, BoatTypeEnum badTypen, ModelEnum theModel, int maxPassengers, 
            int lenght, int width, int draft, int yearBuilt, MotorInfo motor, bool canSail)
        {
            SailNumber = sailNumber;
            Name = name;
            Description = description;
            BoatType = boatType;
            TheModel = theModel;
            MaxPassengers = maxPassengers;
            Lenght = lenght;
            Width = width;
            Draft = draft;
            YearBuilt = yearBuilt;
            Motor = motor;
            CanSail = canSail;
            RepairLog = new List<string>();

        }


        public override string ToString()
        {
            return $"SejlNummer: {SailNumber}\n Name: {Name}\n Description: {Description}\n BådTypen: {BadTypen}\n TheModel: {TheModel} \n " +
                $"MaxPassengers : {MaxPassengers}\n Motor: {Motor}\n Lenght {Lenght}\n Width: {Width}\n Dybgang: {Draft}\n ByggeÅr: {YearBuilt}\n" +
                $"Motor: {Motor}\n" +
                $"CanSail: {CanSail}" +
                $"RepairLog: {RepairLog}";
               
        }


        public void RepairLogMethod()
        {
            foreach (string log in RepairLog)
            {
                Console.WriteLine(log);
            }
        }
    }
}
