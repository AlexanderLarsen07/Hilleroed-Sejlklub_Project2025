using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models;

namespace Hillerød_Sejlklub_Library
{
    public class BookingRepo : IBookingRepo
    {
        private List<Booking> _bookings;

        public BookingRepo()
        {
            _bookings = new List<Booking>();
        }
        public void AddBooking(Booking booking)
        {
            foreach (Booking bookingOnList in _bookings)
            {
                if (booking.BookingID == bookingOnList.BookingID)
                {
                    throw new Exception("BookingID already exist");
                }
                
            }
            _bookings.Add(booking);
        }

        public Booking GetBookingByID(int BookingID)
        {
            for(int i = 0; _bookings.Count > i; i++)
            {
                if(BookingID == _bookings[i].BookingID)
                {
                    return _bookings[i];
                }
            }
            throw new Exception("BookingID doesn’t exist");
        }

        public void PrintAllBookings()
        {
            throw new NotImplementedException();
        }

        public void RemoveBookingByID(int BookingID)
        {
            int i = 0;
            while(_bookings.Count > i)
            {
                if(BookingID == _bookings[i].BookingID)
                {
                    _bookings.RemoveAt(i);
                }

            }
            i++;
        }
    }
}
