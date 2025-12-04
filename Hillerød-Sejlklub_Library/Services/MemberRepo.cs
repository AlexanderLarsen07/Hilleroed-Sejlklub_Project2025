using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Services
{
    public class MemberRepo : IMemberRepo
    {
        private Dictionary<int, Member> _memberDictionary;
        public MemberRepo()
        {
            _memberDictionary = new Dictionary<int, Member>();
        }

        public void AddMember()
        {
            foreach(KeyValuePair<int, Member> member in _memberDictionary)
            {
                _memberDictionary.Add(member.Key, member.Value);
            }
        }
        public Dictionary<int, Member> GetAll()
        {
            //return _memberDictionary.Values.ToDictionary();
            return null;
        }

        //removes a member by the entering id that matches member id
        public void RemoveMember(int id)
        {
            foreach(KeyValuePair<int, Member> member in _memberDictionary)
            {
                if(member.Key == id)
                {
                    _memberDictionary.Remove(member.Key);
                    return;
                }
            }
        }
        //return customer that contains the id
        public Member GetCustomerById(int id)
        {
            if (_memberDictionary.ContainsKey(id))
            {
                return _memberDictionary[id];
            }
            return null;
        }

        public void PrintAllMembers()
        {
            foreach (KeyValuePair<int, Member> members in _memberDictionary)
            {
                Console.WriteLine(members);
            }
        }

        public void EditMember()
        {

        }
    }
}
