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
                                if (title == "q")
                                {
                                    isFalse = false;
                                }
                                while (isFalse)
                                {
                                    if (events.Count <= 0)
                                    {
                                        isFalse = false;
                                        Console.WriteLine("No event with the given name was found.");
                                        Console.ReadLine();
                                    }
                                    else if (events.Count == 1)
                                    {
                                        Console.WriteLine("Make your comment");
                                        string comment = Console.ReadLine();
                                        Signup theSignup = new Signup(events[0], member, comment);
                                        Console.WriteLine($"Succesfully signed up to {events[0].Title}");
                                        signupRepo.AddSignup(theSignup);
                                        isFalse = false;
                                        Console.ReadLine();
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
                                                signupRepo.AddSignup(theSignup);
                                                isFalse = false;
                                                Console.ReadLine();
                                            }
                                            else if (choice == "n".ToLower() || choice == "n".ToUpper())
                                            {
                                                continue;
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case "2":
                            { //lookup events from daterange
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
                                    if (events.Count <= 0)
                                    {
                                        Console.WriteLine("No event with the given range of dates could be found.");
                                        isFalse = false;
                                        Console.ReadLine();
                                    }
                                    else if (events.Count == 1)
                                    {
                                        Console.WriteLine("Write your comment:");
                                        string comment = Console.ReadLine();
                                        Signup theSignup = new Signup(events[0], member, comment);
                                        Console.WriteLine($"Succesfully signed up to {events[0].Title}");
                                        signupRepo.AddSignup(theSignup);
                                        isFalse = false;
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
                                                signupRepo.AddSignup(theSignup);
                                                Console.ReadLine();
                                            }
                                            else if (choice == "n".ToLower() || choice == "n".ToUpper())
                                            {
                                                continue;
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine(signupRepo.ReturnAllByMember(member));
                                Console.WriteLine("Choose the signup to edit by writing the events title");
                                string title = Console.ReadLine();
                                if (signupRepo.ReturnAllByMember(member).Count == 1)
                                {
                                    Console.WriteLine("Write edited comment:");
                                    string comment = Console.ReadLine();
                                    signupRepo.EditComment(member, comment, title);
                                    Console.WriteLine("Comment added.");
                                    Console.ReadLine();
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
                                        signupRepo.RemoveSignup(signups[i]);
                                        Console.WriteLine("Signup successfully removed.");
                                        Console.ReadLine();
                                    }
                                }
                                break;
                            }
                            //default:
                            //    {
                            //        Console.WriteLine("invalid input try these options:");
                            //    }
                            //    break;
                    }
                    theChoice = ReadChoice(theChoices);
                }

                else if (member.Role == RoleEnum.Administrator ||member.Role == RoleEnum.Chairman)
                {
                    //ny userchoice for Admin
                    switch (theChoice)
                    {
                        case "1":
                            { //print all events/sign up to event by title
                                eventRepo.PrintAllEvents();
                                Console.WriteLine("Press \"1\" to sign up to an event. Press \"2\" to view signups on an event. Press \"3\" to edit an event. Press \"q\" to quit.");
                                string actionChoice = Console.ReadLine();
                                if (actionChoice == "q")
                                {
                                    break;
                                }
                                Console.WriteLine("Enter the title of the event: ");
                                if (actionChoice == "1")
                                {
                                    string title = Console.ReadLine();
                                    List<Event> events = eventRepo.ReturnAllEventsByTitle(title);
                                    bool isFalse = true;
                                    while (isFalse)
                                    {
                                        if (events.Count <= 0)
                                        {
                                            isFalse = false;
                                            Console.WriteLine("No event with the given name was found.");
                                            Console.ReadLine();
                                        }
                                        else if (events.Count == 1)
                                        {
                                            Console.WriteLine("Make your comment");
                                            string comment = Console.ReadLine();
                                            Signup theSignup = new Signup(events[0], member, comment);
                                            Console.WriteLine($"Succesfully signed up to {events[0].Title}");
                                            signupRepo.AddSignup(theSignup);
                                            isFalse = false;
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            for (int i = 0; i <= events.Count; i++)
                                            {
                                                Console.WriteLine(events[i]);

                                                Console.WriteLine("press \"y\" to signup to event. Press \"n\" if Wrong event. Press \"q\" to cancel signing up.");

                                                string signupChoice = Console.ReadLine();

                                                if (signupChoice == "q".ToLower() || signupChoice == "q".ToUpper())
                                                {
                                                    isFalse = false;
                                                }
                                                else if (signupChoice == "y".ToLower() || signupChoice == "y".ToUpper())
                                                {
                                                    Console.WriteLine("Make your comment");
                                                    string comment = Console.ReadLine();
                                                    Signup theSignup = new Signup(events[i], member, comment);
                                                    Console.WriteLine($"Succesfully signed up to {events[i].Title}");
                                                    signupRepo.AddSignup(theSignup);
                                                    isFalse = false;
                                                    Console.ReadLine();
                                                }
                                                else if (signupChoice == "n".ToLower() || signupChoice == "n".ToUpper())
                                                {
                                                    continue;
                                                }
                                            }
                                        }
                                    }
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
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            Console.WriteLine(signups);
                                            Console.WriteLine("Choose memberID to remove signup. Press \"q\" to cancel.");
                                            string removeAction = Console.ReadLine();
                                            if(removeAction == "q")
                                            {
                                                isFalse = false;
                                            }
                                            else
                                            {
                                                for(int i = 0; i <= signups.Count; i++)
                                                {
                                                    if (signups[i].Member.MemberID.ToString() == removeAction)
                                                    {
                                                        Console.WriteLine("Signup successfully removed.");
                                                        signupRepo.RemoveSignup(signups[i]);
                                                        isFalse = false;
                                                        Console.ReadLine();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("A signup with the given memberID could not be found.");
                                                    }
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
                                            Console.WriteLine("No event with the given name was found.");
                                            Console.ReadLine();
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
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            for (int i = 0; i <= events.Count; i++) //choose event to edit
                                            {
                                                Console.WriteLine(events[i].EventID);
                                                Console.WriteLine(events[i]);

                                                Console.WriteLine("press \"y\" to choose event to edit. Press \"n\" if Wrong event. Press \"q\" to quit editing event.");

                                                string editEventChoice = Console.ReadLine();

                                                if (editEventChoice == "q".ToLower() || editEventChoice == "q".ToUpper())
                                                {
                                                    isFalse = false;
                                                }
                                                else if (editEventChoice == "y".ToLower() || editEventChoice == "y".ToUpper())
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
                                                    Console.ReadLine();
                                                }
                                                else if (editEventChoice == "n".ToLower() || editEventChoice == "n".ToUpper())
                                                {
                                                    continue;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case "2":
                            { //lookup events from daterange
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
                                    if (events.Count <= 0)
                                    {
                                        Console.WriteLine("No event with the given title could be found.");
                                        isFalse = false;
                                    }
                                    else if (events.Count == 1)
                                    {
                                        Console.WriteLine("Write your comment:");
                                        string comment = Console.ReadLine();
                                        Signup theSignup = new Signup(events[0], member, comment);
                                        Console.WriteLine($"Succesfully signed up to {events[0].Title}");
                                        isFalse = false;
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
                                }
                                break;
                            }
                        case "3":
                            { //edit comment on signup
                                Console.WriteLine(signupRepo.ReturnAllByMember(member));
                                Console.WriteLine("Choose your signup to edit by writing the events title. Press \"q\" to cancel.");
                                string title = Console.ReadLine();
                                if (title == "q")
                                {
                                    break;
                                }
                                else if (signupRepo.ReturnAllByEventTitle(title).Count == 1)
                                {
                                    Console.WriteLine("Write edited comment:");
                                    string comment = Console.ReadLine();
                                    signupRepo.EditComment(member, comment, title);
                                }
                                break;
                            }
                        case "4":
                            {//delete signup by title
                                Console.WriteLine(signupRepo.ReturnAllByMember(member));
                                Console.WriteLine("Choose your signup to delete by writing the events title. Press \"q\" to cancel.");
                                string title = Console.ReadLine();
                                if (title == "q")
                                {
                                    break;
                                }
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
                        case "5":
                            {
                                Console.WriteLine("Enter Title. Press \"q\" to cancel creating event.");
                                string title = Console.ReadLine();
                                Console.WriteLine("Enter description. Press \"q\" to cancel creating event.");
                                string description = Console.ReadLine();
                                Console.WriteLine("Enter date of event. Format : yyyy-mm-dd hh:mm. Press \"q\" to cancel creating event.");
                                DateTime date = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("Enter Maximum signups for event. Press \"q\" to cancel creating event.");
                                int maxMembers = Convert.ToInt32(Console.ReadLine());
                                if(title == "q" || description == "q" || date == Convert.ToDateTime("q") || maxMembers == Convert.ToInt32("q"))
                                {
                                    break;
                                }
                                AddEventController newEvent = new AddEventController(maxMembers, title, date, description, eventRepo);
                                newEvent.AddEvent();
                                Console.WriteLine("Event successfully added.");
                                Console.ReadLine();
                                break;
                            }
                    }
                    theChoice = ReadChoice(theChoices);
                }
            }
        }
    }
}
