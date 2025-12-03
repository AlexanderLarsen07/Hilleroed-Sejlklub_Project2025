using System;
using System.Collections;
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

        public int NumberOfMembers { get; private set; }

        public DateTime Start { get; private set; }

        public DateTime End { get; private set; }
        
       
        public bool Overdue
        {
            get {return Start.AddHours(5) < End;}    
        }

        public List<Member> ListOfMembers = new List<Member>();

        public Booking(string destination, int numberOfMembers, DateTime start, DateTime end)
        {
            _bookingID++;
            BookingID = _bookingID;
            NumberOfMembers = numberOfMembers;
            Destination = destination;
            Start = start;
            End = end;
            


        }

        public override string ToString()
        {
            return $"BookingID: {BookingID}\n NumberOfMembers: {NumberOfMembers}\n Destination: {Destination}\n Start: {Start}\n End: {End}\n Overdue: {Overdue}";
        }

        public void AddMember(Member member)
        {
            foreach(Member members in ListOfMembers)
            {
                if (members.ID == member.ID)
                {
                    throw new Exception();
                }
                member.Add. 
            }
            
        }
    }
}

   