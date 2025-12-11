using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;

namespace Hillerød_Sejlklub_Library.Data
{
    public class MockData
    {
        #region Instancefields
        private static Dictionary<int, Member> _memberData = new Dictionary<int, Member>()
        {
            {1 ,new Member("name", 17, MembershipEnum.Medlem, "mail@yes.efs", "password", "12121212") },
            {2, new Member("gustaf", 19, MembershipEnum.Medlem, "gustaf@mail.com", "password", "13131313") },
            {3, new Member("steve", 64, MembershipEnum.PassiveMedlem, "steve@gmail.com", "password", "14141414") }
        };
        
        private static List<DateTime> _dateTimeData = new List<DateTime>()
        {
            { new DateTime(2004, 04, 12, 13, 30, 0) },
            { new DateTime(2006, 04, 13, 11, 30, 0) },
            { new DateTime(2020, 06, 24, 16, 45, 0) }
        };

        private static Dictionary<int, BoatLot> _boatLotData = new Dictionary<int, BoatLot>()
        {
            {1, new BoatLot(400, 600) },
            {2, new BoatLot(500, 400) },
            {3, new BoatLot(300, 200) }
        };

        private static Dictionary<int, Event> _eventData = new Dictionary<int, Event>()
        {
            {1, new Event(1, "title", _dateTimeData[0], "description") },
            {2, new Event(15, "Coffee", _dateTimeData[1], "Free cookies") },
            {3, new Event(9, "Boat prep", _dateTimeData[2], "We prepare the War Canoes") }
        };

        private static List<Signup> _signupData = new List<Signup>()
        {
            {new Signup(_eventData[0], _memberData[1], "Comment-1") },
            {new Signup(_eventData[0], _memberData[2], "Comment-1") },
            {new Signup(_eventData[2], _memberData[3], "Coment-3") }
        };
        #endregion
        
        #region Properties
        public static Dictionary<int, BoatLot> BoatLotData
        {
            get { return _boatLotData; }
        }

        public static Dictionary<int, Member> MemberData
        {
            get { return _memberData; }
        }
        
        private static List<DateTime> DateTimes
        {
            get { return _dateTimeData; }
        }

        private static Dictionary<int, Event> EventData
        {
            get { return _eventData; }
        }

        private static List<Signup> SignupData
        {
            get { return _signupData; }
        }
        #endregion
    }
}
