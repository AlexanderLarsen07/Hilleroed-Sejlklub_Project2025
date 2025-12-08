using Hillerød_Sejlklub_Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Models.Members
{
    public class AddMembersController
    {
        IMemberRepo _memberRepository;
        public Member Member { get; set; }

        public AddMembersController(string name, int age, MembershipEnum membershipEnum, string mail, string password, string phoneNumber)
        {
            Member = new Member(name, age, membershipEnum, mail, password, phoneNumber);

        }
        public void AddMember()
        {
            _memberRepository.AddMember(Member);
        }
    }
}
