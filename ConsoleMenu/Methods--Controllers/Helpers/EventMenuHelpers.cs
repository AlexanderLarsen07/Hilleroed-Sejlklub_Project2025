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
            List<Signup> signups = signupRepo.ReturnAllByEventTitle(title);
            bool isFalse = true;
            while (isFalse)
            {
                if (signups.Count == 0)
                {
                    Console.WriteLine("No event with the given title could be found.");
                    Pause();
                    isFalse = false;
                }
                else
                {
                    for (int i = 0; i < signups.Count; i++)
                    {
                        if (signups[i].Member == member)
                        {
                            Console.Clear();
                            Console.WriteLine(signups[i]);

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
                                isFalse = false;
                                Pause();
                            }
                            else if (choice == "n")
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input.");
                                Pause();
                            }
                        }
                    }
                }
            }
        }
        public void RemoveSignup(SignupRepo signupRepo, Member member, EventRepo eventRepo)
        {
            foreach (Signup signup in signupRepo.ReturnAllByMember(member))
            {
                Console.WriteLine(signup.ToString());
            }
            Console.WriteLine("Choose the signup to remove by writing the events title");
            string title = Console.ReadLine();
            List<Signup> signups = signupRepo.ReturnAllByEventTitle(title);
            bool isFalse = true;
            while (isFalse)
            {
                if (signups.Count == 0)
                {
                    Console.WriteLine("No event with the given title could be found.");
                    Pause();
                    isFalse = false;
                }
                else
                {
                    for (int i = 0; i < signups.Count; i++)
                    {
                        if (signups[i].Member == member)
                        {
                            Console.Clear();
                            Console.WriteLine(signups[i]);

                            Console.WriteLine("press \"y\" to remove. Press \"n\" if wrong signup. Press \"q\" to cancel removing signups.");
                            string choice = Console.ReadLine().ToLower();

                            if (choice == "q")
                            {
                                isFalse = false;
                            }
                            else if (choice == "y")
                            {
                                eventRepo.RemoveSignupOnEvent(signups[i].Event, signups[i]);
                                signupRepo.RemoveSignup(signups[i]);
                                Console.WriteLine("Signup removed.");
                                isFalse = false;
                                Pause();
                            }
                            else if (choice == "n")
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input.");
                                Pause();
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
            
            SignupToEvent(eventRepo, member, signupRepo);
        }
        public void SignupToEvent(EventRepo eventRepo, Member member, SignupRepo signupRepo)
        {
            string title = Console.ReadLine();
            List<Event> events = eventRepo.ReturnAllEventsByTitle(title);

            bool isFalse = true;
            while (isFalse)
            {
                if (events.Count <= 0)
                {
                    Console.WriteLine("No event with the given title could be found.");
                    Pause();
                    isFalse = false;
                }
                else if (events.Count == 1 && !events[0].Signups.Count.Equals(events[0].MaxMembers) && !eventRepo.SignupExistsCheck(member, events[0]))
                {
                    Console.WriteLine("Write your comment:");
                    string comment = Console.ReadLine();
                    Signup theSignup = new Signup(events[0], member, comment);
                    signupRepo.AddSignup(theSignup);
                    Console.WriteLine($"Succesfully signed up to {events[0].Title}");
                    isFalse = false;
                    Pause();
                }
                else if (events.Count > 1)
                {
                    for (int i = 0; i < events.Count; i++)
                    {
                        if (!events[i].Signups.Count.Equals(events[i].MaxMembers) && !eventRepo.SignupExistsCheck(member, events[i]))
                        {
                            Console.Clear();
                            Console.WriteLine(events[i].ToString());

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
                                Pause();
                                isFalse = false;
                            }
                            else if (choice == "n")
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input.");
                                Pause();
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Event title not valid.");
                    Pause();
                    isFalse = false;
                }
            }
        }
        public void AdminChoiceHandler(Member member, SignupRepo signupRepo, string actionChoice, EventRepo eventRepo)
        {
            PrintEnterTitle();
            if (actionChoice == "1")
            {
                SignupToEvent(eventRepo, member, signupRepo);
            }
            else if (actionChoice == "2")
            {
                string title = Console.ReadLine();
                List<Signup> signups = signupRepo.ReturnAllByEventTitle(title);
                bool isFalse = true;
                while (isFalse)
                {
                    if (signups.Count <= 0)
                    {
                        isFalse = false;
                        Console.WriteLine("No signups for the given event was found.");
                        Pause();
                    }
                    else
                    {
                        foreach (Signup signup in signups)
                        {
                            Console.WriteLine(signup);
                        }
                        Console.WriteLine("Choose memberID to remove signup. Press \"q\" to cancel.");
                        string removeAction = Console.ReadLine();
                        if (removeAction == "q")
                        {
                            isFalse = false;
                        }
                        else
                        {
                            bool isFound = false;
                            for (int i = 0; i < signups.Count; i++)
                            {
                                if (signups[i].Member.MemberID.ToString() == removeAction)
                                {
                                    Console.WriteLine("Signup successfully removed.");
                                    signupRepo.RemoveSignup(signups[i]);
                                    isFalse = false;
                                    isFound = true;
                                    Pause();
                                    break;
                                }
                            }
                            if (!isFound)
                            {
                                Console.WriteLine("A signup with the given memberID could not be found.");
                                Pause();
                            }
                        }
                    }
                }
            }
            else if (actionChoice == "3")
            {
                string title = Console.ReadLine();
                List<Event> events = eventRepo.ReturnAllEventsByTitle(title);
                bool isFalse = true;
                while (isFalse)
                {
                    if (events.Count <= 0)
                    {
                        isFalse = false;
                        Console.WriteLine("No event with the given title was found.");
                        Pause();
                    }
                    else if (events.Count == 1)//edit event
                    {
                        Console.WriteLine("Write new title.");
                        string editTitle = Console.ReadLine();
                        Console.WriteLine("Write new description");
                        string editDescription = Console.ReadLine();
                        Console.WriteLine("enter new maximum members for event.");
                        int editMaxMembers = Convert.ToInt32(Console.ReadLine());
                        eventRepo.EditEvent(events[0].EventID, editTitle, editMaxMembers, editDescription);
                        Console.WriteLine("Event successfully edited");
                        isFalse = false;
                        Pause();
                    }
                    else
                    {
                        for (int i = 0; i < events.Count; i++) //choose event to edit
                        {
                            Console.WriteLine(events[i].EventID);
                            Console.WriteLine(events[i]);

                            Console.WriteLine("press \"y\" to choose event to edit. Press \"n\" if Wrong event. Press \"q\" to quit editing event.");

                            string editEventChoice = Console.ReadLine().ToLower();

                            if (editEventChoice == "q")
                            {
                                isFalse = false;
                            }
                            else if (editEventChoice == "y")
                            {
                                Console.WriteLine("Write new title.");
                                string editTitle = Console.ReadLine();
                                Console.WriteLine("Write new description");
                                string editDescription = Console.ReadLine();
                                Console.WriteLine("enter new maximum members for event.");
                                int editMaxMembers = Convert.ToInt32(Console.ReadLine());
                                eventRepo.EditEvent(events[i].EventID, editTitle, editMaxMembers, editDescription);
                                Console.WriteLine("Event successfully edited");
                                isFalse = false;
                                Pause();
                            }
                            else if (editEventChoice == "n")
                            {
                                continue;
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
                Pause();
            }
        }
        public void Pause()
        {
            Console.ReadLine();
        }
        public void PrintEnterTitle()
        {
            Console.WriteLine("Enter the title of the event: ");
        }
    }
}
