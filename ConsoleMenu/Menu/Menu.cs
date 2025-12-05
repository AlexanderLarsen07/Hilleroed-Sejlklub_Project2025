using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Hillerød_Sejlklub_Library;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;
using Hillerød_Sejlklub_Library.Services;

namespace ConsoleMenu.Menu
{
    public class Menu
    {
        // static strings for choices
        static string LoginChoices = "\t 1. Sign in as guest.\t\n 2. Sign in as Member. \t\n q. Exit.";

        //Gæst - basal adgang til systemet, kan se blogindlæg,
        //både og generel info om klubben og oprette sig som medlem, kan ikke leje både og melde sig til events.

        //Medlem - har samme adgang til systemet som en gæst,
        //men kan melde sig til events, leje både og indberette skader/fejl.

        //Administrator - har samme adgang til systemet som et medlem,
        //men kan lave blogindlæg, se, redigere, slette og tilføje både, events og indberetninger om skader/fejl.

        //Formand - har samme adgang som en administrator,
        //men kan fjerne og tilføje administratorer og give formandskabet til en anden.


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
                    //_menuItemRepository.PrintMenu();
                    Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Valg 2");
                        Console.WriteLine("Enter Mail : ");
                        bool validMail = false;
                        while (!validMail)
                        {
                            string mail = Console.ReadLine();
                            if (_memberRepo.ReturnMemberByMail(mail) == null)
                            {
                                Console.WriteLine("Mail does not exist.");
                            }
                            else if (_memberRepo.ReturnMemberByMail(mail).Mail == mail)
                            {
                                validMail = true;
                                Console.WriteLine("Enter Password : ");
                                bool validPassword = false;
                                while (!validPassword)
                                {
                                    string password = Console.ReadLine();
                                    if (_memberRepo.ReturnMemberByMail(mail).Password != password)
                                    {
                                        Console.WriteLine("Wrong password.");
                                    }
                                    else if(_memberRepo.ReturnMemberByMail(mail).Password == password)
                                    {
                                        Member member = _memberRepo.ReturnMemberByMail(mail);
                                        Console.WriteLine($"Welcome {member.Name}");
                                    }
                                }
                            }
                        }

                        break;
                    default:
                        Console.WriteLine("Angiv et tal fra 1..4 eller q for afslut");
                        break;
                }
                theChoice = ReadChoice(LoginChoices);
            }
        }
    } 
}