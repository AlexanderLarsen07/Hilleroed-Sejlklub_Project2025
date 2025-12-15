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

        public void Roles(string readChoices, Member? member, MemberRepo memberRepo, BoatLotRepo boatLotRepo)
        {
            string theChoice = ReadChoice(readChoices);
            while (theChoice != "q")
            {
                #region Members with role Member
                if (member.Role == RoleEnum.Member) //skal kunne kigge på Membership oplysninger, redigere deres konto, tilføje boatlots
                {
                    switch (theChoice)
                    {
                        case "1"://skal kunne kigge på ens oplysninger
                            {
                                Console.WriteLine(member.ToString() + $"\n{member.Mail}");
                            }
                            break;
                        case "2": //redigere deres konto
                            {
                                Console.WriteLine("Dine Nuværende Informationer:");
                                Console.WriteLine(member.ToString());
                                Console.WriteLine("Choose an option from a number to edit, or q to quit:" +
                                    "\n1: Navn" +
                                    "\n2: Alder" +
                                    "\n3: Telefon Nummer" +
                                    "\n4: Mail" +
                                    "\n5: Password");
                                bool ChoiceQuit = false;
                                while (!ChoiceQuit)
                                {
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
                                        string mail = Console.ReadLine().Trim();
                                        if (!memberRepo.EmailCheckExist(mail) && mail != member.Mail && mail.Contains("@" + ".") && !mail.Contains("@.") && !mail.Contains(".@"))
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
                            }
                            break;
                        case "3"://tilføje boatlots
                            Console.WriteLine($"Du har lige nu: {member._boatLotsRented.Count} boat lots som er lejet.");
                            Console.WriteLine($"-----------------------------------------------");
                            Console.WriteLine("Indtast mængde af boat lots som du ønsker: ");
                            Console.WriteLine("Familie member: 400 kr. = 1 boat lot");
                            Console.WriteLine("Senior  member: 400 kr. = 1 boat lot");
                            Console.WriteLine("Junior  member: 200 kr. = 1 boat lot");
                            int numberOfBoatLotsRented = Convert.ToInt32(Console.ReadLine());
                            if (numberOfBoatLotsRented > 0)
                            {
                                for (int i = 0; i < numberOfBoatLotsRented; i++)
                                {
                                    BoatLot bl = new BoatLot(20, 20); //ændre dette senere til at man selv kan tilføje 
                                    member._boatLotsRented.Add(bl);
                                    //member._boatLotsRented.Add() = boatLotsRented;
                                }
                            }
                            break;
                    }
                    theChoice = ReadChoice(readChoices);
                }
                #endregion
                #region Members with role Admin
                else if (member.Role == RoleEnum.Administrator) //skal kunne alt membersne kan, skal kunne view alle members og en bestemt valgt member, sortere boatlots (sorterings algoritmer), simple statistikker, kan delete users og lave user
                {
                    switch (theChoice)
                    {
                        case "1": //skal kunne view alle members
                            foreach (Member m1 in memberRepo.GetAll()) //Maybe it works?
                            {
                                if (m1.Role == RoleEnum.Member)
                                {
                                    Console.WriteLine(member.ToString() + $"\n{member.Mail}");
                                }
                            }
                            break;
                        case "2"://skal kunne vælge en bestemt valgt member (findes member ud fra deres id)
                            foreach (Member m1 in memberRepo.GetAll()) //Maybe it works?
                            {
                                if (m1.Role == RoleEnum.Member)
                                {
                                    int enteredNumber = Convert.ToInt32(Console.ReadLine());
                                    if (enteredNumber == m1.MemberID)
                                    {
                                        Console.WriteLine(member.ToString() + $"\n{member.Mail}");
                                    }
                                }
                            }
                            break;
                        case "3": //sortere boatlots (sorterings algoritmer)    -   not done
                            foreach (BoatLot boatLot in boatLotRepo.GetAll())
                            {
                                foreach (Member m1 in memberRepo.GetAll()) //Maybe it works?
                                {
                                    if (m1._boatLotsRented != null)
                                    {
                                        Console.WriteLine(m1.MemberID);
                                        Console.WriteLine(m1.Name);
                                        Console.WriteLine(m1._boatLotsRented);
                                    }
                                }
                            }
                            break;
                        case "4": //simple statistikker     -   not done
                            Console.WriteLine("Brugere i alt:");
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine($"Der er {memberRepo.GetAll().Count} brugere i alt.");
                            Console.WriteLine($"Der er {member._members.Count.CompareTo(RoleEnum.Member)} brugere i alt der er member.");
                            Console.WriteLine($"Der er {member._members.Count.CompareTo(RoleEnum.Administrator)} brugere i alt der administrator.");
                            Console.WriteLine($"Der er {member._members.Count.CompareTo(RoleEnum.Chairman)} brugere i alt der er formand ");
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("Mængde af båd pladser tilbage:");
                            Console.WriteLine($"{member._boatLotsRented.Capacity}");
                            Console.WriteLine("\nBrugere der har bådpladser og mængden::");
                            foreach (Member memb in memberRepo.GetAll())
                            {
                                if (memberRepo.addBoatLotToMember != null)
                                {
                                    Console.WriteLine($"ID: {memb.MemberID}, Navn: {memb.Name} har {memb._boatLotsRented} båd pladser.");
                                }
                            }
                            break;
                        case "5": //kan delete users og lave user
                            string firstChoice = Console.ReadLine();
                            if (firstChoice == "1") //Adds a new user
                            {
                                Console.WriteLine("Indtast Informationerne om den nye member:");
                                Console.WriteLine("------------------------------------------");
                                Console.WriteLine("Indtast Navnet");
                                string name = Console.ReadLine();
                                Console.WriteLine("Indtast Alderen");
                                int age = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Indtast hvilken Membership som Memberen skal have");
                                Console.WriteLine("1 = Familie Medlem");
                                Console.WriteLine("2 = Medlem");
                                //Console.WriteLine("3 = Passive Medlem");
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
                                //else if (membership == "3")
                                //{
                                //    isMembership = MembershipEnum.PassiveMedlem;
                                //}
                                Console.WriteLine("Indtast Mailen");
                                string mail = Console.ReadLine();
                                Console.WriteLine("Indtast Passwordet");
                                string password = Console.ReadLine();
                                Console.WriteLine("Indtast Telefon nummer");
                                string phoneNumber = Console.ReadLine();
                                AddMembersController newMember = new AddMembersController(name, age, isMembership, mail, password, phoneNumber, memberRepo);
                                newMember.Member.Role = RoleEnum.Member;
                                newMember.AddMember();
                            }
                            else if (firstChoice == "2") //deletes an existing user
                            {
                                foreach (Member m1 in memberRepo.GetAll()) //Maybe it works?
                                {
                                    if (m1.Role == RoleEnum.Member)
                                    {
                                        Console.WriteLine("Indtast ID'et af memberen som der ønskes at slette:");
                                        Console.WriteLine("---------------------------------------------------");
                                        int secondChoice = Convert.ToInt32(Console.ReadLine());
                                        if (secondChoice == m1.MemberID)
                                        {
                                            m1._members.Remove(m1.MemberID);
                                        }
                                    }
                                }
                            }
                            break;
                        case "6"://skal kunne kigge på ens oplysninger
                            {
                                Console.WriteLine(member.ToString() + $"\n{member.Mail}");
                            }
                            break;
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
                        case "8"://tilføje boatlots
                            Console.WriteLine($"Du har lige nu: {member._boatLotsRented.Count} boat lots som er lejet.");
                            Console.WriteLine($"-----------------------------------------------");
                            Console.WriteLine("Indtast mængde af boat lots som du ønsker: ");
                            Console.WriteLine("Familie member: 400 kr. = 1 boat lot");
                            Console.WriteLine("Senior  member: 400 kr. = 1 boat lot");
                            Console.WriteLine("Junior  member: 200 kr. = 1 boat lot");
                            int boatLotsRented = Convert.ToInt32(Console.ReadLine());
                            if (boatLotsRented < 0)
                            {
                                for (int i = 0; i < boatLotsRented; i++)
                                {
                                    BoatLot bl = new BoatLot(100, 100);
                                    member._boatLotsRented.Add(bl);
                                    //member._boatLotsRented.Add() = boatLotsRented;
                                }
                            }
                            break;
                    }
                    theChoice = ReadChoice(readChoices);
                }
                #endregion
                #region Members with role chairman
                else if (member.Role == RoleEnum.Chairman) //skal alt admins kan, CRUD admins, ændre formandskab
                {
                    switch (theChoice) //(1, 2, 5, 6 and 7) not finished
                    {
                        #region 1. CRUD Admins - not finished
                        case "1": //CRUD admins - not done
                            Console.WriteLine("Input Which Crud method u want to do:");
                            Console.WriteLine("1. (C) Create admin");
                            Console.WriteLine("2. (R) Read   admin");
                            Console.WriteLine("3. (U) Update admin");
                            Console.WriteLine("4. (D) Delete admin");
                            Console.WriteLine();
                            string decision = Console.ReadLine();
                            #region (C) Create admin - (the lower part doesnt work) - almost done
                            if (decision == "1")  //Create admin - not done
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
                                        Console.WriteLine("Indtast Informationerne om den nye administrator:");
                                        Console.WriteLine("------------------------------------------");
                                        Console.WriteLine("Indtast Navnet");
                                        string name = Console.ReadLine();
                                        Console.WriteLine("Indtast Alderen");
                                        int age = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Indtast hvilken Membership som administratoren skal have");
                                        Console.WriteLine("1 = Familie Medlem");
                                        Console.WriteLine("2 = Medlem");
                                        Console.WriteLine("3 = Passive Medlem");
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
                                        Console.WriteLine("Indtast Mailen");
                                        string mail = Console.ReadLine();
                                        Console.WriteLine("Indtast Passwordet");
                                        string password = Console.ReadLine();
                                        Console.WriteLine("Indtast Telefon nummer");
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
                                        Console.WriteLine(memberRepo.GetMemberByRole());
                                        Console.WriteLine("--------------------------");
                                        Console.WriteLine("");
                                        int number = Convert.ToInt32(Console.ReadLine());
                                        if (number == memberRepo.GetMemberByRole().MemberID)
                                        {
                                            //memberRepo.GetMemberById(number).Role = RoleEnum.Administrator;
                                            memberRepo.AddMember(memberRepo.GetMemberById(number));
                                            memberRepo.GetMemberById(number).Role = RoleEnum.Administrator;
                                            break;
                                        }
                                    }
                                    determination = false;
                                }

                            }
                            #endregion
                            #region (R) Read admin - done
                            else if (decision == "2") //Read admin
                            {
                                bool determination = true;
                                while (determination == true)
                                {
                                    Console.WriteLine(memberRepo.GetAdministratorByRole());
                                    Console.ReadLine();
                                    determination = false;
                                }
                            }
                            #endregion
                            #region (U) Update admin - not done
                            else if (decision == "3")//Update admin
                            {
                                Console.WriteLine(memberRepo.GetAdministratorByRole());
                                Console.WriteLine("Indtast en Admins id:");
                                int idNumber = Convert.ToInt32(Console.ReadLine());
                                if (idNumber == memberRepo.GetAdministratorByRole().MemberID) //nulreference
                                {
                                    Console.WriteLine("Admindens nuværende informationer:");
                                    if (idNumber == memberRepo.GetMemberByRole().MemberID)
                                    {
                                        Console.WriteLine(memberRepo.GetAdministratorByRole().ToString());
                                    }
                                    Console.WriteLine("Vælg hvilke informationer om adminden du ville ændres ud fra tallet:" +
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
                                        if (nameTyped != memberRepo.GetAdministratorByRole().Name || nameTyped.Length < 0)
                                        {
                                            memberRepo.GetAdministratorByRole().Name = nameTyped!;
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
                                        if (age != memberRepo.GetAdministratorByRole().Age || age < 100 || age > 0)
                                        {
                                            memberRepo.GetAdministratorByRole().Age = age;
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
                                        if (phoneNumber != memberRepo.GetAdministratorByRole().PhoneNumber || phoneNumber.Length == 8)
                                        {
                                            memberRepo.GetAdministratorByRole().PhoneNumber = phoneNumber!;
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
                                        if (mail != memberRepo.GetAdministratorByRole().Mail || mail.Contains("@gmail") || mail.Contains("@yahoo") || mail.Contains("@hotmail") || mail.Contains("@outlook") || mail.Contains("@office365"))
                                        {
                                            memberRepo.GetAdministratorByRole().Mail = mail;
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
                                        if (password != memberRepo.GetAdministratorByRole().Password || password.Length < 5)
                                        {
                                            memberRepo.GetAdministratorByRole().Password = password;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Passwordet må ikke være det samme som den gamle password og skal være større end 5 karakterer");
                                        }
                                        //member.Password = Console.ReadLine();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Brugeren med dette id findes ikke, prøv igen.");
                                }
                            }
                            #endregion
                            #region (D) Delete admin - not done
                            else if (decision == "4")//Delete admin
                            {
                                Console.WriteLine($"\nInsert the number associated with the action:" +
                                    $"\n1: Changes the role of an admin to a member" +
                                    $"\n2: Deletes an existing admin\n");
                                string theSecondChoice = Console.ReadLine();
                                if (theSecondChoice == "1") //omdøbes den valgte admins til at ændres til member rollen
                                {
                                    Console.WriteLine("Inseret an existing admins id to change their role to a member:");
                                    int newNumber = Convert.ToInt32(Console.ReadLine());
                                    if (newNumber == memberRepo.GetAdministratorByRole().MemberID)
                                    {
                                        member.Role = RoleEnum.Member;
                                    }
                                }
                                else if (theSecondChoice == "2") //sletter helt kontoen
                                {
                                    Console.WriteLine("Insert an existing admins id to delete their account:");
                                    Console.WriteLine(memberRepo.GetAdministratorByRole().ToString());
                                    int enteredNumber = Convert.ToInt32(Console.ReadLine());
                                    foreach(Member members in memberRepo.GetAll())
                                    {
                                        if(members.Role == RoleEnum.Administrator && enteredNumber == members.MemberID)
                                        {

                                            memberRepo.RemoveMember(enteredNumber);
                                        }
                                        else
                                        {
                                            Console.WriteLine("There are no admins associated with the inserted id.");
                                            Console.ReadLine();
                                        }
                                    }
                                }
                            }
                            break;
                        #endregion
                        #endregion
                        #region 2. Change Chairman - (exception and roles not working) - not finished
                        case "2": //ændre formandskab
                            Console.WriteLine("Input the users id to change Chairman:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            if (id == memberRepo.GetMemberById(id).MemberID) //exception makes me unable to output else
                            {
                                Console.WriteLine("\nDo you want to confirm your action?");
                                Console.WriteLine(memberRepo.GetMemberById(id).ToString());
                                Console.WriteLine("");
                                string confirmation = Console.ReadLine().ToLower();
                                if (confirmation == "ja" || confirmation == "yes")
                                {
                                    if (member.Role == RoleEnum.Chairman) //rollen formandskab bliver fjernet for den nuværende formand
                                    {
                                        member.Role = RoleEnum.Administrator; //not done
                                    }
                                    while (id == memberRepo.GetMemberById(id).MemberID) //rollen bliver tildelt til en ny formand ud fra id
                                    {
                                        memberRepo.GetMemberById(id).Role = RoleEnum.Chairman; //not done
                                        theChoice = ReadChoice(readChoices);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Brugeren findes ikke, prøv igen.");
                                Console.ReadLine();
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
                        #region 4. Vælge en bestemt member - done
                        case "4"://skal kunne vælge en bestemt valgt member (findes member ud fra deres id)
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
                        #region 5. Sortering af både pladser - (confused? how to do) - not finished
                        case "5"://sortere boatlots (sorterings algoritmer)    -   not done
                            foreach (BoatLot boatLot in boatLotRepo.GetAll())
                            {
                                foreach (Member m1 in memberRepo.GetAll()) //Maybe it works?
                                {
                                    if (m1._boatLotsRented.Contains(boatLot))
                                    {
                                        Console.WriteLine(m1.ToString().Count());
                                        Console.WriteLine(m1.MemberID.ToString());
                                        Console.WriteLine(m1.Mail!.ToString());
                                        Console.WriteLine(m1._boatLotsRented.ToString());
                                        Console.ReadLine();
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You have no boatlot's");
                                        Console.ReadLine();
                                        break;
                                    }
                                }
                            }
                            break;
                        #endregion
                        #region 6. Simple statistikker  -  (nulreference) - not finished
                        case "6"://simple statistikker
                            Console.WriteLine("Members in total:");
                            Console.WriteLine("------------------------------------------");
                            foreach (Member members in memberRepo.GetAll())
                            {
                                Console.WriteLine($"There are {member.ToString().Count()} members in total.");
                            }
                            Console.WriteLine($"There are {memberRepo.GetMemberByRole()._members.Count} members in total with the role member."); //nulreference
                            Console.WriteLine($"There are {memberRepo.GetAdministratorByRole()._members.Count} members in total with the role administrator.");//nulreference
                            Console.WriteLine($"There are {memberRepo.GetChairmanByRole()._members.Count} members in total with the role chairman ");//nulreference
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine($"Remaining boat lots left in total: {member._boatLotsRented.Capacity}");
                            Console.WriteLine("\nMembers that have a boat lot and how many boat lots:");
                            foreach (BoatLot boatLot in boatLotRepo.GetAll())
                            {
                                foreach (Member memb in memberRepo.GetAll())
                                {
                                    if (memb._boatLotsRented.Contains(boatLot))
                                    {
                                        Console.WriteLine($"ID: {memb.MemberID.ToString()}, Navn: {memb.Name.ToString()} har {memb._boatLotsRented.Count} båd pladser.");
                                    }
                                }
                            }
                            Console.ReadLine();
                            break;
                        #endregion
                        #region 7. Slette og lave members - (fix the delete version) - almost done
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
                                Console.WriteLine("Members");
                                Console.WriteLine("---------------------------------------------------");
                                Console.WriteLine(memberRepo.GetAdministratorByRole());
                                Console.WriteLine(memberRepo.GetMemberByRole());
                                Console.WriteLine("");
                                Console.WriteLine("Insert a members id that you would want to remove:");
                                Console.WriteLine("---------------------------------------------------");
                                int secondChoice = Convert.ToInt32(Console.ReadLine());
                                if (secondChoice == memberRepo.GetAdministratorByRole().MemberID || secondChoice == memberRepo.GetMemberByRole().MemberID) //nullReference
                                {
                                    memberRepo.RemoveMember(secondChoice);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid id entered");
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
                        #region 10. tilføje boatlots til en selv - done
                        case "10"://tilføje boatlots 
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
            }
        }
        public void GuestMemberMenu(MemberRepo memberRepo)
        {
            Console.WriteLine("Indtast Navn");
            string name = Console.ReadLine();
            Console.WriteLine("Indtast Alder");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Indtast hvilken Membership som du ønsker");
            Console.WriteLine("1 = Familie Medlem");
            Console.WriteLine("2 = Medlem");
            Console.WriteLine("3 = Passive Medlem");
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
            Console.WriteLine("Indtast din Mail");
            string mail = Console.ReadLine();
            Console.WriteLine("Indtast Passwordet");
            string password = Console.ReadLine();
            Console.WriteLine("Indtast Telefon nummer");
            string phoneNumber = Console.ReadLine();
            AddMembersController newMember = new AddMembersController(name, age, isMembership, mail, password, phoneNumber, memberRepo);
            memberRepo.AddMember(newMember.Member);
        }
    }
}

