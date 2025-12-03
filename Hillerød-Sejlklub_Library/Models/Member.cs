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
        public int Price { get; set; }
        public enum Role { get }
        public int MemberID { get; }
        public List<BoatLot> _boatLotsRented;
        public bool BoatLotsRentedIs;
        public bool IsFamily { get; }
        public string Mail { get; }
        public string Password { get; }
        public int PhoneNumber { get; }
        public bool PassiveMedlem { get; set; }
        public string Type { get; set; }

        public Member(string name, int age, bool isFamily, string mail, string password, string type, int phoneNumber) {
            Name = name;
            IsFamily = isFamily;
            Mail = mail;
            Password = password;
            PhoneNumber = phoneNumber;
            Age = age;
            //Increment ID
            MemberID = _memberID;
            //tilføj til MemberRepo
            //make new List of BoatLotsRented
            
        }

        Dictionary<int, MemberRepo> _members;

        public int CalculateInitialMembershipFee()
        {
            foreach(var member in _members)
            {
                if(PassiveMedlem == false)
                {
                    if (IsFamily == true)
                    {
                        Type = "Familie (hele husstanden)";
                        Price = 1500;
                        Price = Price + (_boatLotsRented.Count * 400);
                    }
                    else if (IsFamily == false)
                    {
                        if (Age >= 19)
                        {
                            if (BoatLotsRentedIs == true)
                            {
                                Type = "Senior medlem inkl. pladsleje";
                                Price = 1500;
                                Price = Price + (_boatLotsRented.Count * 400);
                            }
                            else if (BoatLotsRentedIs == false)
                            {
                                Type = "Senior medlem";
                                Price = 1100;
                                Price = Price + (_boatLotsRented.Count * 400);
                            }
                        }
                        else if (Age <= 18)
                        {
                            if (BoatLotsRentedIs == true)
                            {
                                Type = "Junior medlem inkl. pladsleje";
                                Price = 950;
                                Price = Price + (_boatLotsRented.Count * 200);
                            }
                            else if (BoatLotsRentedIs == false)
                            {
                                Type = "Junior medlem";
                                Price = 750;
                                Price = Price + (_boatLotsRented.Count * 200);
                            }
                        }
                    }
                }
                else if(PassiveMedlem == true)
                {
                    Type = "Passiv medlem";
                    Price = 250;
                }
            }
            return Price = Price + 150;
        }
        public override string ToString()
        {
            return $"{MemberID}" +
                $"Navn: {Name}\n" +
                $"Alder: {Age}\n" +
                $"Type: {Type}\n" +
                $"Familie Abonnoment: {IsFamily}\n" +
                $"Telefon Nummer: {PhoneNumber}";
        }
    }
}
