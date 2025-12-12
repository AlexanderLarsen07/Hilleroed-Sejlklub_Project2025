using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Members;

namespace Hillerød_Sejlklub_Library.Services
{
    public class BoatLotRepo : IBoatLotRepo
    {
        private Dictionary<int, BoatLot> _boatLotDictionary;
        public BoatLotRepo()
        {
            _boatLotDictionary = new Dictionary<int, BoatLot>();
        }
    
        public List<BoatLot> GetAll()
        {
            return _boatLotDictionary.Values.ToList();
        }
        public void AddBoatLot(BoatLot boatLot)
        {
            if(!_boatLotDictionary.ContainsKey(boatLot.LotID))
            {
                _boatLotDictionary.Add(boatLot.LotID, boatLot);
            }
        }
        public BoatLot? GetBoatLotById(int id)
        {
            if (_boatLotDictionary.ContainsKey(id))
            {
                return _boatLotDictionary[id];
            }
            return null;
        }
        public void RemoveBoatLot(int id)
        {
            foreach (KeyValuePair<int, BoatLot> boatLot in _boatLotDictionary)
            {
                if (boatLot.Key == id)
                {
                    _boatLotDictionary.Remove(boatLot.Key);
                    return;
                }
            }
        }
        public void PrintAllBoatLots()
        {
            foreach (KeyValuePair<int, BoatLot> boatLots in _boatLotDictionary)
            {
                Console.WriteLine(boatLots);
            }
        }
    }
}
