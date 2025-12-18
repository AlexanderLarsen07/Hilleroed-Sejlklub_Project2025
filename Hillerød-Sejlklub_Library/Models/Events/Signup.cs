using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub_Library.Exceptions;
using Hillerød_Sejlklub_Library.Models.Members;
using Hillerød_Sejlklub_Library.Services;

namespace Hillerød_Sejlklub_Library.Models.Events
{
    public class Signup
    {
        #region Instance fields
        private DateTime _dateOfSignup;
        #endregion
        #region Properties
        public string Comment { get; set; }
        public Event Event { get; private set; }
        public Member Member { get; private set; }
        public DateTime DateOfSignup { get { return _dateOfSignup; } }
        #endregion
        #region Constructor
        public Signup(Event ev, Member member, string comment)
        {
            _dateOfSignup = DateTime.Now;
            Event = ev;
            Member = member;
            Comment = comment.Trim();
            try
            {

                if (Event.Signups.Count < Event.MaxMembers)
                {
                    Event.Signups.Add(this);
                }
            }
            catch (EventFullException efv)
            {
                new EventFullException(efv.Message);
            }
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"\tMember : {Member.Name} : MemberID : {Member.MemberID} " +
                $"\n\tEvent : {Event.Title}\n\t" +
                $"Signed up : {_dateOfSignup}\n\t" +
                $"Comment : {Comment}";
        }
        #endregion
    }
}


