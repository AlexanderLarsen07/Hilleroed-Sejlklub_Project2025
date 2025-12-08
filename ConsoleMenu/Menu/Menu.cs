using Hillerød_Sejlklub_Library;
using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Blogs;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;
using Hillerød_Sejlklub_Library.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ConsoleMenu.Menu
{
    public class Menu
    {
        // static strings for choices
        static string LoginChoices = "\t 1. Sign in as guest.\t\n 2. Sign in as Member. \t\n q. Exit.";
        static string GuestMenuChoices = "";//Implement TODO.
        static string GuestEventsChoices = "";//Implement TODO.

        //Gæst - basal adgang til systemet, kan se blogindlæg,
        //både og generel info om klubben og oprette sig som medlem, kan ikke leje både og melde sig til events.

        //Medlem - har samme adgang til systemet som en gæst,
        //men kan melde sig til events, leje både og indberette skader/fejl.

        //Administrator - har samme adgang til systemet som et medlem,
        //men kan lave blogindlæg, se, redigere, slette og tilføje både, events og indberetninger om skader/fejl.

        //Formand - har samme adgang som en administrator,
        //men kan fjerne og tilføje administratorer og give formandskabet til en anden.
        //static string MemberEventChoices = "";
        //public void Events(string extraChoices)// lav de forskellige menu funktioner sådanne.
        //{
        //    if(member)
        //    switch (MemberEventsChoices + extraChoices)
        //    {
        //        case "1":

        //            break;
        //    }
        //    else if (admin)
        //    {
        //        switch (MemberEventsChoices + extraChoices)
        //        {
        //            case "1":

        //                break;
        //        }
        //    }
        //    else if (chairman)
        //    {
        //        switch (MemberEventChoices + extraChoices)
        //        {
        //            case "1":

        //                break;
        //        }
        //    }
        //}

        // lav repos
        private MemberRepo _memberRepo = new MemberRepo();
        private BlogRepo _blogRepo = new BlogRepo();
        private BoatLotRepo _boatLotRepo = new BoatLotRepo();
        private BoatRepo _boatRepo = new BoatRepo();
        private EventRepo _eventRepo = new EventRepo();
        private SignupRepo _signupRepo = new SignupRepo();
        private BookingRepo _bookingRepo = new BookingRepo();

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

                                    break;
                                case "2":

                                    break;
                            }
                        }
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Valg 2");
                        string mail = "";
                        string password = "";
                        bool validMail = false;
                        while (!validMail)
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
                                while (!validPassword)
                                {
                                    Console.WriteLine($"Mail : {mail}");
                                    Console.WriteLine($"Enter Password : ");
                                    password = Console.ReadLine();
                                    if (member.Password != password)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Wrong password.");
                                    }
                                    else if (member.Password == password)
                                    {
                                        Console.WriteLine($"Welcome {member.Name}");
                                        if (member.Role == RoleEnum.Member)
                                        {
                                            string extra = "";
                                            //selcet memberMenu string
                                        }
                                        else if (member.Role == RoleEnum.Administrator)
                                        {
                                            //select adminMenu string
                                        }
                                        else if (member.Role == RoleEnum.Chairman)
                                        {
                                            //string extra = MemberEventChoices;
                                            //select chairmanMenu string
                                        }
                                        //menu // switch case
                                        //method(member , extra)
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
//        public void MenuBlog(Member memberType, string member)
//        {

//            bool input = true;
//            while (input)
//            {
//                string? userChoice = Console.ReadLine();
//                Member memer = new Member("name", 2, MembershipEnum.Medlem, "mail", "password", 007); //for at teste - normal skal man kunne logge ind først inden man når hertil korrekt?
//                if (memberType.Role == RoleEnum.Member)
//                {
//                    Console.WriteLine($"1. Add a blog\n2. Edit a blog\n3. Delete a blog\n\"q\"to quit");

//                    switch (userChoice)
//                    {
//                        case "1": //se blogs / printe dem alle
//                            {

//                            }
//                            break;
//                        case "2":
//                            {
//                               //søge efter blogs 
//                               //tjek eventRepository klassen på søg metoden
//                            }
//                            break;
//                        case "3":
//                            {
//                                //kommenter
//                            }
//                            break;
//                        //case 4 for opdater listen a blog?
//                        case "q":
//                            {
//                                input = false;
//                            }
//                            break;
//                        default:
//                            {
//                                Console.WriteLine("invalid input try these options:");
//                            }
//                            break;
//                    }
//                }

//                else if(memberType.Role == RoleEnum.Administrator)
//                {
//                    //ny userchoice for Admin
//                    switch (userChoice + member)
//                    {
//                        case "1":
//                            Console.WriteLine("haifaf");
//                            break;
//                    }
//                }
//                else if(memberType.Role == RoleEnum.Chairman)
//                {
//                    //ny userchoice for chairman
//                    switch (userChoice + member)
//                    {
//                        case "1":

//                            break;
//                    }
//                }
//                else
//                {
//                    Console.WriteLine("Sign in or sign up to see what's going on in the blog!");
//                }



//            }

//        }
//        //comment metode her
//    } 
//}

//til Admin og chairman
//case "1":
//    {
//        Console.WriteLine("Add a headline");
//        string? headline = Console.ReadLine(); //exception for intet input? det kan i hvertfald null

//        Console.WriteLine("Add a text");
//        string? text = Console.ReadLine(); //exception for intet input? det kan i hvertfald null

//        Console.WriteLine("Add a description");
//        string? description = Console.ReadLine(); //exception for intet input? det kan i hvertfald null

//        _blogRepo.AddBlog(new Blog(headline, memer, text, description));

//        Console.WriteLine("Added the blog");
//    }
//    break;
//case "2":
//    {
//        //rediger blog og implementer at man faktisk kan det
//    }
//    break;
//case "3":
//    {
//        //slet en blog
//    }
//    break;
////case 4 for opdater listen a blog? og case 5 for at printe dem alle? case 5 for medlem
//case "q":
//    {
//        input = false;
//    }
//    break;
//default:
//    {
//        Console.WriteLine("invalid input try these options:");
//    }
//    break;