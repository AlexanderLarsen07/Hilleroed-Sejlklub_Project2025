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
        public enum Role { get }
        public int MemberID { get; }
        public List<BoatLot> BoatLotsRented;
        public bool IsFamily { get; }
        public string Mail { get; }
        public string Password { get; }
        public int PhoneNumber { get; }

        public Member(string name, bool isFamily, string mail, string password, int phoneNumber) {
            Name = name;
            IsFamily = isFamily;
            Mail = mail;
            Password = password;
            PhoneNumber = phoneNumber;
            //Increment ID
            MemberID = _memberID;
            
        }

        public void CalculateMembershipFee(int age, bool isFamily, List<BoatLots> boatLotsRented)
        {
        }
        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}
