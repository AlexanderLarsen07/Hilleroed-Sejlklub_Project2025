using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models;
using Hillerød_Sejlklub_Library.Models.Boats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Services
{
    public class BoatRepo : IBoat
    {
        
        private List<Boat> _boat;
        public BoatRepo()
        {
            _boat = new List<Boat>();
        }
        
        public List<Boat> GetAll()
        {
            return _boat;
        }

        public void AddBoat(Boat boat)
        {
            foreach (Boat boatOnList in _boat)
            {
                if (boat.SailNumber == boatOnList.SailNumber)
                {
                    throw new Exception(message: "SailNumber already exist");
                }

            }
            _boat.Add(boat);
        }

        public Boat GetBoatBySailNumber(string SailNumber)
        {
            for (int i = 0; _boat.Count > i; i++)
            {
                if (SailNumber == _boat[i].SailNumber)
                {
                    return _boat[i];
                }
            }
            throw new Exception(message: "SailNumber doesn’t exist");
        }


        public void RemoveBySailNumber(string SailNumber)
        {
            int i = 0;
            while (_boat.Count > i)
            {
                if (SailNumber == _boat[i].SailNumber)
                {
                    _boat.RemoveAt(i);
                    return;
                }
                i++;
            }
            throw new Exception(message: "SailNumber doesn’t exist");
        }

        public void PrintAllBoats()
        {
            foreach (Boat boatOnList in _boat)
            {
                Console.WriteLine($"{boatOnList}");
            }
        } 
    }
}
