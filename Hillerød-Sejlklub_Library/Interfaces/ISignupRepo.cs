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
        public int Count { get; }
        List<Signup> GetAll();
        Signup ReturnAllByMember(Member member);
        Signup ReturnAllByEvent(Event even);
        void RemoveSignup(Signup signup);
        void AddSignup(Signup signup);
        void PrintAll();
    }
}
