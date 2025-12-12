using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Boats;

namespace Hillerød_Sejlklub_Library.Services
{
    public class BookingRepo : IBookingRepo
    {
        private List<Booking> _bookings;

        public BookingRepo()
        {
            _bookings = new List<Booking>();
        }

        public List<Booking> GetAll()
        {
            return _bookings;
        }

        public void AddBooking(Booking booking)
        {
            DateTime start = booking.Start;
            foreach (Booking bookingOnList in _bookings)
            {
                if (booking.BookingID == bookingOnList.BookingID)
                {
                    throw new Exception(message: "BookingID already exist");
                }
                else if (booking.TheBoat.SailNumber == bookingOnList.TheBoat.SailNumber && booking.Start < bookingOnList.End && (booking.End > bookingOnList.Start))
                {
                    throw new Exception(message: "You booked a boat that is already booked for the time you chose.");

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
            throw new Exception(message: "BookingID doesn’t exist");
        }

        public void PrintAllBookings()
        {
            foreach(Booking bookingOnList in _bookings)
            {
                Console.WriteLine(bookingOnList);
            }
            
        }

        public void RemoveBookingByID(int BookingID)
        {
            int i = 0;
            while(_bookings.Count > i)
            {
                if(BookingID == _bookings[i].BookingID)
                {
                    _bookings.RemoveAt(i);
                    return;
                }
                i++;
            }
            
            throw new Exception(message: "BookingID doesn’t exist");
        }

       
    }
}
