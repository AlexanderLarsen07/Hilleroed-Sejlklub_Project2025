using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models;

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

        public Signup ReturnAllByEvent(Event even)
        {
            foreach(Signup signup in _signupList)
            {
                if(signup.Event == even)
                {
                    return signup;
                }
            }
            return null;
        }

        public Signup ReturnAllByMember(Member member)
        {
            foreach(Signup signup in _signupList)
            {
                if(signup.Member == member)
                {
                    return signup;
                }
            }
            return null;
        }
    }
}
