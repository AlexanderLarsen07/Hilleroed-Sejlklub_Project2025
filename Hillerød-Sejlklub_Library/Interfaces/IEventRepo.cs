using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;

namespace Hillerød_Sejlklub_Library.Interfaces
{
    public interface IEventRepo
    {
        public int Count { get; }
        List<Event> GetAll();
        List<Event> ReturnByDateRange(DateTime start, DateTime end);
        void RemoveEvent(int eventID);
        void AddEvent(Event even);
        void PrintAllEvents();
        void EditEvent(int id, string title, int maxMembers, string description);
        List<Event> ReturnAllEventsByTitle(string title);
        bool SignupExistsCheck(Member member, Event even);
        List<Event> BubbleSortBySignups();
        void RemoveSignupOnEvent(Event even, Signup signup);
    }
}
