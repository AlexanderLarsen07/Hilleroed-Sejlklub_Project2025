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
using System.Xml.Linq;

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
        public void BoatMenu(string theChoices, Member? member, BoatRepo boatRepo, MotorInfo? motor)
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
                                Console.WriteLine("The boats:");
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
                                Console.WriteLine("Press \"q\" to quit.");
                                Console.WriteLine("The boats:");
                                boatRepo.PrintAllBoats();
                                Console.ReadLine();
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
                                Console.WriteLine("Press \"q\" to quit.");
                                Console.WriteLine("The boats");
                                boatRepo.PrintAllBoats();
                                Console.ReadLine();
                                break;
                            }
                        case "2":
                            {
                                Console.WriteLine("Press \"q\" to quit.");
                                Console.WriteLine("Create a new boat and add the new boat:");
                                Console.WriteLine("Enter sailNumber");
                                string sailNumber = Console.ReadLine();
                                Console.WriteLine("Enter name");
                                string name = Console.ReadLine();
                                Console.WriteLine("Enter description");
                                string description = Console.ReadLine();
                                Console.WriteLine("Enter boat type");
                                string boatTypeInput = Console.ReadLine();
                                BoatTypeEnum boatType = Enum.Parse<BoatTypeEnum>(boatTypeInput);
                                Console.WriteLine("Enter the model");
                                string theModelInput = Console.ReadLine();
                                ModelEnum theModel = Enum.Parse<ModelEnum>(theModelInput);
                                Console.WriteLine("Enter max passengers");
                                int maxPassengers = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter lenght");
                                int lenght = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter width");
                                int width = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter draft");
                                int draft = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter year built");
                                int yearBuilt = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter 'no motor' if the boat has no motor, else enter 'has motor':");
                                string motorInput = Console.ReadLine();
                                if (motorInput == "no motor")
                                {
                                    motor = null;
                                }
                                else if (motorInput == "has motor")
                                {
                                    Console.WriteLine("Enter fuel type:");
                                    FuelTypeEnum fuelType = Enum.Parse<FuelTypeEnum>(Console.ReadLine());

                                    Console.WriteLine("Enter brand:");
                                    BrandEnum brand = Enum.Parse<BrandEnum>(Console.ReadLine());

                                    Console.WriteLine("Enter horsepower:");
                                    int hp = int.Parse(Console.ReadLine());

                                    Console.WriteLine("Enter weight:");
                                    int weight = int.Parse(Console.ReadLine());

                                    motor = new MotorInfo(fuelType, brand, hp, weight);
                                }
                                else
                                {
                                    Console.WriteLine("You didn't write 'no motor' or 'has motor'");
                                }

                                AddBoatController createBoat = new AddBoatController(sailNumber, name, description, boatType, theModel, maxPassengers, lenght, width, draft, yearBuilt, motor, boatRepo);
                                createBoat.AddTheCreatedBoat();
                                Console.ReadLine();
                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine("Press \"q\" to quit.");
                                Console.WriteLine("delete a boat by sailnumber:");
                                string givenSailNumber = Console.ReadLine();
                                boatRepo.RemoveBySailNumber(givenSailNumber);
                                Console.ReadLine();
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
                                Console.WriteLine("The boats");
                                boatRepo.PrintAllBoats();
                                Console.ReadLine();
                            }
                            break;
                        case "2":
                            {
                                Console.WriteLine("Press \"q\" to quit.");
                                Console.WriteLine("Create a new boat and add the new boat:");
                                Console.WriteLine("Enter sailNumber");
                                string sailNumber = Console.ReadLine();
                                Console.WriteLine("Enter name");
                                string name = Console.ReadLine();
                                Console.WriteLine("Enter description");
                                string description = Console.ReadLine();
                                Console.WriteLine("Enter boat type");
                                string boatTypeInput = Console.ReadLine();
                                BoatTypeEnum boatType = Enum.Parse<BoatTypeEnum>(boatTypeInput);
                                Console.WriteLine("Enter the model");
                                string theModelInput = Console.ReadLine();
                                ModelEnum theModel = Enum.Parse<ModelEnum>(theModelInput);
                                Console.WriteLine("Enter max passengers");
                                int maxPassengers = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter lenght");
                                int lenght = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter width");
                                int width = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter draft");
                                int draft = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter year built");
                                int yearBuilt = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter 'no motor' if the boat has no motor, else enter 'has motor':");
                                string motorInput = Console.ReadLine();
                                if (motorInput == "no motor")
                                {
                                    motor = null;
                                }
                                else if (motorInput == "has motor")
                                {
                                    Console.WriteLine("Enter fuel type:");
                                    FuelTypeEnum fuelType = Enum.Parse<FuelTypeEnum>(Console.ReadLine());

                                    Console.WriteLine("Enter brand:");
                                    BrandEnum brand = Enum.Parse<BrandEnum>(Console.ReadLine());

                                    Console.WriteLine("Enter horsepower:");
                                    int hp = int.Parse(Console.ReadLine());

                                    Console.WriteLine("Enter weight:");
                                    int weight = int.Parse(Console.ReadLine());

                                    motor = new MotorInfo(fuelType, brand, hp, weight);
                                }
                                else
                                {
                                    Console.WriteLine("You didn't write 'no motor' or 'has motor'");
                                }

                                    AddBoatController createBoat = new AddBoatController(sailNumber, name, description, boatType, theModel, maxPassengers, lenght, width, draft, yearBuilt, motor, boatRepo);
                                createBoat.AddTheCreatedBoat();
                                Console.ReadLine();
                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine("Press \"q\" to quit.");
                                Console.WriteLine("delete a boat by sailnumber:");
                                string givenSailNumber = Console.ReadLine();
                                boatRepo.RemoveBySailNumber(givenSailNumber);
                                Console.ReadLine();
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


        private void CreateBoatMethod()
        {
          
        }
    }
}
