using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Models
{
    public class Boat
    {
        public  int SejlNummer { get; private set; }
        
        public string Name { get; private set; }

        public string Description { get; private set; }

        public BådTypeEnum BådTypen {get; private set; }

        public ModelEnum TheModel {get; private set; }

        public int MaxPassengers { get; private set; }
        
        public MotorInfo Motor { get; private set; }

        public int Lenght { get; private set; }
        
        public int Width {get; private set; }
        
        public int Dybgang { get; private set; }

        public int ByggeÅr { get; private set; }

        public List<RepairLog>
        +RepairLog : list<string>


        public Boat(int sejlNummer, string name, string description, BådTypeEnum bådTypen, ModelEnum theModel, int maxPassengers, 
            int lenght, int width, int dybgang, int byggeår, MotorInfo motor)
        {
            SejlNummer = sejlNummer;
            Name = name;
            Description = description;
            BådTypen = bådTypen;
            TheModel = theModel;
            MaxPassengers = maxPassengers;
            Lenght = lenght;
            Width = width;
            Dybgang = dybgang;
            ByggeÅr = byggeår;
        }


        public override string ToString()
        {
            return $"SejlNummer: {SejlNummer}\n Name: {Name}\n Description: {Description}\n BådTypen: {BådTypen}\n TheModel: {TheModel} \n " +
                $"MaxPassengers : {MaxPassengers}\n Motor: {Motor}\n Lenght {Lenght}\n Width: {Width}\n Dybgang: {Dybgang}\n ByggeÅr: {ByggeÅr}\n" +
                $"Motor: {Motor}\n" +
                $"RepairLog: {RepairLog}";
               
        }
    }
    
}
