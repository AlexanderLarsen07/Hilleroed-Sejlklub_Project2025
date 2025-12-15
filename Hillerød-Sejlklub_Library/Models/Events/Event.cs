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
        private int _eventID;
        private static int _counter = 1;
        public List<Signup> _signups;
        #endregion
        #region Properties
        public int EventID { get { return _eventID; } }
        public int MaxMembers { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; private set; }
        public string Description { get; set; }
        #endregion
        #region Constructor
        public Event(int maxMembers, string title, DateTime date, string description)
        {
            _signups = new List<Signup>();
            _eventID = _counter++;
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
