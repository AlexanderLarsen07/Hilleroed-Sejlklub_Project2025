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
                                    menuHelpers.Pause();
                                }
                                break;
                            case "2":
                                {
                                    Console.WriteLine("Look up event by start date and end date. Format : yyyy-mm-dd hh:mm");//skriv format så user kan indsætte en valid datetime
                                    Console.WriteLine("write start date:");
                                    DateTime startDate = DateTime.Parse(Console.ReadLine());
                                    Console.WriteLine("write end date:");
                                    DateTime endDate = DateTime.Parse(Console.ReadLine());
                                    foreach(Event even in eventRepo.ReturnByDateRange(startDate, endDate))
                                    {
                                        Console.WriteLine(even.ToString());
                                    }
                                    menuHelpers.Pause();
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
                                    menuHelpers.SignupToEvent(eventRepo, member, signupRepo);
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
                                    menuHelpers.RemoveSignup(signupRepo, member, eventRepo);
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
                                    menuHelpers.AdminChoiceHandler(member, signupRepo, actionChoice, eventRepo);
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
                                    menuHelpers.RemoveSignup(signupRepo, member, eventRepo);
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
                                    menuHelpers.Pause();
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
                                    menuHelpers.Pause();
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
                                    menuHelpers.Pause();
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
                menuHelpers.Pause();
            }
        }
    }
}