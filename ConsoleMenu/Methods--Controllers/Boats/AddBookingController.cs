using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Boats;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;
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
        public Booking TheBooking { get; set; }

        public AddBookingController(string destination, DateTime start, DateTime end, Member member, Boat boat, IBookingRepo theBooking)
        {
            TheBooking = new Booking(destination, start, end, member, boat);
            _bookings = theBooking;
        }
        public void AddTheBooking()
        {
            _bookings.AddBooking(TheBooking);
        }
    }
}
