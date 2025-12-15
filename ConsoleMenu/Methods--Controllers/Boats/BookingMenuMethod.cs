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
    public class BookingMenuMethod
    {
        private static string ReadChoice(string choices)
        {
            Console.Write("\x1b[2J"); // Clear screen
            Console.Write("\x1b[3J"); // Clear scrollback
            Console.Write("\x1b[H");  // Set cursor to home
            Console.Write(choices);
            string choice = Console.ReadLine();
            Console.Clear();
            return choice.ToLower();
        }
        public void BookingMenu(string theChoices, Member? member, BookingRepo bookingRepo, MemberRepo memberRepo, BoatRepo boatRepo)
        {
            string theChoice = ReadChoice(theChoices);
            while (theChoice != "q")
            {
                if (member == null)
                {
                    switch (theChoice)
                    {
                        case "1":
                            {
                                Console.WriteLine("Press q to exit.");
                                Console.WriteLine("bookings not available to guests, you need to become a member.");
                                Console.ReadLine();
                            }
                            break;
                    }
                    theChoice = ReadChoice(theChoices);
                }

                else if (member.Role == RoleEnum.Member)
                {
                    switch (theChoice)
                    {

                        case "1":
                            {
                                Console.WriteLine("Press \"q\" to quit.");
                                CreateAddBooking(bookingRepo, memberRepo, boatRepo);
                                break;
                            }
                    }
                    theChoice = ReadChoice(theChoices);
                }

                else if (member.Role == RoleEnum.Administrator)
                {
                    //ny userchoice for Admin
                    switch (theChoice)
                    {
                        case "1":
                            {
                                Console.WriteLine("Press \"q\" to quit.");
                                CreateAddBooking(bookingRepo, memberRepo, boatRepo);
                                Console.ReadLine();
                                break;
                            }
                        case "2":
                            {
                                Console.WriteLine("Press \"q\" to quit.");
                                Console.WriteLine("delete a booking by BookingID:");
                                int BookingID = int.Parse(Console.ReadLine());
                                bookingRepo.RemoveBookingByID(BookingID);
                                Console.ReadLine();
                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine("Press \"q\" to quit.");
                                Console.WriteLine("All bookings:");
                                bookingRepo.PrintAllBookings();
                                Console.ReadLine();
                                break;
                            }

                    }
                    theChoice = ReadChoice(theChoices);
                }

                else if (member.Role == RoleEnum.Chairman)
                {
                    //ny userchoice for chairman
                    switch (theChoice)
                    {
                        case "1":
                            {
                                Console.WriteLine("Press \"q\" to quit.");
                                CreateAddBooking(bookingRepo, memberRepo, boatRepo);
                                break;

                            }
                        case "2":
                            {
                                Console.WriteLine("Press \"q\" to quit.");
                                Console.WriteLine("delete a booking by BookingID:");
                                int BookingID = int.Parse(Console.ReadLine());
                                bookingRepo.RemoveBookingByID(BookingID);
                                Console.ReadLine();
                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine("Press \"q\" to quit.");
                                Console.WriteLine("All bookings:");
                                bookingRepo.PrintAllBookings();
                                Console.ReadLine();
                                break;
                            }
                    }
                    theChoice = ReadChoice(theChoices);
                }
            }
        }
        public void CreateAddBooking(BookingRepo bookingRepo, MemberRepo memberRepo, BoatRepo boatRepo)
        {
            Console.WriteLine("Make a new booking");

            Console.WriteLine("Enter destination");
            string destination = Console.ReadLine();

            Console.WriteLine("Enter start date (example: 2025 12 03 06 00 00)");
            DateTime start = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter end date (example: 2025 12 05 06 00 00)");
            DateTime end = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter member");
            int memberID = int.Parse(Console.ReadLine());
            Member member = memberRepo.GetMemberById(memberID);
            Console.WriteLine("Enter boat");
            string sailNumber = (Console.ReadLine());
            Boat boat = boatRepo.GetBoatBySailNumber(sailNumber);
            AddBookingController makeBooking =
            new AddBookingController(destination, start, end, member, boat, bookingRepo, memberRepo, boatRepo);

            makeBooking.AddTheCreatedBooking();
            Console.ReadLine();
        }
    }
}
