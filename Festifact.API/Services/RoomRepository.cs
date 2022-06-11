using System.Collections.Generic;
using System.Linq;
using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Services
{
    public class RoomRepository : IRoomRepository
    {
        private List<Room> _roomList;

        public RoomRepository()
        {
            InitializeData();
        }

        public IEnumerable<Room> All
        {
            get { return _roomList; }
        }

        public bool DoesRoomExist(int id)
        {
            return _roomList.Any(room => room.RoomId == id);
        }

        public Room Find(int id)
        {
            return _roomList.FirstOrDefault(room => room.RoomId == id);
        }

        public void Insert(Room item)
        {
            _roomList.Add(item);
        }

        public void Update(Room room)
        {
            var selectedRoom = this.Find(room.RoomId);
            var index = _roomList.IndexOf(selectedRoom);
            _roomList.RemoveAt(index);
            _roomList.Insert(index, room);
        }

        public void Delete(int RoomId)
        {
            _roomList.Remove(this.Find(RoomId));
        }

        private void InitializeData()
        {
            _roomList = new List<Room>();

            var room1 = new Room
            {
                RoomId = 1,
                Name = "Land van Bosse",
                LocationId = 1
            };
            var room2 = new Room
            {
                RoomId = 2,
                Name = "Blijdorp",
                LocationId = 2
            };
            var room3 = new Room
            {
                RoomId = 3,
                Name = "Cirque du Sziget",
                LocationId = 3
            };

            var room4 = new Room
            {
                RoomId = 4,
                Name = "dropYard",
                LocationId = 3
            };

            var room5 = new Room
            {
                RoomId = 5,
                Name = "ibis x ALL Europe Stage",
                LocationId = 3
            };

            _roomList.Add(room1);
            _roomList.Add(room2);
            _roomList.Add(room3);
            _roomList.Add(room4);
            _roomList.Add(room5);

        }

        IEnumerable<Room> IRoomRepository.GetLocationRooms(int locationId)
        {
            IEnumerable<Room> FiltredList = _roomList;
            FiltredList = FiltredList.Where(room => room.LocationId.Equals(locationId));
            return FiltredList;
        }

    }
}