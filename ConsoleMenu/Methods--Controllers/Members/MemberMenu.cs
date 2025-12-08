using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Members;
using Hillerød_Sejlklub_Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

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
        public void Roles(Member memberRole, string member)
        {
            if (memberRole.Role == null)
            {
                switch (member)
                {
                    case "1": //SignUP
                        Console.WriteLine("Indtast Navn");
                        string name = Console.ReadLine()!;
                        Console.WriteLine("Indtast Alder");
                        int age = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Indtast hvilken Membership som du ønsker");
                        Console.WriteLine("1 = Familie Medlem");
                        Console.WriteLine("2 = Medlem");
                        //Console.WriteLine("3 = Passive Medlem");
                        string membership = Console.ReadLine()!;
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
                        string mail = Console.ReadLine()!;
                        Console.WriteLine("Indtast Passwordet");
                        string password = Console.ReadLine()!;
                        Console.WriteLine("Indtast Telefon nummer");
                        string phoneNumber = Console.ReadLine()!;
                        AddMembersController newMember = new AddMembersController(name, age, isMembership, mail, password, phoneNumber);
                        newMember.AddMember();
                        break;
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
            }
            if (memberRole.Role == RoleEnum.Member) //skal kunne kigge på Membership oplysninger, redigere deres konto, tilføje boatlots
            {
                switch (member)
                {
                    case "1":

                        break;
                }
            }
            if (memberRole.Role == RoleEnum.Administrator) //skal kunne alt membersne kan, skal kunne view alle members og en bestemt valgt member, sortere boatlots (sorterings algoritmer), simple statistikker, kan delete users og lave user
            {
                switch (member)
                {
                    case "1":

                        break;
                }
            }
            if (memberRole.Role == RoleEnum.Chairman) //skal alt admins kan, CRUD admins, ændre formandskab (confirmation button)
            {
                switch (member)
                {
                    case "1":

                        break;
                }
            }
        }
    }
}
