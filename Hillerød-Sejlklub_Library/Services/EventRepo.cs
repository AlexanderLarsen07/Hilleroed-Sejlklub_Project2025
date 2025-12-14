using Hillerød_Sejlklub_Library.Data;
using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;

namespace Hillerød_Sejlklub_Library.Services
{
    public class EventRepo : IEventRepo
    {
        private Dictionary<int, Event> _events;
        public int Count { get { return _events.Count; } }
        public EventRepo()
        {
            _events = new Dictionary<int, Event>();
            _events = MockData.EventData;
        }
        public List<Event> GetAll()
        {
            return _events.Values.ToList();
        }

        public bool SignupExistsCheck(Member member, Event even) //use to ensure no double signups
        {
            for (int i = 0; i <= even._signups.Count; i++)
            {
                if (even._signups[i].Member.MemberID == member.MemberID)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Event> ReturnByDateRange(DateTime from, DateTime to)
        {
            List<Event> events = [];
            foreach(KeyValuePair<int, Event> even in _events)
            {
                if (even.Value.Date >= from && even.Value.Date <= to)
                {
                    events.Add(even.Value);
                }
            }
            return events;
        }

        public void RemoveEvent(int eventID) //member gemmes i menu efter login, hvor Member.Role Enum checkes
        {
                _events.Remove(eventID);
        }

        public void AddEvent(Event even)
        {
            if (!_events.ContainsKey(even.EventID))
            {
                _events.Add(even.EventID, even);
            }
            
        }

        public void PrintAllEvents()
        {
            foreach(KeyValuePair<int, Event> even in _events)
            {
                Console.WriteLine(even.Value);
            }
        }

        public void EditEvent(int id, string title, int maxMembers, string description)
        {
            foreach(KeyValuePair<int, Event> even in _events)
            {
                if (even.Key == id)
                {
                    even.Value.MaxMembers = maxMembers;
                    even.Value.Title = title;
                    even.Value.Description = description;
                }
            }
        }

        public List<Event> ReturnAllEventsByTitle(string title)
        {
            List<Event> events = [];
            foreach(KeyValuePair<int, Event> even in _events)
            {
                if(even.Value.Title.Trim().ToLower() == title.Trim().ToLower())
                {
                    events.Add(even.Value);
                }
            }
            return events;
        }

    }
}
