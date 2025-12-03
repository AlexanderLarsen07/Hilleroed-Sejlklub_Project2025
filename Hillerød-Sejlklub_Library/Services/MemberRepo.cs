using Hillerød_Sejlklub_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Services
{
    public class MemberRepo
    {
        Dictionary<int, Member> _memberDictionary;
        public MemberRepo()
        {
            _memberDictionary = new Dictionary<int, Member>();
        }

        public void AddMember()
        {

        }
    }
}
