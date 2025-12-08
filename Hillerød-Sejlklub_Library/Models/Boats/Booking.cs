using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub_Library.Models.Members;

namespace Hillerød_Sejlklub_Library.Models.Boats
{
    public class Booking
    {
        private static int _bookingID = 1;

        public int BookingID { get; private set; }
        public string Destination { get; private set; }

        public DateTime Start { get; private set; }

        public DateTime End { get; private set; }
        
        public Member TheMember { get; private set; }

        public Boat TheBoat {get; private set;}

        public bool Overdue
        {
            get {return Start.AddHours(5) < End;}    
        }

        public List<Member> ListOfMembers;

        public Booking(string destination, DateTime start, DateTime end, Member theMember, Boat theBoat)
        {
            if (theBoat.CanSail == true)
            {
                BookingID = _bookingID++;
                Destination = destination;
                Start = start;
                End = end;
                TheMember = theMember;
                TheBoat = theBoat;
                ListOfMembers = new List<Member>();
                ListOfMembers.Add(theMember);
            }
            else
            {
                throw new Exception("You booked a boat that cannot sail.");
            }

        }

        

        public void AddMember(Member member)
        {
            foreach(Member memberOnList in ListOfMembers)
            {
                if (member.PhoneNumber == memberOnList.PhoneNumber)
                {
                    throw new Exception("Member already exist");
                }
                
            }
            ListOfMembers.Add(member);
        }

        public override string ToString()
        {
            return $"BookingID: {BookingID}\nNumberOfMembers: {ListOfMembers.Count}\nDestination: {Destination}\nStart: {Start}\nEnd: {End}\nOverdue: {Overdue}" +
                $"\nMember: {TheMember}" +
                $"\nBoat {TheBoat}";

        }
    }
}

   