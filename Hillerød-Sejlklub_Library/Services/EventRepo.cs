using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models;

namespace Hillerød_Sejlklub_Library.Services
{
    public class EventRepo : IEventRepo
    {
        private Dictionary<int, Event> _events;
        public int Count { get { return _events.Count; } }
        public EventRepo()
        {
            _events = new Dictionary<int, Event>();
        }
        public List<Event> GetAll()
        {
            return _events.Values.ToList();
        }

        public Event ReturnByDateRange(DateTime from, DateTime to)
        {
            foreach(KeyValuePair<int, Event> even in _events)
            {
                if (even.Value.Date > from && even.Value.Date < to)
                {
                    return even.Value;
                }
            }
            return null;
        }

        public void RemoveEvent(int eventID)
        {
            _events.Remove(eventID);
        }

        public void AddEvent(Event even)// Tilføj check på members role enum
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
    }
}
