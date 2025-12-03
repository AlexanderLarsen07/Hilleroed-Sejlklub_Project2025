using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub_Library.Exceptions;

namespace Hillerød_Sejlklub_Library.Models
{
    public class Signup
    {
        #region Instance fields
        private DateTime dateOfSignup;
        #endregion
        #region Properties
        public string Comment { get; private set; }
        public Event Event { get; private set; }
        public Member Member { get; private set; }
        #endregion
        #region Constructor
        public Signup(Event ev, Member member, string comment)
        {
            dateOfSignup = DateTime.Now;
            Event = ev;
            Member = member;
            Comment = comment;
            try
            {
                if (Event._signups.Count < Event.MaxMembers)
                {
                    Event._signups.Add(this);
                }
                else
                {
                    throw new EventFullException("\tCouldn't sign up to event : Event full");
                }
            }
            catch (EventFullException efe)
            {
                Console.WriteLine(efe.Message);
            } 
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"\tMember : {Member.Name}" +
                $"\n\tEvent : {Event.Title}\n\t" +
                $"Signed up : {dateOfSignup}\n\t" +
                $"Comment : {Comment}";
        }
        #endregion
    }
}
