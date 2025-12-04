using Hillerød_Sejlklub_Library.Models.Boats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Interfaces
{
    public interface IBookingRepo
    {
        void AddBooking(Booking booking);
        Booking GetBookingByID(int BookingID);
        void RemoveBookingByID(int BookingID);

        void PrintAllBookings();
    }
}
