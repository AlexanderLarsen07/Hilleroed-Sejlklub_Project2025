using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;
using Hillerød_Sejlklub_Library.Services;

namespace ConsoleMenu.Methods__Controllers.Helpers
{
    public class EventMenuHelpers
    {
        public void EditComment(SignupRepo signupRepo, Member member)
        {
            foreach (Signup signup in signupRepo.ReturnAllByMember(member))
            {
                Console.WriteLine(signup.ToString());
            }
            Console.WriteLine("Choose the signup to edit by writing the events title");
            string title = Console.ReadLine();
            List<Signup> signups = [];
            for (int i = 0; i < signupRepo.ReturnAllByEventTitle(title).Count; i++)
            {
                if (signupRepo.ReturnAllByEventTitle(title)[i].Member == member)
                {
                    signups.Add(signupRepo.ReturnAllByEventTitle(title)[i]);
                }
            }
            bool isFalse = true;
            while (isFalse)
            {
                if (signups.Count == 0)
                {
                    Console.WriteLine("No event with the given title could be found.");
                    Console.ReadLine();
                    isFalse = false;
                }
                else
                {
                    for (int i = 0; i < signups.Count; i++)
                    {
                        if (signups[i].Member == member)
                        {
                            Console.Clear();
                            Console.WriteLine(signupRepo.ReturnAllByEventTitle(title)[i]);

                            Console.WriteLine("press \"y\" to Edit. Press \"n\" if wrong signup. Press \"q\" to cancel editing comment.");
                            string choice = Console.ReadLine().ToLower();

                            if (choice == "q")
                            {
                                isFalse = false;
                            }
                            else if (choice == "y")
                            {
                                Console.WriteLine("Write edited comment:");
                                string comment = Console.ReadLine();
                                signupRepo.EditComment(member, comment, title);
                                Console.WriteLine("Comment added.");
                                Console.ReadLine();
                            }
                            else if (choice == "n")
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input.");
                                Console.ReadLine();
                            }
                        }
                    }
                }
            }
        }
        public void RemoveSignup(SignupRepo signupRepo, Member member)
        {
            foreach (Signup signup in signupRepo.ReturnAllByMember(member))
            {
                Console.WriteLine(signup.ToString());
            }
            Console.WriteLine("Choose the signup to remove by writing the events title");
            string title = Console.ReadLine();
            List<Signup> signups = [];
            for (int i = 0; i < signupRepo.ReturnAllByEventTitle(title).Count; i++)
            {
                if (signupRepo.ReturnAllByEventTitle(title)[i].Member == member)
                {
                    signups.Add(signupRepo.ReturnAllByEventTitle(title)[i]);
                }
            }
            bool isFalse = true;
            while (isFalse)
            {
                if (signups.Count == 0)
                {
                    Console.WriteLine("No event with the given title could be found.");
                    Console.ReadLine();
                    isFalse = false;
                }
                else
                {
                    for (int i = 0; i < signups.Count; i++)
                    {
                        if (signups[i].Member == member)
                        {
                            Console.Clear();
                            Console.WriteLine(signupRepo.ReturnAllByEventTitle(title)[i]);

                            Console.WriteLine("press \"y\" to remove. Press \"n\" if wrong signup. Press \"q\" to cancel removing signups.");
                            string choice = Console.ReadLine().ToLower();

                            if (choice == "q")
                            {
                                isFalse = false;
                            }
                            else if (choice == "y")
                            {
                                signupRepo.RemoveSignup(signups[i]);
                                Console.WriteLine("Signup removed.");
                                Console.ReadLine();
                            }
                            else if (choice == "n")
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input.");
                                Console.ReadLine();
                            }
                        }
                    }
                }
            }
        }
        public void LookupEventByDateRange(EventRepo eventRepo, Member member, SignupRepo signupRepo)
        {
            Console.WriteLine("Look up event by start date and end date. Format : yyyy-mm-dd hh:mm");//skriv format så user kan indsætte en valid datetime
            Console.WriteLine("write start date");
            DateTime startDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("write end date");
            DateTime endDate = DateTime.Parse(Console.ReadLine());
            foreach (Event even in eventRepo.ReturnByDateRange(startDate, endDate))
            {
                Console.WriteLine(even.ToString());
            }
            Console.WriteLine("enter title of the Event you wish to sign up to.");
            string title = Console.ReadLine();
            List<Event> events = eventRepo.ReturnAllEventsByTitle(title);

            bool isFalse = true;
            while (isFalse)
            {
                if (events.Count <= 0)
                {
                    Console.WriteLine("No event with the given title could be found.");
                    isFalse = false;
                }
                else if (events.Count == 1 && !events[0]._signups.Count.Equals(events[0].MaxMembers) && !eventRepo.SignupExistsCheck(member, events[0]))
                {
                    Console.WriteLine("Write your comment:");
                    string comment = Console.ReadLine();
                    Signup theSignup = new Signup(events[0], member, comment);
                    signupRepo.AddSignup(theSignup);
                    Console.WriteLine($"Succesfully signed up to {events[0].Title}");
                    isFalse = false;
                    Console.ReadLine();
                }
                else if (events.Count > 1)
                {
                    for (int i = 0; i < events.Count; i++)
                    {
                        if (!events[i]._signups.Count.Equals(events[i].MaxMembers) && !eventRepo.SignupExistsCheck(member, events[i]))
                        {
                            Console.WriteLine(events[i]);

                            Console.WriteLine("press \"y\" to signup to event. Press \"n\" if Wrong event. Press \"q\" to cancel signing up.");
                            string choice = Console.ReadLine().ToLower();

                            if (choice == "q")
                            {
                                isFalse = false;
                            }
                            else if (choice == "y")
                            {
                                Console.WriteLine("Write your comment:");
                                string comment = Console.ReadLine();
                                Signup theSignup = new Signup(events[i], member, comment);
                                signupRepo.AddSignup(theSignup);
                                Console.WriteLine($"Succesfully signed up to {events[i].Title}");
                                Console.ReadLine();
                            }
                            else if (choice == "n")
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input.");
                                Console.ReadLine();
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Event not found.");
                    Console.ReadLine();
                    isFalse = false;
                }
            }
        }
    }
}
