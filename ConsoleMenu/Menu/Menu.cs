using ConsoleMenu.Controllers.Events;
using ConsoleMenu.Methods.Members;
using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;
using Hillerød_Sejlklub_Library.Services;

namespace ConsoleMenu.Menu
{
    public class Menu
    {
        // static strings for choices
        static string LoginChoices = " 1. Sign in as guest.\t\n 2. Sign in as Member. \t\n q. Exit.";
        
        static string GuestMenuChoices = " 1. Events.\t\n 2. Signup.\t\n q. Exit.";//Implement TODO.
        static string MemberMenuChoices = " 1. Events.\t\n 2. Members \t\n q. Exits.";
        static string AdminMenuChoices = "";
        static string ChairmanMenuChoices = "";

        static string GuestEventChoices = " 1. View all events. \t\n 2. Search for events by date. \t\n q. Exit.";//DONE
        static string MemberEventChoices = " 1. View all event/signup. \t\n 2. Search for events by date/signup. \t\n 3. Edit a Comment on a signup. \t\n 4. Delete a signup. \t\n q. quit.";//DONE
        static string AdminEventChoices = " 1. View all event. \t\n 2. Search for events by date. \t\n 3. Edit a Comment on a signup. \t\n 4. Delete a signup. \t\n 5. Create new event. \t\n q. quit.";


        static string MemberMemberChoices = "1. View your details\t\n 2. Edit your account\t\n 3. View boat lots\t\n q. Exits.";
        static string AdminMemberChoices = "1. View all members\t\n 2. Search for a specific member of their id\t\n 3. Boat lots\t\n 4.simple statistics\t\n 5. Delete a user or make a custom user\t\n 6. View your account\t\n 7. Edit details of your account\t\n 8. Add boat lots\t\n 9. Events. \t\n q. Exits.";
        static string ChairmanMemberChoices = "1. Crud Admins\t\n 2. Change chairman\t\n 3. View all members\t\n 4. Search for a specific member of their id\t\n 5. Boat lots\t\n 6.simple statistics\t\n 7. Delete a user or make a custom user\t\n 8. View your account\t\n 9. Edit details of your account\t\n 10. Add boat lots\t\n 11. Events. \t\n q. Exits.";

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

        private EventMenuMethod eventMenu = new EventMenuMethod();
        private MemberMenu memberMenu = new MemberMenu();

        public void SetChairman(Member member) //slet
        {
            _memberRepo.AddMember(member);
        }
        public void AddEvent(Event even)
        {
            _eventRepo.AddEvent(even);
        }
        public void AddBoatLot(BoatLot boatlot)
        {
            _boatLotRepo.AddBoatLot(boatlot);
        }
        public void AddSignup(Signup signup)
        {
            _signupRepo.AddSignup(signup);
        }

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
                        Console.WriteLine("Valg 1");
                        //print guestMenu
                        string guestMenuChoices = ReadChoice(GuestMenuChoices);
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
                                        /*memberMenu.Roles(GuestMemberChoices, null, _memberRepo, _boatLotRepo);*/ //MemberMenu
                                    }
                                    break;
                            }
                            guestMenuChoices = ReadChoice(GuestMenuChoices);
                        }
                        //Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Valg 2");
                        string mail = "";
                        string password = "";
                        bool validMail = false;
                        while (!validMail && mail != "q")
                        {
                            Console.WriteLine($"Enter Mail : ");
                            mail = Console.ReadLine();
                            Member? member = _memberRepo.ReturnMemberByMail(mail);
                            if (member == null)
                            {
                                Console.Clear();
                                Console.WriteLine("Mail does not exist.");
                            }
                            else if (member.Mail == mail)
                            {
                                validMail = true;
                                bool validPassword = false;
                                while (!validPassword && password != "q")
                                {
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
                                        if (member.Role == RoleEnum.Member)
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
                                                }
                                                memberMenuChoices = ReadChoice(MemberMenuChoices);
                                            }
                                        }
                                        else if (member.Role == RoleEnum.Administrator)
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
                                                }
                                                memberMenuChoices = ReadChoice(MemberMenuChoices);
                                            }
                                        }
                                        else if (member.Role == RoleEnum.Chairman)
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