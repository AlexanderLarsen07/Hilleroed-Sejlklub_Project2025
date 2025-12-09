using Hillerød_Sejlklub_Library.Models.Boats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Models.Boats
{
    public class Repair
    {
        private DateTime _dateOfRepair;

        public int Number { get; set; }

        public string Comment { get; set; }

        public Boat TheBoat { get; set; }
        public bool IsFixed { get; set; }

        public bool HaveToBeSolved { get; set; }


        public Repair(int number, string comment, Boat theBoat, bool isFixed, bool haveToBeSolved)
        {
            _dateOfRepair = DateTime.Now; 
            Number = number;
            Comment = comment;
            TheBoat = theBoat;
            IsFixed = isFixed;
            HaveToBeSolved = haveToBeSolved;
        }


        public override string ToString()
        {
            return $"The name of the boat: {TheBoat.Name}\n" +
                   $"Made: {_dateOfRepair}\n" +
                   $"Number: {Number}\n" +
                   $"Comment: {Comment}\n" +
                   $"IsFixed: {IsFixed}\n" +
                   $"The problem needs to be fixed before the boat can sail: {HaveToBeSolved}\n"; 
        }
    }
}
