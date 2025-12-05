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
        //adds Member
        public void AddMember(Member member)
        {
            if (!_memberDictionary.ContainsKey(member.MemberID))
            {
                _memberDictionary.Add(member.MemberID, member);
            }
        }
        public List<Member> GetAll()
        {
            return _memberDictionary.Values.ToList();
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

        public void Print(Dictionary<int, Member> dictionary)
        {
            foreach (KeyValuePair<int, Member> member in dictionary)
            {
                Console.WriteLine(member);
            }
        }
        public void PrintAllMembers()
        {
            foreach (KeyValuePair<int, Member> members in _memberDictionary)
            {
                Console.WriteLine(members);
            }
        }

        //only administrator and chairmand can use this method
        public Member EditMembersMembership(int id, MembershipEnum membershipEnum) // - not done
        {
            return null;
        }

        public Member? EditMember(int id, string name, int age, string mail, string password, int phoneNumber)
        {
            if (_memberDictionary.ContainsKey(id))
            {
                _memberDictionary[id].PhoneNumber = phoneNumber;
                _memberDictionary[id].Name = name;
                _memberDictionary[id].Age = age;
                //mail needs to be unique it can only be edited if the new mail
                //is NOT already in use
                if (_memberDictionary[id].Mail == null)
                {
                    _memberDictionary[id].Mail = mail;
                }
                else
                {
                    Console.WriteLine("Mail is already in use. Please try a different Mail.");
                }
                    _memberDictionary[id].Password = password;
                return _memberDictionary[id];
            }
            else
            {
                return null;
            }
        }

        //Added for funktionalitet i MenuLogin
        public Member ReturnMemberByMail(string mail)
        {
            foreach (KeyValuePair<int, Member> member in _memberDictionary)
            {
                if (member.Value.Mail == mail)
                {
                    member.Value.Mail = mail;
                }
                return member.Value;
            }
            return null;
        }

        //public Member ReturnMemberByPassword(string password)
        //{
        //    foreach(KeyValuePair<int, Member> member in _memberDictionary)
        //    {
        //        if(member.Value.Password == password)
        //        {
        //            return member.Value;
        //        }
        //    }
        //    return null;
        //}
    }
}
