using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ConsoleMenu.Menu;
using ConsoleMenu.Methods.Events;
using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Blogs;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;
using Hillerød_Sejlklub_Library.Services;

namespace ConsoleMenu.Controllers.Events
{
    public class EventMenuMethod
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
        public void EventMenu(string theChoices, Member? member, EventRepo eventRepo, SignupRepo signupRepo)
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
                                eventRepo.PrintAllEvents();
                                Console.WriteLine("Press q to exit.");
                                Console.ReadLine();
                            }
                            break;
                        case "2":
                            {
                                Console.WriteLine("Look up event by start date and end date. Format : yyyy-mm-dd hh:mm");//skriv format så user kan indsætte en valid datetime
                                Console.WriteLine("write start date:");
                                DateTime startDate = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("write end date:");
                                DateTime endDate = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine(eventRepo.ReturnByDateRange(startDate, endDate));
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
                                eventRepo.PrintAllEvents();
                                Console.WriteLine("Choose event by writing its title. Press \"q\" to quit.");
                                string title = Console.ReadLine();
                                List<Event> events = eventRepo.ReturnAllEventsByTitle(title);

                                bool isFalse = true;
                                while (isFalse)
                                {
                                    if (events.Count <= 0)
                                    {
                                        Console.WriteLine("No event with the given name was found.");
                                    }
                                    else
                                    {
                                        for (int i = 0; i <= events.Count; i++)
                                        {
                                            Console.WriteLine(events[i]);

                                            Console.WriteLine("press \"y\" to signup to event. Press \"n\" if Wrong event. Press \"q\" to cancel signing up.");

                                            string choice = Console.ReadLine();

                                            if (choice == "q".ToLower() || choice == "q".ToUpper())
                                            {
                                                isFalse = false;
                                            }
                                            else if (choice == "y".ToLower() || choice == "y".ToUpper())
                                            {
                                                Console.WriteLine("Make your comment");
                                                string comment = Console.ReadLine();
                                                Signup theSignup = new Signup(events[i], member, comment);
                                                Console.WriteLine($"Succesfully signed up to {events[i].Title}");
                                                Console.ReadLine();
                                            }
                                            else if (choice == "n".ToLower() || choice == "n".ToUpper())
                                            {
                                                continue;
                                            }
                                        }
                                    }
                                    isFalse = true;
                                }
                            }
                            break;
                        case "2":
                            {
                                Console.WriteLine("Look up event by start date and end date. Format : yyyy-mm-dd hh:mm");//skriv format så user kan indsætte en valid datetime
                                Console.WriteLine("write start date");
                                DateTime startDate = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("write end date");
                                DateTime endDate = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine(eventRepo.ReturnByDateRange(startDate, endDate));
                                Console.WriteLine("enter title of the Event you wish to sign up to.");
                                string title = Console.ReadLine();
                                List<Event> events = eventRepo.ReturnAllEventsByTitle(title);

                                bool isFalse = true;
                                while (isFalse)
                                {
                                    if (events.Count == 1)
                                    {
                                        Console.WriteLine("Write your comment:");
                                        string comment = Console.ReadLine();
                                        Signup theSignup = new Signup(events[0], member, comment);
                                        Console.WriteLine($"Succesfully signed up to {events[0].Title}");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        for (int i = 0; i < events.Count; i++)
                                        {
                                            Console.WriteLine(events[i]);

                                            Console.WriteLine("press \"y\" to signup to event. Press \"n\" if Wrong event. Press \"q\" to cancel signing up.");
                                            string choice = Console.ReadLine();

                                            if (choice == "q".ToLower() || choice == "q".ToUpper())
                                            {
                                                isFalse = false;
                                            }
                                            else if (choice == "y".ToLower() || choice == "y".ToUpper())
                                            {
                                                Console.WriteLine("Write your comment:");
                                                string comment = Console.ReadLine();
                                                Signup theSignup = new Signup(events[i], member, comment);
                                                Console.WriteLine($"Succesfully signed up to {events[i].Title}");
                                                Console.ReadLine();
                                            }
                                            else if (choice == "n".ToLower() || choice == "n".ToUpper())
                                            {
                                                continue;
                                            }
                                        }
                                    }
                                    isFalse = true;
                                }
                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine(signupRepo.ReturnAllByMember(member));
                                Console.WriteLine("Choose the signup to edit by writing the events title");
                                string title = Console.ReadLine();
                                if(signupRepo.ReturnAllByMember(member).Count == 1)
                                {
                                    Console.WriteLine("Write edited comment:");
                                    string comment = Console.ReadLine();
                                    signupRepo.EditComment(member, comment, title);
                                }
                                    break;
                            }
                        case "4":
                            {
                                Console.WriteLine(signupRepo.ReturnAllByMember(member));
                                Console.WriteLine("Choose signup to delete by writing the events title");
                                string title = Console.ReadLine();
                                List<Signup> signups = signupRepo.ReturnAllByEventTitle(title);
                                for (int i = 0; i <= signups.Count; i++)
                                {
                                    if (signups[i].Member == member)
                                    {
                                        signups.Remove(signups[i]);
                                    }
                                }
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("invalid input try these options:");
                            }
                            break;
                    }
                    theChoice = ReadChoice(theChoices);
                }

                else if (member.Role == RoleEnum.Administrator)
                {
                    //ny userchoice for Admin
                    switch (theChoice)
                    {
                        case "1":
                            
                            break;
                    }
                    theChoice = ReadChoice(theChoices);
                }

                else if (member.Role == RoleEnum.Chairman)
                {
                    //ny userchoice for chairman
                    switch (theChoice)
                    {
                        case "1":

                            break;
                    }
                    theChoice = ReadChoice(theChoices);
                }
            }
        }
    }
}
