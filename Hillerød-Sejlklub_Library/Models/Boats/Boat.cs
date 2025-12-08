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
        public string SailNumber { get; private set; }
        
        public string Name { get; private set; }

        public string Description { get; private set; }

        public BoatTypeEnum BoatType {get; private set; }

        public ModelEnum TheModel {get; private set; }

        public int MaxPassengers { get; private set; }

        public int Lenght { get; private set; }
        
        public int Width {get; private set; }
        
        public int Draft { get; private set; }

        public int YearBuilt { get; private set; }

        public MotorInfo? Motor { get; private set; }

        public bool CanSail { get; private set;}

        public List<Repair> RepairLogList;


        public Boat(string sailNumber, string name, string description, BoatTypeEnum boatType, ModelEnum theModel, int maxPassengers,
            int lenght, int width, int draft, int yearBuilt, MotorInfo? motor)
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
            RepairLogList = new List<Repair>();
            CanSailUpdated();
        }
        public void CanSailUpdated()
        {
            if (RepairLogList.Count == 0)
            {
                CanSail = true;
                return;
            }
            for (int i = 0; RepairLogList.Count > i; i++)
            {
                
                if (RepairLogList[i].IsFixed == false && RepairLogList[i].HaveToBeSolved == true)
                {
                    CanSail = false;
                    return;
                }
                CanSail = true;
            } 
        }
           
        public override string ToString()
        {
            string motorText;
                if(Motor == null)
                {
                motorText = "No motor";
                }
                else
                {
                motorText = Motor.ToString();
                }
                
            return $"SejlNummer: {SailNumber}\nName: {Name}\nDescription: {Description}\nBådTypen: {BoatType}\nTheModel: {TheModel}\n" +
                $"MaxPassengers : {MaxPassengers}\nLenght {Lenght}\nWidth: {Width}\nDybgang: {Draft}\nByggeÅr: {YearBuilt}\n"+
                $"Motor: {motorText}\n" +
                $"CanSail: {CanSail}\n"
                ; 
        }
    }
}
