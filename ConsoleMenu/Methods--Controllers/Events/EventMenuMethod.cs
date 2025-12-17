using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ConsoleMenu.Menu;
using ConsoleMenu.Methods.Events;
using ConsoleMenu.Methods__Controllers.Helpers;
using Hillerød_Sejlklub_Library.Exceptions;
using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Blogs;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;
using Hillerød_Sejlklub_Library.Services;

namespace ConsoleMenu.Controllers.Events
{
    public class EventMenuMethod
    {
        EventMenuHelpers menuHelpers = new EventMenuHelpers();
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
            try
            {
                string theChoice = ReadChoice(theChoices);
                while (theChoice != "q")
                {
                    #region GuestMenu
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
                    #endregion
                    #region MemberMenu
                    else if (member.Role == RoleEnum.Member)
                    {
                        switch (theChoice)
                        {

                            case "1":
                                {
                                    eventRepo.PrintAllEvents();
                                    Console.WriteLine("enter title of the Event you wish to sign up to. Press \"q\" to quit.");
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
                                            Console.WriteLine("Event title not valid.");
                                            Console.ReadLine();
                                            isFalse = false;
                                        }
                                    }
                                    break;
                                }
                            case "2":
                                { //lookup events from daterange
                                    menuHelpers.LookupEventByDateRange(eventRepo, member, signupRepo);
                                    break;
                                } //DONE
                            case "3":
                                {//edit
                                    menuHelpers.EditComment(signupRepo, member);
                                    break;
                                } //DONE
                            case "4":
                                {//remove signup
                                    menuHelpers.RemoveSignup(signupRepo, member);
                                    break;
                                } //DONE
                        }
                        theChoice = ReadChoice(theChoices);
                    }
                    #endregion
                    #region AdminMenu
                    else if (member.Role == RoleEnum.Administrator || member.Role == RoleEnum.Chairman)
                    {
                        //ny userchoice for Admin
                        switch (theChoice)
                        {
                            #region Case 1
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
                                    #region ActionChoice 1
                                    if (actionChoice == "1")
                                    {
                                        string title = Console.ReadLine();
                                        List<Event> events = eventRepo.ReturnAllEventsByTitle(title);

                                        bool isFalse = true;
                                        while (isFalse)
                                        {
                                            if (events.Count <= 0)
                                            {
                                                Console.WriteLine("No event with the given title could be found.");
                                                Console.ReadLine();
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
                                                            Console.ReadLine();
                                                            isFalse = false;
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
                                                Console.WriteLine("Event title not valid.");
                                                Console.ReadLine();
                                                isFalse = false;
                                            }
                                        }
                                        break;
                                    }
                                    #endregion
                                    #endregion
                                    #region ActionChoice 2
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
                                                    for (int i = 0; i < signups.Count; i++)
                                                    {
                                                        if (signups[i].Member.MemberID.ToString() == removeAction)
                                                        {
                                                            Console.WriteLine("Signup successfully removed.");
                                                            signupRepo.RemoveSignup(signups[i]);
                                                            isFalse = false;
                                                            Console.ReadLine();
                                                            return;
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
                                    #endregion
                                    #region ActionChoice 3
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
                                                        Console.ReadLine();
                                                    }
                                                    else if (editEventChoice == "n")
                                                    {
                                                        continue;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                            #endregion
                            #region Admin/Chairman Case 2
                            case "2":
                                { //lookup events from daterange
                                    menuHelpers.LookupEventByDateRange(eventRepo, member, signupRepo);
                                    break;
                                } //DONE
                            #endregion
                            #region Admin/Chairman Case 3
                            case "3":
                                { //edit comment on signup
                                    menuHelpers.EditComment(signupRepo, member);
                                    break;
                                } //DONE
                            #endregion
                            #region Admin/Chairman Case 4
                            case "4":
                                {//delete signup by title
                                    menuHelpers.RemoveSignup(signupRepo, member);
                                    break;
                                } //DONE
                            #endregion
                            #region Admin/Chairman Case 5
                            case "5":
                                {
                                    Console.WriteLine("Enter Title. Press \"q\" to cancel creating event.");
                                    string title = Console.ReadLine();
                                    if (title == "q")
                                    {
                                        break;
                                    }
                                    Console.WriteLine("Enter description. Press \"q\" to cancel creating event.");
                                    string description = Console.ReadLine();
                                    if (description == "q")
                                    {
                                        break;
                                    }
                                    Console.WriteLine("Enter date of event. Format : yyyy-mm-dd hh:mm. Press \"q\" to cancel creating event.");
                                    string dateString = Console.ReadLine();
                                    if (dateString == "q")
                                    {
                                        break;
                                    }
                                    DateTime date = Convert.ToDateTime(dateString);
                                    Console.WriteLine("Enter Maximum signups for event. Press \"q\" to cancel creating event.");
                                    string maxMemberString = Console.ReadLine();
                                    if (maxMemberString == "q")
                                    {
                                        break;
                                    }
                                    int maxMembers = Convert.ToInt32(maxMemberString);
                                    AddEventController newEvent = new AddEventController(maxMembers, title, date, description, eventRepo);
                                    newEvent.AddEvent();
                                    Console.WriteLine("Event successfully added.");
                                    Console.ReadLine();
                                    break;
                                }
                            #endregion
                            #region Case 6
                            case "6":
                                {
                                    List<Event> events = eventRepo.BubbleSortBySignups();
                                    foreach (Event even in events)
                                    {
                                        Console.WriteLine(even);
                                    }
                                    Console.ReadLine();
                                    break;
                                }
                            #endregion
                            case "7":
                                {
                                    List<Signup> signups = signupRepo.SortByDateOfSignup();
                                    foreach (Signup signup in signups)
                                    {
                                        Console.WriteLine(signup);
                                    }
                                    Console.ReadLine();
                                    break;
                                }
                        }
                        theChoice = ReadChoice(theChoices);
                    }
                    #endregion
                }
            }
            catch (Exception exc) //prevents the system from crashing. says what went wrong. not very user friendly though
            {
                Console.WriteLine(exc.Message);
                Console.ReadLine();
            }
        }
    }
}
