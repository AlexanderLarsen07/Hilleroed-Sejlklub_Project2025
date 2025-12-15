using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Boats;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;
using Hillerød_Sejlklub_Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Methods__Controllers.Boats
{
    public class AddBookingController
    {

        IBookingRepo _bookings;

        IBoatRepo _boat;

        IMemberRepo _memberDictionary;
        public Booking TheBooking { get; set; }

        public AddBookingController(string destination, DateTime start, DateTime end, Member member, Boat boat, BookingRepo bookingRepo, MemberRepo memberRepo, BoatRepo boatRepo)
        {
            TheBooking = new Booking(destination, start, end, member, boat);
            _bookings = bookingRepo;
            _boat = boatRepo;
            _memberDictionary = memberRepo;
        }

        public void AddTheCreatedBooking()
        {
            _bookings.AddBooking(TheBooking);
       
        }
    }
}
