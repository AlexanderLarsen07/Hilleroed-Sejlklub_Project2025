using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Boats;
using Hillerød_Sejlklub_Library.Models.Members;
using Hillerød_Sejlklub_Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Methods__Controllers.Boats
{
    public class RepairMenuMethod
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
        public void BoatMenu(string theChoices, Member? member, RepairRepo repairRepo, BoatRepo boatRepo)
        {
            try
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
                                    Console.WriteLine("Press q to exit.");
                                    Console.WriteLine("Repairs not available to guests, you need to become a member.");
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
                                    Console.WriteLine("Press \"q\" to quit.");
                                    Console.WriteLine("All the Repairs to each boat:");
                                    repairRepo.PrintAllTheRepairsToEachBoat(boatRepo);
                                    Console.ReadLine();
                                    break;
                                }

                            case "2":
                                {
                                    Console.WriteLine("Press \"q\" to quit.");
                                    Console.WriteLine("Create and add a repair:");
                                    CreateAddRepair(repairRepo, boatRepo);
                                    break;
                                }
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
                                    Console.WriteLine("Press \"q\" to quit.");
                                    Console.WriteLine("All the Repairs to each boat:");
                                    repairRepo.PrintAllTheRepairsToEachBoat(boatRepo);
                                    Console.ReadLine();
                                    break;
                                }
                            case "2":
                                {
                                    Console.WriteLine("Press \"q\" to quit.");
                                    Console.WriteLine("Create and add a repair:");
                                    CreateAddRepair(repairRepo, boatRepo);
                                    break;
                                }
                            case "3":
                                {
                                    Console.WriteLine("Press \"q\" to quit.");
                                    Console.WriteLine("delete a repair:");
                                    int repairNumber = int.Parse(Console.ReadLine());
                                    repairRepo.RemoveRepair(repairNumber);
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


                    else if (member.Role == RoleEnum.Chairman)
                    {
                        //ny userchoice for chairman
                        switch (theChoice)
                        {
                            case "1":
                                {
                                    Console.WriteLine("Press \"q\" to quit.");
                                    Console.WriteLine("All the Repairs to each boat:");
                                    repairRepo.PrintAllTheRepairsToEachBoat(boatRepo);
                                    Console.ReadLine();
                                }
                                break;
                            case "2":
                                {
                                    Console.WriteLine("Press \"q\" to quit.");
                                    Console.WriteLine("Create and add a repair:");
                                    CreateAddRepair(repairRepo, boatRepo);
                                    break;

                                }
                            case "3":
                                {
                                    Console.WriteLine("Press \"q\" to quit.");
                                    Console.WriteLine("delete a repair:");
                                    int repairNumber = int.Parse(Console.ReadLine());
                                    repairRepo.RemoveRepair(repairNumber);
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
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
        

        public void CreateAddRepair(RepairRepo repairRepo, BoatRepo boatRepo)
        {
            try
            {
                Console.WriteLine("Enter number");
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter comment");
                string comment = Console.ReadLine();
                Console.WriteLine("Enter the boat sail number");
                string sailNumber = Console.ReadLine();
                Boat theBoat = boatRepo.GetBoatBySailNumber(sailNumber);
                bool isFixed = false;
                Console.WriteLine("Enter 'true' or 'false' depending on if the repair you will add to this boat will have to be solved before the boat can sail or not");
                bool haveToBeSolved = bool.Parse(Console.ReadLine());
                AddRepairController createdRepair = new AddRepairController(number, comment, theBoat, isFixed, haveToBeSolved, repairRepo, boatRepo);
                createdRepair.AddTheCreatedRepair();
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
