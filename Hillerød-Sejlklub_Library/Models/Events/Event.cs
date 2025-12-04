using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub_Library.Services;

namespace Hillerød_Sejlklub_Library.Models.Events
{
    public class Event
    {
        #region Instance fields
        private static int _eventID = 1;
        public List<Signup> _signups;
        #endregion
        #region Properties
        public int EventID 
        { 
            get { return _eventID; }
            private set { _eventID = value; }
        }
        public int MaxMembers { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; private set; }
        public string Description { get; set; }
        #endregion
        #region Constructor
        public Event(int maxMembers, string title, DateTime date, string description)
        {
            _signups = new List<Signup>();
            EventID = _eventID++;
            MaxMembers = maxMembers;
            Title = title.Trim();
            Date = date;
            Description = description.Trim();
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
