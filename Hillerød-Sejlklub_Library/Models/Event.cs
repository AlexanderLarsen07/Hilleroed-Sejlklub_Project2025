using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Models
{
    public class Event
    {
        #region Instance fields
        private static int eventID = 1;
        public List<Signup> _signups;
        #endregion
        #region Properties
        public int EventID 
        { 
            get { return eventID; }
            private set { eventID = value; }
        }
        public int MaxMembers { get; private set; }
        public string Title { get; private set; }
        public DateTime Date { get; private set; }
        public string Description { get; private set; }
        #endregion
        #region Constructor
        public Event(int maxMembers, string title, DateTime date, string description)
        {
            _signups = new List<Signup>();
            EventID = eventID++;
            MaxMembers = maxMembers;
            Title = title;
            Date = date;
            Description = description;
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"\t{Title}\n\t" +
                $"Date : {Date}\n\t" +
                $"Current signups : {_signups.Count} / {MaxMembers}\n\t" +
                $"{Description}";
        }
        #endregion
    }
}
