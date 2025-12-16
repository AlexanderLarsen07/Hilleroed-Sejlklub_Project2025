using ConsoleMenu.Controllers.Events;
using ConsoleMenu.Methods.Members;
using ConsoleMenu.Methods__Controllers.Blogs;
using ConsoleMenu.Methods__Controllers.Boats;
using Hillerød_Sejlklub_Library.Data;
using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;
using Hillerød_Sejlklub_Library.Services;

namespace ConsoleMenu.Menu
{
    public class Menu
    {
        // static strings for choices
        static string LoginChoices = " 1. Sign in as guest.\t\n 2. Sign in as Member. \t\n q. Exit. \n\t ";
        
        static string GuestMenuChoices = " 1. Events.\t\n 2. Signup.\t\n 3. Boats\t\n q. Exit. \n\t ";//Implement TODO.
        static string MemberMenuChoices = " 1. Events.\t\n 2. Members \t\n q. Exits. \n\t ";

        static string GuestEventChoices = " 1. View all events. \t\n 2. Search for events by date. \t\n q. Exit. \n\t ";
        static string MemberEventChoices = " 1. View all event/signup. \t\n 2. Search for events by date/signup. \t\n 3. Edit a Comment on a signup. \t\n 4. Delete a signup. \t\n q. quit. \n\t ";
        static string AdminEventChoices = " 1. View all event. \t\n 2. Search for events by date. \t\n 3. Edit a Comment on a signup. \t\n 4. Delete a signup. \t\n 5. Create new event. \t\n q. quit. \n\t ";


        static string MemberMemberChoices = "1. View your details\t\n 2. Edit your account\t\n 3. View boat lots\t\n q. Exits. \n\t ";
        static string AdminMemberChoices = "1. View all members\t\n 2. Search for a specific member of their id\t\n 3. Boat lots\t\n 4.simple statistics\t\n 5. Delete a user or make a custom user\t\n 6. View your account\t\n 7. Edit details of your account\t\n 8. Add boat lots\t\n 9. Events. \t\n q. Exits. \n\t ";
        static string ChairmanMemberChoices = "1.  Crud Admins\t\n2.  Change chairman\t\n3.  View all members\t\n4.  Search for a specific member of their id\t\n5.  Boat lots\t\n6.  Simple statistics\t\n7.  Delete a user or make a custom user\t\n8.  View your account\t\n9.  Edit details of your account\t\n10. Add boat lots\t\n11. Events.\t\n q. Exits.\t\n\t\nIndtast Nummer: \t\n ";

        static string GuestBoatChoices = "1. See the boats.\t\n q. Exit \t\n";
        static string MemberBoatChoices = "1. See all the boats with all the details.\t\n q. Exit. \t\n";
        static string AdminBoatChoices = "1. See all boats\t\n2. Add boat\t\n3. Delete boat\t\nq. Exit\t\n";

        static string GuestBookingChoices = "1. bookings not available to guests, you need to become a member.\t\n q. Exit. \t\n";
        static string MemberBookingChoices = "1. Create booking \t\n q. Exit. \t\n";
        static string AdminBookingChoices = "1. Create booking\n2. Delete booking\n3. View all bookings\nq. Exit\n";

        static string GuestRepairChoices = "1. bookings not available to guests, you need to become a member.\t\nq. Exit. \t\n";
        static string MemberRepairChoices = "1. Repairs to each boat\t\n2. Create repair\t\nq. Exit. \t\n\"";
        static string AdminRepairChoices = "1. Repairs to each boat\t\n2. Create repair\t\n3. delete repair\t\nq. Exit. \t\n\""; 
        //Gæst - basal adgang til systemet, kan se blogindlæg,
        //både og generel info om klubben og oprette sig som medlem, kan ikke leje både og melde sig til events.

        //Medlem - har samme adgang til systemet som en gæst,
        //men kan melde sig til events, leje både og indberette skader/fejl.

        //Administrator - har samme adgang til systemet som et medlem,
        //men kan lave blogindlæg, se, redigere, slette og tilføje både, events og indberetninger om skader/fejl.

        //Formand - har samme adgang som en administrator,
        //men kan fjerne og tilføje administratorer og give formandskabet til en anden.

        private MemberRepo _memberRepo = new MemberRepo();
        private BlogRepo _blogRepo = new BlogRepo();
        private BoatLotRepo _boatLotRepo = new BoatLotRepo();
        private BoatRepo _boatRepo = new BoatRepo();
        private CommentRepo _commentRepo = new CommentRepo();
        private EventRepo _eventRepo = new EventRepo();
        private SignupRepo _signupRepo = new SignupRepo();
        private BookingRepo _bookingRepo = new BookingRepo();
        private RepairRepo _repairRepo = new RepairRepo();

        private EventMenuMethod eventMenu = new EventMenuMethod();
        private MemberMenu memberMenu = new MemberMenu();
        private BlogMenuMethod blogMenu = new BlogMenuMethod();
        private BoatMenuMethod boatMenu = new BoatMenuMethod();
        private RepairMenuMethod repairMenu = new RepairMenuMethod();
        private BookingMenuMethod bookingMenu = new BookingMenuMethod();
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

        // lav switch case
        public void ShowLoginPage()
        {
            string theChoice = ReadChoice(LoginChoices);
            while (theChoice != "q")
            {
                switch (theChoice)
                {
                    case "1":
                        //Console.WriteLine("Valg 1");
                        //print guestMenu
                        string guestMenuChoices = ReadChoice(GuestMenuChoices);//guestfield
                        while (guestMenuChoices != "q")
                        {
                            switch (guestMenuChoices)
                            {
                                case "1":
                                    {
                                        eventMenu.EventMenu(GuestEventChoices, null, _eventRepo, _signupRepo);
                                    }
                                    break;
                                case "2":
                                    {
                                        memberMenu.GuestMemberMenu(_memberRepo);
                                    }
                                    break;
                                case "3":
                                    {
                                        boatMenu.BoatMenu(GuestBoatChoices, null, _boatRepo);
                                    }
                                    break;
                                case "4":
                                    {
                                        bookingMenu.BookingMenu(GuestBookingChoices, null, _bookingRepo, _memberRepo, _boatRepo);
                                    }
                                    break;
                                case "5":
                                    {
                                        repairMenu.RepairMenu(GuestRepairChoices, null, _repairRepo, _boatRepo);
                                    }
                                    break;
                                case "6":
                                    {
                                        //blogMenu.BlogMenu(null, _blogRepo, _commentRepo, /*add blogGuestMenu string*/);
                                    }
                                    break;
                            }
                            guestMenuChoices = ReadChoice(GuestMenuChoices);
                        }
                        //Console.ReadLine();
                        break;
                    case "2":
                        /*Console.WriteLine("Valg 2");*///loginfield
                        string mail = "";
                        string password = "";
                        bool validMail = false;
                        while (!validMail && mail != "q")
                        {
                            Console.WriteLine("Press \"q\" to cancel signing in.");
                            Console.WriteLine($"Enter Mail : ");
                            mail = Console.ReadLine();
                            Member? member = _memberRepo.ReturnMemberByMail(mail);
                            if (member == null)
                            {
                                Console.Clear();
                                Console.WriteLine("Mail does not exist.");
                            }
                            else
                            {
                                validMail = true;
                                bool validPassword = false;
                                while (!validPassword && password != "q")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Press \"q\" to cancel signing in.");
                                    Console.WriteLine($"Mail : {mail}");
                                    Console.WriteLine($"Enter Password : ");
                                    password = Console.ReadLine();
                                    if (member.Password != password)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Wrong password.");
                                    }

                                    else
                                    {
                                        Console.WriteLine($"Welcome {member.Name}");
                                        if (member.Role == RoleEnum.Member)//memberfield
                                        {
                                            Console.WriteLine($"Signed in as : {member.Role}");
                                            string memberMenuChoices = ReadChoice(MemberMenuChoices);
                                            if(memberMenuChoices == "q")
                                            {
                                                mail = "q";
                                                password = "q";
                                                break;
                                            }
                                            while (memberMenuChoices != "q")
                                            {
                                                switch (memberMenuChoices)
                                                {
                                                    case "1":
                                                        {
                                                            eventMenu.EventMenu(MemberEventChoices, member, _eventRepo, _signupRepo);
                                                        }
                                                        break;
                                                    case "2":
                                                        {
                                                            boatMenu.BoatMenu(MemberBoatChoices, member, _boatRepo);
                                                        }
                                                        break;
                                                    case "3":
                                                        {
                                                            bookingMenu.BookingMenu(MemberBookingChoices, member, _bookingRepo, _memberRepo, _boatRepo);
                                                        }
                                                        break;
                                                    case "4":
                                                        {
                                                            repairMenu.RepairMenu(MemberRepairChoices, member, _repairRepo, _boatRepo);
                                                        }
                                                        break;
                                                }
                                                memberMenuChoices = ReadChoice(MemberMenuChoices);
                                            }
                                        }
                                        else if (member.Role == RoleEnum.Administrator)//admin field
                                        {
                                            Console.WriteLine($"Signed in as : {member.Role}");
                                            string memberMenuChoices = ReadChoice(MemberMenuChoices);
                                            if (memberMenuChoices == "q")
                                            {
                                                mail = "q";
                                                password = "q";
                                                break;
                                            }
                                            while (memberMenuChoices != "q")
                                            {
                                                switch (memberMenuChoices)
                                                {
                                                    case "1":
                                                        {
                                                            eventMenu.EventMenu(MemberEventChoices, member, _eventRepo, _signupRepo);
                                                        }
                                                        break;
                                                    case "2":
                                                        {
                                                            boatMenu.BoatMenu(AdminBoatChoices, member, _boatRepo);
                                                        }
                                                        break;
                                                    case "3":
                                                        {
                                                            bookingMenu.BookingMenu(AdminBookingChoices, member, _bookingRepo, _memberRepo, _boatRepo);
                                                        }
                                                        break;
                                                    case "4":
                                                        {
                                                            repairMenu.RepairMenu(AdminRepairChoices, member, _repairRepo, _boatRepo);
                                                        }
                                                        break;
                                                }
                                                memberMenuChoices = ReadChoice(MemberMenuChoices);
                                            }
                                        }
                                        else if (member.Role == RoleEnum.Chairman) //chairmanfield
                                        {
                                            Console.WriteLine($"Signed in as : {member.Role}");
                                            string memberMenuChoices = ReadChoice(MemberMenuChoices);
                                            if (memberMenuChoices == "q")
                                            {
                                                mail = "q";
                                                password = "q";
                                                break;
                                            }
                                            while (memberMenuChoices != "q")
                                            {
                                                switch (memberMenuChoices)
                                                {
                                                    case "1":
                                                        {
                                                            eventMenu.EventMenu(AdminEventChoices, member, _eventRepo, _signupRepo);
                                                        }
                                                        break;
                                                    case "2":
                                                        {
                                                            memberMenu.Roles(ChairmanMemberChoices, member, _memberRepo, _boatLotRepo);
                                                        }
                                                        break;
                                                    case "3":
                                                        {
                                                            boatMenu.BoatMenu(AdminBoatChoices, member, _boatRepo);
                                                        }
                                                        break;
                                                    case "4":
                                                        {
                                                            bookingMenu.BookingMenu(AdminBookingChoices, member, _bookingRepo, _memberRepo, _boatRepo);
                                                        }
                                                        break;
                                                    case "5":
                                                        {
                                                            repairMenu.RepairMenu(AdminRepairChoices, member, _repairRepo, _boatRepo);
                                                        }
                                                        break;
                                                }
                                                memberMenuChoices = ReadChoice(MemberMenuChoices);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Angiv et tal fra 1-2 eller q for afslut");
                        break;
                }
                theChoice = ReadChoice(LoginChoices);
            }
        }
    }
}