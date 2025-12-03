using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub_Library.Models;

namespace Hillerød_Sejlklub_Library.Interfaces
{
    public interface IEventRepo
    {
        public int Count { get; }
        List<Event> GetAll();
        Event ReturnByDateRange(DateTime start, DateTime end);
        void RemoveEvent(int eventID);
        void AddEvent(Event even);
        void PrintAllEvents();
    }
}
