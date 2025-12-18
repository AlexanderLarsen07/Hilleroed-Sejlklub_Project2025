using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;

namespace Hillerød_Sejlklub_Library.Interfaces
{
    public interface ISignupRepo
    {
        List<Signup> GetAll();
        List<Signup> ReturnAllByMember(Member member);
        List<Signup> ReturnAllByEventTitle(string title);
        void RemoveSignup(Signup signup);
        void AddSignup(Signup signup);
        void PrintAll();
        List<Signup> SortByDateOfSignup();
        void EditComment(Member member, string comment, string title);
    }
}
