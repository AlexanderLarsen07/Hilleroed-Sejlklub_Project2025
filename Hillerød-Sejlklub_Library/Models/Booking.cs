using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Models
{
    public class Booking
    {
        private static int _bookingID = 0;

        public int BookingID { get; private set; }
        public string Destination { get; private set; }

        public DateTime Start { get; private set; }

        public DateTime End { get; private set; }
        public bool Overdue { get; }

        public List<Member> ListOfMembers = new List<Member>();

        public Booking(string destination, DateTime start, DateTime end, bool overdue)
        {
            _bookingID++;
            BookingID = _bookingID;
            Destination = destination;
            Start = start;
            End = end;
            Overdue = overdue;
           
        }

        public override string ToString()
        {
            return $"BookingID: {BookingID}\n Destination: {Destination}\n Start: {Start}\n End: {End}\n Overdue: {Overdue}";
        }
    }
}

   