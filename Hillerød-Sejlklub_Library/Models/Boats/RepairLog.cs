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
        private static int _number = 1;

        public int Number { get; private set; }

        private DateTime _dateOfSignup;

        public string Comment { get; private set; }

        public Boat TheBoat { get; private set; }
        public bool IsFixed { get; set; }

        public bool CanSail {get; private set;}


        public RepairLog(string comment, Boat theBoat, bool isFixed, bool canSail)
        {
            _dateOfSignup = DateTime.Now;
            Number = _number++;
            Comment = comment;
            TheBoat = theBoat;
            IsFixed = isFixed;
            CanSail = canSail;
        }


        public override string ToString()
        {
         return $"Made: {_dateOfSignup}" +
                $"Number: {Number}" +
                $"Comment: {Comment}\n" +
                $"TheBoat: {TheBoat}\n" +
                $"IsFixed: {IsFixed}\n" +
                $"CanSail: {CanSail}";
        }



    }
}
