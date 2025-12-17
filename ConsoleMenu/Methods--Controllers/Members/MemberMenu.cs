using ConsoleMenu.Menu;
using Hillerød_Sejlklub_Library.Data;
using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Members;
using Hillerød_Sejlklub_Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleMenu.Methods.Members
{
    public class MemberMenu
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
        #region role (old version - delete)
        public void Roles(string readChoices, Member member, MemberRepo memberRepo, BoatLotRepo boatLotRepo)
        {
            string theChoice = ReadChoice(readChoices);
            while (theChoice != "q")
            {
                #region Members with role Member
                if (member.Role == RoleEnum.Member) //skal kunne kigge på Membership oplysninger, redigere deres konto, tilføje boatlots
                {
                    switch (theChoice)
                    {
                        #region 1. View ens oplysninger
                        case "1"://skal kunne kigge på ens oplysninger
                            {
                                Console.WriteLine(member.ToString() + $"Mail: {member.Mail}");
                                Console.ReadLine();
                            }
                            break;
                        #endregion
                        #region 2. Edit ens konto
                        case "2": //redigere deres konto
                            {
                                {
                                    Console.WriteLine("Dine Nuværende Informationer:");
                                    member.ToString();
                                    Console.WriteLine("Valg hvilke informationer du ville ændres ud fra tallet:" +
                                        "\n1: Navn" +
                                        "\n2: Alder" +
                                        "\n3: Telefon Nummer" +
                                        "\n4: Mail" +
                                        "\n5: Password");
                                    string choice = Console.ReadLine();
                                    if (choice == "1") //navn
                                    {
                                        Console.WriteLine("Indtast nyt navn:");
                                        string nameTyped = Console.ReadLine();
                                        if (nameTyped != member.Name || nameTyped.Length < 0)
                                        {
                                            member.Name = nameTyped!;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Navnet kan ikke være det samme som den tidligere og skal være større end 0 tegn" +
                                                ",\nStart over.");
                                        }
                                    }
                                    else if (choice == "2") //alder
                                    {
                                        Console.WriteLine("Indtast nyt alder:");
                                        int age = Convert.ToInt32(Console.ReadLine());
                                        if (age != member.Age || age < 100 || age > 0)
                                        {
                                            member.Age = age;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Alderen må ikke være under 0 eller over 100 eller det samme som den tidligere alder, Start over.");
                                        }
                                    }
                                    else if (choice == "3") //Telefon nummer
                                    {
                                        Console.WriteLine("Indtast nyt Telefon nummer:");
                                        string phoneNumber = Console.ReadLine();
                                        if (phoneNumber != member.PhoneNumber || phoneNumber.Length == 8)
                                        {
                                            member.PhoneNumber = phoneNumber!;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Telefon Nummeret skal have 8 cifre, start over.");
                                        }
                                    }
                                    else if (choice == "4") // Mail
                                    {
                                        Console.WriteLine("Indtast nyt Mail:");
                                        string mail = Console.ReadLine();
                                        if (mail != member.Mail || mail.Contains("@gmail") || mail.Contains("@yahoo") || mail.Contains("@hotmail") || mail.Contains("@outlook") || mail.Contains("@office365"))
                                        {
                                            member.Mail = mail;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Den indtastede Mail er ikke korrekt, start over.");
                                        }
                                    }
                                    else if (choice == "5") //Password
                                    {
                                        Console.WriteLine("Indtast nyt password:");
                                        string password = Console.ReadLine();
                                        if (password != member.Password || password.Length < 5)
                                        {
                                            member.Password = password;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Passwordet må ikke være det samme som den gamle password og skal være større end 5 karakterer");
                                        }
                                    }
                                }
                            }
                            break;
                        #endregion
                        #region 3. tilføje boatlots til en selv - done
                        case "3"://tilføje boatlots 
                            Console.WriteLine($"You have currently: {member._boatLotsRented.Count} boat lots that your renting.");
                            Console.WriteLine($"There are {member._boatLotsRented.Count}/{member._boatLotsRented.Capacity} boat lots rented");
                            Console.WriteLine($"-----------------------------------------------");
                            Console.WriteLine("Inset the number of boat lots that you want: ");
                            Console.WriteLine("Familie member: 400 kr. = 1 boat lot");
                            Console.WriteLine("Senior  member: 400 kr. = 1 boat lot");
                            Console.WriteLine("Junior  member: 200 kr. = 1 boat lot");
                            bool ying = true;
                            while (ying == true)
                            {
                                foreach (BoatLot data in boatLotRepo.GetAll())
                                {
                                    if (data.IsRented == false)//checks if there are boat lots that are not rented
                                    {
                                        {
                                            Console.WriteLine($"{data.ToString()}\n");
                                        }
                                    }
                                }
                                Console.WriteLine("Input the id of the boat lot, that you want:");
                                int numberInputted = Convert.ToInt32(Console.ReadLine());
                                if (boatLotRepo.GetBoatLotById(numberInputted) != null)
                                {
                                    memberRepo.addBoatLotToMember(boatLotRepo.GetBoatLotById(numberInputted)!, member);
                                    break;
                                }
                                ying = false;
                            }
                            break;
                            #endregion
                    }
                    theChoice = ReadChoice(readChoices);
                }
                #endregion
                #region Members with role Admin
                else if (member.Role == RoleEnum.Administrator) //skal kunne alt membersne kan, skal kunne view alle members og en bestemt valgt member, sortere boatlots (sorterings algoritmer), simple statistikker, kan delete users og lave user
                {
                    switch (theChoice)
                    {
                        #region 1. View alle user
                        case "1"://skal kunne view alle members
                            foreach (Member members in memberRepo.GetAll())
                            {
                                Console.WriteLine(members.ToString());
                            }
                            Console.ReadLine();
                            break;
                        #endregion
                        #region 2. Vælge en bestemt member
                        case "2"://skal kunne vælge en bestemt valgt member (findes member ud fra deres id)
                            foreach (Member m1 in memberRepo.GetAll()) //Maybe it works?
                            {
                                Console.WriteLine("Enter a members id number:");
                                int enteredNumber = Convert.ToInt32(Console.ReadLine());
                                if (enteredNumber == m1.MemberID)
                                {
                                    Console.WriteLine(m1.ToString() + $"{m1.Mail}");
                                    Console.ReadLine();
                                    break;
                                }
                                if (enteredNumber != m1.MemberID)
                                {
                                    Console.WriteLine("No member has the entered id");
                                    Console.ReadLine();
                                    break;
                                }
                            }
                            break;
                        #endregion
                        #region 3. Sortering af både pladser - done
                        case "3"://sortere boatlots
                            int theirNumber = 0;
                            Console.WriteLine("Every BoatLots:");
                            foreach (BoatLot boatLot in boatLotRepo.GetAll())
                            {
                                foreach (Member m1 in memberRepo.GetAll())
                                {
                                    if (m1._boatLotsRented.Contains(boatLot))
                                    {
                                        Console.WriteLine($"\nMember ID: {m1.MemberID.ToString()}, Name: {m1.Name.ToString()}" +
                                            $"Boat lot info:{boatLot.ToString()}");
                                        theirNumber++;
                                    }
                                }
                            }
                            foreach (BoatLot boatLot in boatLotRepo.GetAll())
                            {
                                foreach (Member m1 in memberRepo.GetAll())
                                {
                                    if (!m1._boatLotsRented.Contains(boatLot) && theirNumber == 0)
                                    {
                                        Console.WriteLine("There are no boatlot's");
                                        theirNumber++;
                                    }
                                }
                            }
                            Console.WriteLine("");
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine("Your Boat Lots:");
                            int yourNumber = 0;
                            foreach (BoatLot boatLot in boatLotRepo.GetAll())
                            {
                                if (member._boatLotsRented.Contains(boatLot))
                                {
                                    Console.WriteLine(boatLot.ToString());
                                    yourNumber++;
                                }
                            }
                            foreach (BoatLot boatLot in boatLotRepo.GetAll())
                            {
                                if (!member._boatLotsRented.Contains(boatLot) && yourNumber == 0)
                                {
                                    Console.WriteLine("You have no boat lots.");
                                    yourNumber++;
                                }
                            }
                            Console.ReadLine();
                            break;
                        #endregion
                        #region 4. Simple statistikker  -  done
                        case "4"://simple statistikker
                            Console.WriteLine("Members in total:");
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine($"There are {memberRepo.GetAll().Count()} members in total.");
                            Console.WriteLine($"There are {memberRepo.GetSpecificMembersByRole(RoleEnum.Member).Count()} members in total with the role member."); //nulreference
                            Console.WriteLine($"There are {memberRepo.GetSpecificMembersByRole(RoleEnum.Administrator).Count()} members in total with the role administrator.");//nulreference
                            Console.WriteLine($"There are {memberRepo.GetSpecificMembersByRole(RoleEnum.Chairman).Count()} members in total with the role chairman ");//nulreference
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine($"Remaining boat lots left in total: {member._boatLotsRented.Capacity - member._boatLotsRented.Count}");
                            Console.WriteLine("\nMembers that have a boat lot and how many boat lots:");
                            int processed = 0; //indicator that makes sure that there arent multiple prints of the same person
                            if (processed == 0)
                            {
                                foreach (BoatLot boatLot in boatLotRepo.GetAll())
                                {
                                    foreach (Member memb in memberRepo.GetAll())
                                    {
                                        if (memb._boatLotsRented.Contains(boatLot) && processed == 0)
                                        {

                                            Console.WriteLine($"ID: {memb.MemberID.ToString()}, Navn: {memb.Name.ToString()} har {memb._boatLotsRented.Count} båd pladser.");
                                            processed++;
                                            break;
                                        }
                                    }
                                }
                            }
                            else if (processed == 1)
                            {
                                break;
                            }
                            Console.ReadLine();
                            break;
                        #endregion
                        #region 5. Slette og lave members - (fix nullreferenceException) - done
                        case "5": //kan delete users og lave user
                            Console.WriteLine("Please insert a number to proceed:");
                            Console.WriteLine("1: Create a new member");
                            Console.WriteLine("2: Delete an existing member");
                            Console.WriteLine("");
                            string firstChoice = Console.ReadLine();
                            if (firstChoice == "1") //Adds a new user
                            {
                                Console.WriteLine("Insert the following information that the member will contain:");
                                Console.WriteLine("------------------------------------------");
                                Console.WriteLine("Insert Name");
                                string name = Console.ReadLine();
                                Console.WriteLine("Insert Age:");
                                int age = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Insert which membership that the member will have:");
                                Console.WriteLine("1 = Family Member");
                                Console.WriteLine("2 = Member");
                                Console.WriteLine("3 = Passive Member");
                                string membership = Console.ReadLine();
                                MembershipEnum isMembership = new();
                                if (membership == "1")
                                {
                                    isMembership = MembershipEnum.FamilieMedlem;
                                }
                                else if (membership == "2")
                                {
                                    isMembership = MembershipEnum.Medlem;
                                }
                                else if (membership == "3")
                                {
                                    isMembership = MembershipEnum.PassiveMedlem;
                                }
                                Console.WriteLine("Insert Mail:");
                                string mail = Console.ReadLine();
                                Console.WriteLine("Insert Password:");
                                string password = Console.ReadLine();
                                Console.WriteLine("Insert Phone number");
                                string phoneNumber = Console.ReadLine();
                                AddMembersController newMember = new AddMembersController(name, age, isMembership, mail, password, phoneNumber, memberRepo);
                                newMember.Member.Role = RoleEnum.Member;
                                memberRepo.AddMember(newMember.Member);
                            }
                            else if (firstChoice == "2") //deletes an existing user
                            {
                                Console.WriteLine("Members");
                                Console.WriteLine("---------------------------------------------------");
                                foreach (Member members in memberRepo.GetSpecificMembersByRole(RoleEnum.Member))
                                {
                                    Console.WriteLine(members.ToString());
                                }
                                foreach (Member members in memberRepo.GetSpecificMembersByRole(RoleEnum.Administrator))
                                {
                                    Console.WriteLine(members.ToString());
                                }
                                Console.WriteLine("");
                                Console.WriteLine("Insert a members id that you would want to remove:");
                                Console.WriteLine("---------------------------------------------------");
                                int secondChoice = Convert.ToInt32(Console.ReadLine());
                                if (secondChoice == memberRepo.GetMemberById(secondChoice).MemberID && memberRepo.GetMemberById(secondChoice).Role == RoleEnum.Member || memberRepo.GetMemberById(secondChoice).Role == RoleEnum.Administrator) //NullReferenceException when no members
                                {
                                    memberRepo.RemoveMember(secondChoice);
                                    if (memberRepo.GetAll().Count <= 0)
                                    {
                                        Console.WriteLine("There are no members");
                                        Console.ReadLine();
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid id entered");
                                    Console.ReadLine();
                                    break;
                                }
                            }
                            break;
                        #endregion
                        #region 6. View ens oplysninger
                        case "6"://skal kunne kigge på ens oplysninger
                            {
                                Console.WriteLine(member.ToString() + $"Mail: {member.Mail}");
                                Console.ReadLine();
                            }
                            break;
                        #endregion
                        #region 7. Edit ens konto
                        case "7": //redigere deres konto
                            {
                                Console.WriteLine("Dine Nuværende Informationer:");
                                member.ToString();
                                Console.WriteLine("Valg hvilke informationer du ville ændres ud fra tallet:" +
                                    "\n1: Navn" +
                                    "\n2: Alder" +
                                    "\n3: Telefon Nummer" +
                                    "\n4: Mail" +
                                    "\n5: Password");
                                string choice = Console.ReadLine();
                                if (choice == "1") //navn
                                {
                                    Console.WriteLine("Indtast nyt navn:");
                                    string nameTyped = Console.ReadLine();
                                    if (nameTyped != member.Name || nameTyped.Length < 0)
                                    {
                                        member.Name = nameTyped!;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Navnet kan ikke være det samme som den tidligere og skal være større end 0 tegn" +
                                            ",\nStart over.");
                                    }
                                    //member.Name = Console.ReadLine();

                                }
                                else if (choice == "2") //alder
                                {
                                    Console.WriteLine("Indtast nyt alder:");
                                    int age = Convert.ToInt32(Console.ReadLine());
                                    if (age != member.Age || age < 100 || age > 0)
                                    {
                                        member.Age = age;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Alderen må ikke være under 0 eller over 100 eller det samme som den tidligere alder, Start over.");
                                    }
                                    //member.Age = Convert.ToInt32(Console.ReadLine());
                                }
                                else if (choice == "3") //Telefon nummer
                                {
                                    Console.WriteLine("Indtast nyt Telefon nummer:");
                                    string phoneNumber = Console.ReadLine();
                                    if (phoneNumber != member.PhoneNumber || phoneNumber.Length == 8)
                                    {
                                        member.PhoneNumber = phoneNumber!;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Telefon Nummeret skal have 8 cifre, start over.");
                                    }
                                    //member.PhoneNumber = Console.ReadLine();
                                }
                                else if (choice == "4") // Mail
                                {
                                    Console.WriteLine("Indtast nyt Mail:");
                                    string mail = Console.ReadLine();
                                    if (mail != member.Mail || mail.Contains("@gmail") || mail.Contains("@yahoo") || mail.Contains("@hotmail") || mail.Contains("@outlook") || mail.Contains("@office365"))
                                    {
                                        member.Mail = mail;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Den indtastede Mail er ikke korrekt, start over.");
                                    }
                                    //member.Mail = Console.ReadLine();
                                }
                                else if (choice == "5") //Password
                                {
                                    Console.WriteLine("Indtast nyt password:");
                                    string password = Console.ReadLine();
                                    if (password != member.Password || password.Length < 5)
                                    {
                                        member.Password = password;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Passwordet må ikke være det samme som den gamle password og skal være større end 5 karakterer");
                                    }
                                    //member.Password = Console.ReadLine();
                                }
                            }
                            break;
                        #endregion
                        #region 8. tilføje boatlots til en selv - done
                        case "8"://tilføje boatlots 
                            Console.WriteLine($"You have currently: {member._boatLotsRented.Count} boat lots that your renting.");
                            Console.WriteLine($"There are {member._boatLotsRented.Count}/{member._boatLotsRented.Capacity} boat lots rented");
                            Console.WriteLine($"-----------------------------------------------");
                            Console.WriteLine("Inset the number of boat lots that you want: ");
                            Console.WriteLine("Familie member: 400 kr. = 1 boat lot");
                            Console.WriteLine("Senior  member: 400 kr. = 1 boat lot");
                            Console.WriteLine("Junior  member: 200 kr. = 1 boat lot");
                            //int boatLotsRented = Convert.ToInt32(Console.ReadLine());
                            //Console.WriteLine("");
                            //if (boatLotsRented >= 1)
                            //{
                            bool ying = true;
                            while (ying == true)
                            {
                                //if (boatLotRepo.GetAll() != null) //tries to see if there are any boat lots left
                                //{
                                foreach (BoatLot data in boatLotRepo.GetAll())
                                {
                                    if (data.IsRented == false)//checks if there are boat lots that are not rented
                                    {
                                        {
                                            Console.WriteLine($"{data.ToString()}\n");
                                        }
                                    }
                                }
                                Console.WriteLine("Input the id of the boat lot, that you want:");
                                int numberInputted = Convert.ToInt32(Console.ReadLine());
                                if (boatLotRepo.GetBoatLotById(numberInputted) != null)
                                {
                                    memberRepo.addBoatLotToMember(boatLotRepo.GetBoatLotById(numberInputted)!, member);
                                    break;
                                }
                                ying = false;
                                //}
                                //else
                                //{
                                //    Console.WriteLine("There are no more boat lots left to rent");
                                //    Console.ReadLine();
                                //    ying = false;
                                //}
                            }
                            //}
                            //else if (boatLotsRented <= 0)
                            //{
                            //    Console.WriteLine("The amount of boatLots inserted must be 1 or above");
                            //    Console.ReadLine();
                            //}
                            break;
                            #endregion
                    }
                    theChoice = ReadChoice(readChoices);
                }
                #endregion
                #region Members with role chairman
                else if (member.Role == RoleEnum.Chairman) //skal alt admins kan, CRUD admins, ændre formandskab
                {
                    switch (theChoice)
                    {
                        #region 1. CRUD Admins
                        case "1": //CRUD admins
                            Console.WriteLine("Input Which Crud method that you want to do:");
                            Console.WriteLine("1. (C) Create admin");
                            Console.WriteLine("2. (R) Read   admin");
                            Console.WriteLine("3. (U) Update admin");
                            Console.WriteLine("4. (D) Delete admin");
                            Console.WriteLine();
                            string decision = Console.ReadLine();
                            #region (C) Create admin - done
                            if (decision == "1")  //Create admin
                            {
                                bool determination = true;
                                while (determination == true)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("Input number associated with the decision:");
                                    Console.WriteLine("1. Create a new admin");
                                    Console.WriteLine("2. Give an Already existing member the admin Role");
                                    string newDecision = Console.ReadLine();
                                    if (newDecision == "1")
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Insert the following information of the newly created admin:");
                                        Console.WriteLine("------------------------------------------");
                                        Console.WriteLine("Input new name");
                                        string name = Console.ReadLine();
                                        Console.WriteLine("Input new age");
                                        int age = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Input a membership that the admin will contain");
                                        Console.WriteLine("1 = Family Member");
                                        Console.WriteLine("2 = Member");
                                        Console.WriteLine("3 = Passive Member");
                                        string membership = Console.ReadLine();
                                        MembershipEnum isMembership = new();
                                        if (membership == "1")
                                        {
                                            isMembership = MembershipEnum.FamilieMedlem;
                                        }
                                        else if (membership == "2")
                                        {
                                            isMembership = MembershipEnum.Medlem;
                                        }
                                        else if (membership == "3")
                                        {
                                            isMembership = MembershipEnum.PassiveMedlem;
                                        }
                                        Console.WriteLine("Input new Maile");
                                        string mail = Console.ReadLine();
                                        Console.WriteLine("Input new Password");
                                        string password = Console.ReadLine();
                                        Console.WriteLine("Input new Phone number");
                                        string phoneNumber = Console.ReadLine();
                                        AddMembersController newMember = new AddMembersController(name, age, isMembership, mail, password, phoneNumber, memberRepo);
                                        newMember.Member.Role = RoleEnum.Administrator;
                                        memberRepo.AddMember(newMember.Member);
                                    }
                                    if (newDecision == "2") //ændrer en eksisterende member til administrator
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("--------------------------");
                                        Console.WriteLine("Input an existing members id to give them the role admin:");
                                        foreach (Member members in memberRepo.GetSpecificMembersByRole(RoleEnum.Member))
                                        {
                                            Console.WriteLine(members.ToString());
                                        }
                                        Console.WriteLine("--------------------------");
                                        Console.WriteLine("");
                                        int number = Convert.ToInt32(Console.ReadLine());
                                        if (number == memberRepo.GetMemberById(number).MemberID && memberRepo.GetMemberById(number).Role == RoleEnum.Member)
                                        {
                                            memberRepo.GetMemberById(number).Role = RoleEnum.Administrator;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid member used");
                                            Console.ReadLine();
                                        }
                                    }
                                    determination = false;
                                }

                            }
                            #endregion
                            #region (R) Read admin
                            else if (decision == "2") //Read admin
                            {
                                bool determination = true;
                                while (determination == true)
                                {
                                    foreach (Member members in memberRepo.GetSpecificMembersByRole(RoleEnum.Administrator))
                                    {
                                        Console.WriteLine(members.ToString());
                                    }
                                    Console.ReadLine();
                                    determination = false;
                                }
                            }
                            #endregion
                            #region (U) Update admin
                            else if (decision == "3")//Update admin
                            {
                                foreach (Member members in memberRepo.GetSpecificMembersByRole(RoleEnum.Administrator))
                                {
                                    Console.WriteLine(members.ToString());
                                }
                                Console.WriteLine("------------------------------------");
                                Console.WriteLine("Input an admins id:");
                                Console.WriteLine("");
                                int idNumber = Convert.ToInt32(Console.ReadLine());
                                foreach (Member admins in memberRepo.GetSpecificMembersByRole(RoleEnum.Administrator))
                                {
                                    if (idNumber == admins.MemberID)
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Admins current information:");
                                        if (idNumber == admins.MemberID)
                                        {
                                            Console.WriteLine(admins.ToString());
                                        }
                                        Console.WriteLine("Choose which information about the admin that you want to change:" +
                                                "\n1: Name" +
                                                "\n2: Age" +
                                                "\n3: Phone number" +
                                                "\n4: Mail" +
                                                "\n5: Password");
                                        string choice = Console.ReadLine();
                                        if (choice == "1") //navn
                                        {
                                            Console.WriteLine("Input a new name:");
                                            string nameTyped = Console.ReadLine();
                                            if (nameTyped != admins.Name || nameTyped.Length < 0)
                                            {
                                                admins.Name = nameTyped!;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Name cannot be the same as before nor must it have more than 0 characters.");
                                                Console.ReadLine();
                                            }
                                        }
                                        else if (choice == "2") //alder
                                        {
                                            Console.WriteLine("Input a new age:");
                                            int age = Convert.ToInt32(Console.ReadLine());
                                            if (age != admins.Age || age < 100 || age > 0)
                                            {
                                                admins.Age = age;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Age must be in between 0 or 100 or the same age as before");
                                            }
                                        }
                                        else if (choice == "3") //Telefon nummer
                                        {
                                            Console.WriteLine("Input a new Phone number:");
                                            string phoneNumber = Console.ReadLine();
                                            if (phoneNumber != admins.PhoneNumber || phoneNumber.Length == 8)
                                            {
                                                admins.PhoneNumber = phoneNumber!;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Phone number must have exactly 8 characters.");
                                            }
                                        }
                                        else if (choice == "4") // Mail
                                        {
                                            Console.WriteLine("Input a new Mail:");
                                            string mail = Console.ReadLine();
                                            if (mail != admins.Mail || mail.Contains("@gmail") || mail.Contains("@yahoo") || mail.Contains("@hotmail") || mail.Contains("@outlook") || mail.Contains("@office365"))
                                            {
                                                admins.Mail = mail;
                                            }
                                            else
                                            {
                                                Console.WriteLine("The inputted Mail is incorrect.");
                                            }
                                        }
                                        else if (choice == "5") //Password
                                        {
                                            Console.WriteLine("Input a new Password:");
                                            string password = Console.ReadLine();
                                            if (password != admins.Password || password.Length < 5)
                                            {
                                                admins.Password = password;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Password must not be the same as before and be larger than 5 characters");
                                            }
                                        }
                                    }
                                    else if (idNumber != admins.MemberID)
                                    {
                                        Console.WriteLine("Admin with the entered id doesnt exist.");
                                        Console.ReadLine();
                                        break;
                                    }
                                }
                            }
                            #endregion
                            #region (D) Delete admin - done
                            else if (decision == "4")//Delete admin
                            {
                                Console.WriteLine($"\nInsert the number associated with the action:" +
                                    $"\n1: Changes the role of an admin to a member" +
                                    $"\n2: Deletes an existing admin\n");
                                string theSecondChoice = Console.ReadLine();
                                if (theSecondChoice == "1") //omdøbes den valgte admins til at ændres til member rollen
                                {
                                    Console.WriteLine("----------------------------------------------------------------");
                                    Console.WriteLine("Admins:\n");
                                    foreach (Member members in memberRepo.GetSpecificMembersByRole(RoleEnum.Administrator))
                                    {
                                        Console.WriteLine(members.ToString());
                                    }
                                    Console.WriteLine("----------------------------------------------------------------");
                                    Console.WriteLine("Insert an existing admins id to change their role to a member:");
                                    int newNumber = Convert.ToInt32(Console.ReadLine());
                                    if (newNumber == memberRepo.GetMemberById(newNumber).MemberID && memberRepo.GetMemberById(newNumber).Role == RoleEnum.Administrator)
                                    {
                                        memberRepo.GetMemberById(newNumber).Role = RoleEnum.Member;
                                    }
                                    else
                                    {
                                        Console.WriteLine("No admin found from the inputted id");
                                    }

                                }
                                else if (theSecondChoice == "2") //sletter helt kontoen
                                {
                                    Console.WriteLine("Insert an existing admins id to delete their account:");
                                    foreach (Member members in memberRepo.GetSpecificMembersByRole(RoleEnum.Administrator))
                                    {
                                        Console.WriteLine(members.ToString());
                                    }
                                    int enteredNumber = Convert.ToInt32(Console.ReadLine());
                                    if (enteredNumber == memberRepo.GetMemberById(enteredNumber).MemberID && memberRepo.GetMemberById(enteredNumber).Role == RoleEnum.Administrator)
                                    {
                                        memberRepo.RemoveMember(enteredNumber);
                                        if (memberRepo.GetAll().Count <= 0)
                                        {
                                            Console.WriteLine("There are no admins");
                                            Console.ReadLine();
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid id entered");
                                        Console.ReadLine();
                                        break;
                                    }

                                }
                            }
                            break;
                        #endregion
                        #endregion
                        #region 2. Change Chairman
                        case "2": //ændre formandskab
                            Console.WriteLine("Input the users id to change Chairman:");
                            Console.WriteLine("");
                            foreach (Member getMembers in memberRepo.GetAll())
                            {
                                if (getMembers.Role != RoleEnum.Chairman)
                                {
                                    Console.WriteLine(getMembers.ToString());
                                }
                            }
                            int id = Convert.ToInt32(Console.ReadLine());
                            if (memberRepo.GetMemberById(id) == null) //makes sure that the NullReferenceException is not being outputted
                            {
                                Console.WriteLine("There are no members with that id");
                                Console.ReadLine();
                                break;
                            }
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("Chosen member/administrator:\n");
                            if (id == memberRepo.GetMemberById(id).MemberID && memberRepo.GetMemberById(id).Role == RoleEnum.Member || memberRepo.GetMemberById(id).Role == RoleEnum.Administrator)
                            {
                                Console.WriteLine(memberRepo.GetMemberById(id).ToString());
                            }
                            Console.WriteLine("---------------------------------------");
                            Console.WriteLine("\nDo you want to confirm your action?");
                            Console.WriteLine("");
                            string confirmation = Console.ReadLine().ToLower();
                            if (confirmation == "ja" || confirmation == "yes")
                            {
                                //rollen bliver tildelt til en ny formand ud fra id
                                if (id == memberRepo.GetMemberById(id).MemberID && memberRepo.GetMemberById(id).Role == RoleEnum.Member || memberRepo.GetMemberById(id).Role == RoleEnum.Member)
                                {
                                    memberRepo.GetMemberById(id).Role = RoleEnum.Chairman;
                                    member.Role = RoleEnum.Member;
                                }
                            }
                            break;
                        #endregion
                        #region 3. View alle user - done
                        case "3"://skal kunne view alle members
                            foreach (Member members in memberRepo.GetAll())
                            {
                                Console.WriteLine(members.ToString());
                            }
                            Console.ReadLine();
                            break;
                        #endregion
                        #region 4. Vælge en bestemt member
                        case "4"://skal kunne vælge en bestemt valgt member (findes member ud fra deres id)
                            foreach (Member m1 in memberRepo.GetAll())
                            {
                                Console.WriteLine("Enter a members id number:");
                                int enteredNumber = Convert.ToInt32(Console.ReadLine());
                                if (enteredNumber == m1.MemberID)
                                {
                                    Console.WriteLine(m1.ToString() + $"{m1.Mail}");
                                    Console.ReadLine();
                                    break;
                                }
                                if (enteredNumber != m1.MemberID)
                                {
                                    Console.WriteLine("No member has the entered id");
                                    Console.ReadLine();
                                    break;
                                }
                            }
                            break;
                        #endregion
                        #region 5. Sortering af både pladser
                        case "5"://sortere boatlots (contains more information about boat lots, compared to the statistics version of boatlot)
                            int theirNumber = 0;
                            Console.WriteLine("Every BoatLots:");
                            foreach (BoatLot boatLot in boatLotRepo.GetAll())
                            {
                                foreach (Member m1 in memberRepo.GetAll())
                                {
                                    if (m1._boatLotsRented.Contains(boatLot))
                                    {
                                        Console.WriteLine($"\nMember ID: {m1.MemberID.ToString()}, Name: {m1.Name.ToString()}" +
                                            $"Boat lot info:{boatLot.ToString()}");
                                        theirNumber++;
                                    }
                                }
                            }
                            foreach (BoatLot boatLot in boatLotRepo.GetAll())
                            {
                                foreach (Member m1 in memberRepo.GetAll())
                                {
                                    if (!m1._boatLotsRented.Contains(boatLot) && theirNumber == 0)
                                    {
                                        Console.WriteLine("There are no boatlot's");
                                        theirNumber++;
                                    }
                                }
                            }
                            Console.WriteLine("");
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine("Your Boat Lots:");
                            int yourNumber = 0;
                            foreach (BoatLot boatLot in boatLotRepo.GetAll())
                            {
                                if (member._boatLotsRented.Contains(boatLot))
                                {
                                    Console.WriteLine(boatLot.ToString());
                                    yourNumber++;
                                }
                            }
                            foreach (BoatLot boatLot in boatLotRepo.GetAll())
                            {
                                if (!member._boatLotsRented.Contains(boatLot) && yourNumber == 0)
                                {
                                    Console.WriteLine("You have no boat lots.");
                                    yourNumber++;
                                }
                            }
                            Console.ReadLine();
                            break;
                        #endregion
                        #region 6. Simple statistikker
                        case "6"://simple statistikker
                            Console.WriteLine("Members in total:");
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine($"There are {memberRepo.GetAll().Count()} members in total.");
                            Console.WriteLine($"There are {memberRepo.GetSpecificMembersByRole(RoleEnum.Member).Count()} members in total with the role member."); 
                            Console.WriteLine($"There are {memberRepo.GetSpecificMembersByRole(RoleEnum.Administrator).Count()} members in total with the role administrator.");
                            Console.WriteLine($"There are {memberRepo.GetSpecificMembersByRole(RoleEnum.Chairman).Count()} members in total with the role chairman ");
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine($"Remaining boat lots left in total: {member._boatLotsRented.Capacity - member._boatLotsRented.Count}");
                            Console.WriteLine("\nMembers that have a boat lot and how many boat lots:");
                            int processed = 0; //indicator that makes sure that there arent multiple prints of the same person
                            if (processed == 0)
                            {
                                foreach (BoatLot boatLot in boatLotRepo.GetAll())
                                {
                                    foreach (Member memb in memberRepo.GetAll())
                                    {
                                        if (memb._boatLotsRented.Contains(boatLot) && processed == 0)
                                        {

                                            Console.WriteLine($"ID: {memb.MemberID.ToString()}, Navn: {memb.Name.ToString()} har {memb._boatLotsRented.Count} båd pladser.");
                                            processed++;
                                            break;
                                        }
                                    }
                                }
                            }
                            else if (processed == 1)
                            {
                                break;
                            }
                            Console.ReadLine();
                            break;
                        #endregion
                        #region 7. Slette og lave members
                        case "7": //kan delete users og lave user
                            Console.WriteLine("Please insert a number to proceed:");
                            Console.WriteLine("1: Create a new member");
                            Console.WriteLine("2: Delete an existing member");
                            Console.WriteLine("");
                            string firstChoice = Console.ReadLine();
                            if (firstChoice == "1") //Adds a new user
                            {
                                Console.WriteLine("Insert the following information that the member will contain:");
                                Console.WriteLine("------------------------------------------");
                                Console.WriteLine("Insert Name");
                                string name = Console.ReadLine();
                                Console.WriteLine("Insert Age:");
                                int age = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Insert which membership that the member will have:");
                                Console.WriteLine("1 = Family Member");
                                Console.WriteLine("2 = Member");
                                Console.WriteLine("3 = Passive Member");
                                string membership = Console.ReadLine();
                                MembershipEnum isMembership = new();
                                if (membership == "1")
                                {
                                    isMembership = MembershipEnum.FamilieMedlem;
                                }
                                else if (membership == "2")
                                {
                                    isMembership = MembershipEnum.Medlem;
                                }
                                else if (membership == "3")
                                {
                                    isMembership = MembershipEnum.PassiveMedlem;
                                }
                                Console.WriteLine("Insert Mail:");
                                string mail = Console.ReadLine();
                                Console.WriteLine("Insert Password:");
                                string password = Console.ReadLine();
                                Console.WriteLine("Insert Phone number");
                                string phoneNumber = Console.ReadLine();
                                AddMembersController newMember = new AddMembersController(name, age, isMembership, mail, password, phoneNumber, memberRepo);
                                newMember.Member.Role = RoleEnum.Member;
                                memberRepo.AddMember(newMember.Member);
                            }
                            else if (firstChoice == "2") //deletes an existing user
                            {
                                Console.WriteLine("---------------------------------------------------");
                                Console.WriteLine("Members:\n");
                                foreach (Member members in memberRepo.GetSpecificMembersByRole(RoleEnum.Member))
                                {
                                    Console.WriteLine(members.ToString());
                                }
                                foreach (Member members in memberRepo.GetSpecificMembersByRole(RoleEnum.Administrator))
                                {
                                    Console.WriteLine(members.ToString());
                                }
                                Console.WriteLine("");
                                Console.WriteLine("Insert a members id that you would want to remove:");
                                Console.WriteLine("---------------------------------------------------");
                                int secondChoice = Convert.ToInt32(Console.ReadLine());
                                if (memberRepo.GetMemberById(secondChoice) == null) //makes sure that the NullReferenceException is not being outputted
                                {
                                    Console.WriteLine("There are no members");
                                    Console.ReadLine();
                                    break;
                                }
                                else if (secondChoice == memberRepo.GetMemberById(secondChoice).MemberID && memberRepo.GetMemberById(secondChoice).Role == RoleEnum.Member || memberRepo.GetMemberById(secondChoice).Role == RoleEnum.Administrator)
                                {
                                    memberRepo.RemoveMember(secondChoice);
                                    if (memberRepo.GetAll().Count == 0)
                                    {
                                        Console.WriteLine("There are no members");
                                        Console.ReadLine();
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid id entered");
                                    Console.ReadLine();
                                    break;
                                }
                            }
                            break;
                        #endregion
                        #region 8. View ens oplysninger - done
                        case "8"://skal kunne kigge på ens oplysninger
                            {
                                Console.WriteLine(member.ToString() + $"Mail: {member.Mail}");
                                Console.ReadLine();
                            }
                            break;
                        #endregion
                        #region 9. Edit ens konto - done
                        case "9": //redigere deres konto
                            {
                                Console.WriteLine("Your current information:");
                                member.ToString();
                                Console.WriteLine("Choose which information which you would like to change of your account by inputting the number:" +
                                    "\n1: Name" +
                                    "\n2: Age" +
                                    "\n3: Phone number" +
                                    "\n4: Mail" +
                                    "\n5: Password");
                                string choice = Console.ReadLine();
                                if (choice == "1") //navn
                                {
                                    Console.WriteLine("Input a new name:");
                                    string nameTyped = Console.ReadLine();
                                    if (nameTyped != member.Name || nameTyped.Length < 0)
                                    {
                                        member.Name = nameTyped!;
                                    }
                                    else
                                    {
                                        Console.WriteLine("The name must not be the same as the one before and have 1 or more characters");
                                        Console.ReadLine();
                                    }
                                }
                                else if (choice == "2") //alder
                                {
                                    Console.WriteLine("Input a new age:");
                                    int age = Convert.ToInt32(Console.ReadLine());
                                    if (age != member.Age || age < 100 || age > 0)
                                    {
                                        member.Age = age;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Age must be inbetween 0 and 100 and not the same as your old age.");
                                        Console.ReadLine();
                                        break;
                                    }
                                }
                                else if (choice == "3") //Telefon nummer
                                {
                                    Console.WriteLine("Input a new phone number:");
                                    string phoneNumber = Console.ReadLine();
                                    if (phoneNumber != member.PhoneNumber || phoneNumber.Length == 8)
                                    {
                                        member.PhoneNumber = phoneNumber!;
                                    }
                                    else
                                    {
                                        Console.WriteLine("The phone number must have exactly 8 digits.");
                                        Console.ReadLine();
                                        break;
                                    }
                                }
                                else if (choice == "4") // Mail
                                {
                                    Console.WriteLine("Input a new mail:");
                                    string mail = Console.ReadLine();
                                    if (mail != member.Mail || mail.Contains("@gmail") || mail.Contains("@yahoo") || mail.Contains("@hotmail") || mail.Contains("@outlook") || mail.Contains("@office365"))
                                    {
                                        member.Mail = mail;
                                    }
                                    else
                                    {
                                        Console.WriteLine("The new mail is incorrect, start over.");
                                        Console.ReadLine();
                                        break;
                                    }
                                    //member.Mail = Console.ReadLine();
                                }
                                else if (choice == "5") //Password
                                {
                                    Console.WriteLine("Input a new password:");
                                    string password = Console.ReadLine();
                                    if (password != member.Password || password.Length < 5)
                                    {
                                        member.Password = password;
                                    }
                                    else
                                    {
                                        Console.WriteLine("The password that has been entered must not be the same as the old and contain 5 or more characters.");
                                        Console.ReadLine();
                                    }
                                }
                            }
                            break;
                        #endregion
                        #region 10. tilføje boatlots til en selv - done
                        case "10"://tilføje boatlots 
                            Console.WriteLine($"You have currently: {member._boatLotsRented.Count} boat lots that your renting.");
                            Console.WriteLine($"There are {member._boatLotsRented.Count}/{member._boatLotsRented.Capacity} boat lots rented");
                            Console.WriteLine($"-----------------------------------------------");
                            Console.WriteLine("Insert the number of boat lots that you want: ");
                            Console.WriteLine("Familie member: 400 kr. = 1 boat lot");
                            Console.WriteLine("Senior  member: 400 kr. = 1 boat lot");
                            Console.WriteLine("Junior  member: 200 kr. = 1 boat lot");
                            bool ying = true;
                            while (ying == true)
                            {
                                foreach (BoatLot data in boatLotRepo.GetAll())
                                {
                                    if (data.IsRented == false)//checks if there are boat lots that are not rented
                                    {
                                        {
                                            Console.WriteLine($"{data.ToString()}\n");
                                        }
                                    }
                                }
                                Console.WriteLine("Input the id of the boat lot, that you want:");
                                int numberInputted = Convert.ToInt32(Console.ReadLine());
                                if (boatLotRepo.GetBoatLotById(numberInputted) != null)
                                {
                                    memberRepo.addBoatLotToMember(boatLotRepo.GetBoatLotById(numberInputted)!, member);
                                    break;
                                }
                                ying = false;
                            }
                            break;
                            #endregion
                    }
                    if (memberRepo.GetMemberById(member.MemberID).Role == RoleEnum.Member)
                    {
                        readChoices = "1. View your details\t\n2. Edit your account\t\n3. View boat lots\t\nq. Exits. \t\n";
                    }
                    theChoice = ReadChoice(readChoices);

                }
                #endregion
            }
        }
        #endregion

        public void GuestMemberMenu(MemberRepo memberRepo)
        {
            Console.WriteLine("Input a name");
            string name = Console.ReadLine();
            Console.WriteLine("Input age");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input which membership u would like:");
            Console.WriteLine("1 = Family Member");
            Console.WriteLine("2 = Member");
            Console.WriteLine("3 = Passive Member");
            string membership = Console.ReadLine();
            MembershipEnum isMembership = new();
            if (membership == "1")
            {
                isMembership = MembershipEnum.FamilieMedlem;
            }
            else if (membership == "2")
            {
                isMembership = MembershipEnum.Medlem;
            }
            else if (membership == "3")
            {
                isMembership = MembershipEnum.PassiveMedlem;
            }
            Console.WriteLine("Input the mail");
            string mail = Console.ReadLine();
            Console.WriteLine("Input password");
            string password = Console.ReadLine();
            Console.WriteLine("INput phone number");
            string phoneNumber = Console.ReadLine();
            AddMembersController newMember = new AddMembersController(name, age, isMembership, mail, password, phoneNumber, memberRepo);
            memberRepo.AddMember(newMember.Member);
        }
    }
}

