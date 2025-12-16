using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub_Library.Data;
using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;

namespace Hillerød_Sejlklub_Library.Services
{
    public class SignupRepo : ISignupRepo
    {
        private List<Signup> _signupList;
        public SignupRepo()
        {
            _signupList = new List<Signup>();
            _signupList = MockData.SignupData;
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
                if(signup.Event.Title.Trim().ToLower() == title.Trim().ToLower())
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
                if (s.Event.Title.Trim().ToLower() == title.Trim().ToLower())
                {
                    s.Comment = comment;
                }
            }
        }
        public List<Signup> SortByDateOfSignup()//
        {
            List<Signup> signups = _signupList;
            int unsortedSignups = signups.Count;
            bool sorted = false;
            while (!sorted)
            {
                int timesSwapped = 0;
                for (int i = 1; i < unsortedSignups; i++)
                {
                    if (signups[i].DateOfSignup < signups[i - 1].DateOfSignup)
                    {
                        Signup tempSignup = signups[i];
                        signups[i] = signups[i - 1];
                        signups[i - 1] = tempSignup;
                        timesSwapped++;
                    }
                }
                if (timesSwapped == 0)
                {
                    sorted = true;
                }
                unsortedSignups--;
            }
            return signups;
        }
    }
}
