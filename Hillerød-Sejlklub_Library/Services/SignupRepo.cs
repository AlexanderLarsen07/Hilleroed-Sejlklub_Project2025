using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;

namespace Hillerød_Sejlklub_Library.Services
{
    public class SignupRepo : ISignupRepo
    {
        private List<Signup> _signupList;
        public int Count { get { return _signupList.Count; } }
        public SignupRepo()
        {
            _signupList = new List<Signup>();
        }

        public void AddSignup(Signup signup)
        {
            if (!_signupList.Contains(signup))
            {
                _signupList.Add(signup);
            }
        }

        public List<Signup> GetAll()
        {
                return _signupList;
        }

        public void PrintAll()
        {
            foreach(Signup signup in _signupList)
            {
                Console.WriteLine(signup);
            }
        }

        public void RemoveSignup(Signup signup)
        {
            _signupList.Remove(signup);
        }

        public List<Signup> ReturnAllByEventTitle(string title)
        {
            List<Signup> signups = [];
            foreach(Signup signup in _signupList)
            {
                if(signup.Event.Title.ToLower() == title || signup.Event.Title.ToUpper() == title)
                {
                    signups.Add(signup);
                }
            }
            return signups;
        }

        public List<Signup> ReturnAllByMember(Member member)
        {
            List<Signup> signups = [];
            foreach(Signup signup in _signupList)
            {
                if(signup.Member == member)
                {
                    signups.Add(signup);
                }
            }
            return signups;
        }
        public void EditComment(Member member, string comment, string title)
        {
            List<Signup> signups = ReturnAllByMember(member);
            foreach(Signup s in signups)
            {
                if (s.Event.Title.ToLower() == title || s.Event.Title.ToUpper() == title)
                {
                    s.Comment = comment;
                }
            }
        }
    }
}
