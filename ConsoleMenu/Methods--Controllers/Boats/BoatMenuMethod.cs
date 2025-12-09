using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Boats;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;
using Hillerød_Sejlklub_Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Methods__Controllers.Boats
{
    public class BoatMenuMethod
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
        public void BoatMenu(string theChoices, Member? member, BoatRepo boatRepo)
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
                                Console.WriteLine("Here are the boats:");
                                Console.WriteLine("Press q to exit.");
                                boatRepo.PrintBoatInfoToGuest();
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
                                Console.WriteLine("Here are the boats:");
                                Console.WriteLine("Press \"q\" to quit.");
                                boatRepo.PrintAllBoats();

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
                            {
                                Console.WriteLine("Choice 1");
                                Console.WriteLine("Press \"q\" to quit.");


                            }
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
                            Console.WriteLine("Choice 1");
                            Console.WriteLine("Press \"q\" to quit.");

                            break;
                    }
                    theChoice = ReadChoice(theChoices);
                }
            }
        }
    }
}
