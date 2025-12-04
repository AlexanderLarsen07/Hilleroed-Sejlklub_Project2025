using Hillerød_Sejlklub_Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Models
{
    public class Member
    {
        private static int _memberID;
        public string Name { get; }
        public int Age { get; }
        public int SubscriptionFee { get; set; }
        public enum Role { get, }
        public int MemberID { get; }
        public List<BoatLot> _boatLotsRented;
        public bool IsFamily { get; }
        public string Mail { get; }
        public string Password { get; }
        public int PhoneNumber { get; }
        public bool PassiveMedlem { get; set; }
        public string Type { get; set; }
        public MembershipEnum MembershipEnum { get; set; }

        public Member(string name, int age, MembershipEnum membershipEnum, string mail, string password, int phoneNumber) {
            Name = name;
            MembershipEnum = membershipEnum;
            Mail = mail;
            Password = password;
            PhoneNumber = phoneNumber;
            Age = age;
            //Increment ID
            MemberID = _memberID;
            //tilføj til MemberRepo
            //make new List of BoatLotsRented
            _boatLotsRented = new List<BoatLot>();
            CalculateInitialMembershipFee();
            MembershipType();
        }

        Dictionary<int, MemberRepo> _members;

        public int CalculateInitialMembershipFee()
        {
            SubscriptionFee = 0;
                if(MembershipEnum.PassiveMedlem = MembershipEnum)
                {
                    if (IsFamily == true)
                    {
                        SubscriptionFee = 1500;
                        SubscriptionFee = SubscriptionFee + (_boatLotsRented.Count * 400);
                    }
                    else if (IsFamily == false)
                    {
                        if (Age >= 19)
                        {
                                SubscriptionFee = 1100;
                                SubscriptionFee = SubscriptionFee + (_boatLotsRented.Count * 400);

                        }
                        else if (Age <= 18)
                        {
                                SubscriptionFee = 750;
                        SubscriptionFee = SubscriptionFee + (_boatLotsRented.Count * 200);
                        }
                    }
                }
                else if(PassiveMedlem == true)
                {
                    SubscriptionFee = 250;
                }
            return SubscriptionFee = SubscriptionFee + 150;
        }

        public string MembershipType()
        {
            if (PassiveMedlem == false)
            {
                if (IsFamily == true)
                {
                    Type = "Familie (hele husstanden)";
                }
                else if (IsFamily == false)
                {
                    if (Age >= 19)
                    {

                        Type = "Senior medlem";
                    }
                    else if (Age <= 18)
                    {
                        Type = "Junior medlem";
                        }
                }
            }
            else if (PassiveMedlem == true)
            {
                Type = "Passiv medlem";
            }
            return Type;
        }


        public override string ToString()
        {
            return $"{MemberID}" +
                $"Navn: {Name}\n" +
                $"Alder: {Age}\n" +
                $"Type: {Type}\n" +
                $"Price: {SubscriptionFee}\n" +
                $"Telefon Nummer: {PhoneNumber}\n";
        }
    }
}
