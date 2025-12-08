using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;

namespace ConsoleMenu.Methods.Events
{
    public class AddEventController
    {
        IEventRepo _eventRepo;
        public Event Event { get; set; }

        public AddEventController(int maxMembers, string title, DateTime date, string description, IEventRepo eventRepo)
        {
            Event = new Event(maxMembers, title, date, description);
            _eventRepo = eventRepo;
        }
        public void AddMember()
        {
            _eventRepo.AddEvent(Event);
        }
    }
}
