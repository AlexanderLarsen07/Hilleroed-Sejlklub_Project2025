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
        private static int _bookingID = 0;

        public int BookingID { get; private set; }
        public string Destination { get; private set; }

        public int NumberOfMembers { get; private set; }

        public DateTime Start { get; private set; }

        public DateTime End { get; private set; }
        
        public Member TheMember { get; private set; }

        public Boat TheBoat {get; private set;}

        public bool Overdue
        {
            get {return Start.AddHours(5) < End;}    
        }

        public List<Member> ListOfMembers;

        public Booking(string destination, int numberOfMembers, DateTime start, DateTime end, Member theMember, Boat theBoat)
        {
            if (theBoat.CanSail == true)
            {
                BookingID = _bookingID++;
                NumberOfMembers = numberOfMembers;
                Destination = destination;
                Start = start;
                End = end;
                TheMember = theMember;
                TheBoat = theBoat;
                ListOfMembers = new List<Member>();
        }
            else
            {
                throw new Exception("You booked a boat that cannot sail.");
            }

        }

        public override string ToString()
        {
            return $"BookingID: {BookingID}\n NumberOfMembers: {NumberOfMembers}\n Destination: {Destination}\n Start: {Start}\n End: {End}\n Overdue: {Overdue}" +
                $"ListOfMembers: {ListOfMembers.Count}"+
                $"\nMember: {TheMember}" +
                $"\nBoat {TheBoat}";

        }

        public void AddMember(Member member)
        {
            foreach(Member members in ListOfMembers)
            {
                if (members.MemberID == member.MemberID)
                {
                    throw new Exception("Member ID already exist");
                }
                ListOfMembers.Add(member);
            }
            
        }
    }
}

   