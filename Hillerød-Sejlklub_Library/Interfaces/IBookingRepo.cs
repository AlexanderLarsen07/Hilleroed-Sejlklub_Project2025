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
        public List<Booking> GetAll();
        public void AddBooking(Booking booking); 
        public Booking GetBookingByID(int BookingID); 
        public void RemoveBookingByID(int BookingID);
        public void PrintAllBookings();
    }
}
