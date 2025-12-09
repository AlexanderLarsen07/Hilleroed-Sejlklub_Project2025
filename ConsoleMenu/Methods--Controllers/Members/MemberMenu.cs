using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Members;
using Hillerød_Sejlklub_Library.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleMenu.Methods.Members
{
    public class MemberMenu
    {
        //switch case af valgmuligheder
        //Mulighed 1:
        //
        //1. Sign up as Member
        //2. Sign in as Member
        //3. Exit
        //
        //Mulighed2.

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

        public void Roles(string readChoices, Member? member, MemberRepo memberRepo, BoatLotRepo boatLotRepo, IMemberRepo iMemberRepo)
        {
            string theChoice = ReadChoice(readChoices);
            while (theChoice != "q")
            {
                if (member == null)
                {
                    switch (theChoice)
                    {
                        case "1": //SignUP
                            {
                                Console.WriteLine("Indtast Navn");
                                string name = Console.ReadLine();
                                Console.WriteLine("Indtast Alder");
                                int age = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Indtast hvilken Membership som du ønsker");
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
                                Console.WriteLine("Indtast din Mail");
                                string mail = Console.ReadLine();
                                Console.WriteLine("Indtast Passwordet");
                                string password = Console.ReadLine();
                                Console.WriteLine("Indtast Telefon nummer");
                                string phoneNumber = Console.ReadLine();
                                AddMembersController newMember = new AddMembersController(name, age, isMembership, mail, password, phoneNumber, memberRepo);
                                newMember.AddMember();
                                //case "2": //View bestyrelsesmedlemmer (print en liste af administratoren og Chairman)
                                //    if (memberRole.Role == RoleEnum.Chairman || memberRole.Role == RoleEnum.Administrator)
                                //    {
                                //        Console.WriteLine(member);
                                //    }
                                //    break;
                                //case "2": //View Events (Alexander)

                                //    break;
                                //case "3": //View blogs/comments (Sinan)

                                //    break;
                                //case "4": //View Boat (Aksel)

                                //    break;
                            }
                            break;
                    }
                    theChoice = ReadChoice(readChoices);
                }
                else if (member.Role == RoleEnum.Member) //skal kunne kigge på Membership oplysninger, redigere deres konto, tilføje boatlots
                {
                    switch (theChoice)
                    {
                        case "1"://skal kunne kigge på Membership oplysninger
                            {
                                Console.WriteLine(member.ToString()+$"\n{member.Mail}");
                            }
                            break;
                        case "2": //redigere deres konto
                            {
                                Console.WriteLine("Dine Nuværende Informationer:");
                                member.ToString();
                                Console.WriteLine("Valg hvilke informationer du ville ændres ud fra tallet:" +
                                    "\n1: Navn" +
                                    "\n2: Alder" +
                                    "\n3: Telefon Nummer"+
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
                                    
                                }else if (choice == "2") //alder
                                {
                                    Console.WriteLine("Indtast nyt alder:");
                                    int age = Convert.ToInt32(Console.ReadLine());
                                    if (age != member.Age|| age < 100 || age > 0)
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
                                    if ( phoneNumber != member.PhoneNumber || phoneNumber.Length == 8)
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
                        case "3"://tilføje boatlots
                            Console.WriteLine($"Du har lige nu: {member._boatLotsRented.Count} boat lots som er lejet.");
                            Console.WriteLine($"-----------------------------------------------");
                            Console.WriteLine("Indtast mængde af boat lots som du ønsker: ");
                            Console.WriteLine("Familie member: 400 kr. = 1 boat lot");
                            Console.WriteLine("Senior  member: 400 kr. = 1 boat lot");
                            Console.WriteLine("Junior  member: 200 kr. = 1 boat lot");
                            int boatLotsRented = Convert.ToInt32(Console.ReadLine());
                            if (boatLotsRented < 0)
                            {
                                for (int i=0; i<boatLotsRented; i++)
                                {
                                    BoatLot bl = new BoatLot(20, 20);
                                    member._boatLotsRented.Add(bl);
                                    //member._boatLotsRented.Add() = boatLotsRented;
                                }
                            }
                            break;
                    }
                    theChoice = ReadChoice(readChoices);
                }
                else if (member.Role == RoleEnum.Administrator) //skal kunne alt membersne kan, skal kunne view alle members og en bestemt valgt member, sortere boatlots (sorterings algoritmer), simple statistikker, kan delete users og lave user
                {
                    switch (theChoice)
                    {
                        case "1": //skal kunne view alle members
                            foreach(Member m1 in memberRepo.GetAll()) //Maybe it works?
                            {
                                if(m1.Role == RoleEnum.Member)
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
                            foreach(BoatLot boatLot in boatLotRepo.GetAll())
                            {
                                foreach (Member m1 in memberRepo.GetAll()) //Maybe it works?
                                {
                                    if (false)
                                    {

                                    }
                                }
                            }
                            break;
                        case "4": //simple statistikker     -   not done

                            break;
                        case "5": //kan delete users og lave user
                            string firstChoice = Console.ReadLine();
                            if(firstChoice == "1") //Adds a new user
                            {
                                Console.WriteLine("Indtast Informationerne om den nye member:");
                                Console.WriteLine("------------------------------------------");
                                Console.WriteLine("Indtast Navn");
                                string name = Console.ReadLine();
                                Console.WriteLine("Indtast Alder");
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
                                Console.WriteLine("Indtast din Mail");
                                string mail = Console.ReadLine();
                                Console.WriteLine("Indtast Passwordet");
                                string password = Console.ReadLine();
                                Console.WriteLine("Indtast Telefon nummer");
                                string phoneNumber = Console.ReadLine();
                                AddMembersController newMember = new AddMembersController(name, age, isMembership, mail, password, phoneNumber, memberRepo);
                                newMember.AddMember();
                            } else if(firstChoice == "2") //deletes an existing user
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
                    }
                    theChoice = ReadChoice(readChoices);
                }
                else if (member.Role == RoleEnum.Chairman) //skal alt admins kan, CRUD admins, ændre formandskab (confirmation button) - not done
                {
                    switch (theChoice)
                    {
                        case "1":

                            break;
                    }
                    theChoice = ReadChoice(readChoices);
                }
            }
        }
    }
}
