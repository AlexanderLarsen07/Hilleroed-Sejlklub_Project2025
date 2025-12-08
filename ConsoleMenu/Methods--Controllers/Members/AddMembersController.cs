using ConsoleMenu.Menu;
using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Models.Members
{
    public class AddMembersController
    {
        IMemberRepo _memberRepo;
        public Member Member { get; set; }

        public AddMembersController(string name, int age, MembershipEnum membershipEnum, string mail, string password, string phoneNumber, IMemberRepo memberRepo)
        {
            Member = new Member(name, age, membershipEnum, mail, password, phoneNumber);
            _memberRepo = memberRepo;
        }
        public void AddMember()
        {
            _memberRepo.AddMember(Member);
        }
    }
}
