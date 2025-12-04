using Hillerød_Sejlklub_Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Models.Members
{
    public class Member
    {
        private static int _memberID;
        public string Name { get; set; }
        public int Age { get; set; }
        public int SubscriptionFee { get; set; }
        public RoleEnum Role { get; set; }
        public int MemberID { get; set; }
        public List<BoatLot> _boatLotsRented;
        public string Mail { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public string Type { get; set; }
        public MembershipEnum Membership { get; set; }
        Dictionary<int, MemberRepo> _members;

        public Member(string name, int age, MembershipEnum membershipEnum, string mail, string password, int phoneNumber) {
            Name = name;
            Membership = membershipEnum;
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

        public int CalculateInitialMembershipFee()
        {
            SubscriptionFee = 0;
            if(Membership == MembershipEnum.PassiveMedlem)
            {
                SubscriptionFee = 250;
            }
            else if (Membership == MembershipEnum.FamilieMedlem)
            {
                SubscriptionFee = 1500;
                SubscriptionFee = SubscriptionFee + _boatLotsRented.Count * 400;
            }
            else if(Membership == MembershipEnum.Medlem)
            {
                if (Age >= 19)
                {
                    SubscriptionFee = 1100;
                    SubscriptionFee = SubscriptionFee + _boatLotsRented.Count * 400;

                }
                else if (Age <= 18)
                {
                    SubscriptionFee = 750;
                    SubscriptionFee = SubscriptionFee + _boatLotsRented.Count * 200;
                }
            }
            return SubscriptionFee = SubscriptionFee + 150;
        }

        public string MembershipType()
        {
            if (Membership == MembershipEnum.PassiveMedlem)
            {
                Type = "Passiv medlem";
            }
            else if (Membership == MembershipEnum.FamilieMedlem)
            {
                Type = "Familie (hele husstanden)";
            }
            else if (Membership == MembershipEnum.Medlem)
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
            return Type;
        }


        public override string ToString()
        {
            return $"{MemberID}" +
                $"Navn: {Name}\n" +
                $"Alder: {Age}\n" +
                $"Membership: {Type}\n" +
                $"Price: {SubscriptionFee}\n" +
                $"Telefon Nummer: {PhoneNumber}\n";
        }
    }
}
