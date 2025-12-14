using Hillerød_Sejlklub_Library.Models.Members;
using Hillerød_Sejlklub_Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Interfaces
{
    public interface IMemberRepo
    {
        List<Member> GetAll();
        void AddMember(Member member);
        Member GetMemberById(int id);
        void RemoveMember(int id);
        void PrintAllMembers();
        
    }
}
