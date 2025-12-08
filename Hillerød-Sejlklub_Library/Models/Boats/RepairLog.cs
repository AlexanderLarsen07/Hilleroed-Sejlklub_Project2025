using Hillerød_Sejlklub_Library.Models.Boats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Models.Boats
{
    public class RepairLog
    {
        

        public int Number { get; private set; }

        private DateTime _dateOfSignup;

        public string Comment { get; private set; }

        public Boat TheBoat { get; private set; }
        public bool IsFixed { get; set; }

        public bool HaveToBeSolved { get; set; }


        public RepairLog(int number, string comment, Boat theBoat, bool isFixed, bool haveToBeSolved)
        {
            _dateOfSignup = DateTime.Now; 
            Number = number;
            Comment = comment;
            TheBoat = theBoat;
            IsFixed = isFixed;
            HaveToBeSolved = haveToBeSolved;
        }


        public override string ToString()
        {
            return $"Made: {_dateOfSignup}\n" +
                   $"Number: {Number}\n" +
                   $"Comment: {Comment}\n" +
                   $"IsFixed: {IsFixed}\n" +
                   $"The problem needs to be fixed before the boat can sail: {HaveToBeSolved}"; 

        }

    }
}
