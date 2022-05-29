using System.Collections.Generic;
using System.Linq;
using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Services
{
    public class RoomReservationRepository : IRoomReservationRepository
    {
        private List<RoomReservation> _roomReservationList;

        public RoomReservationRepository()
        {
            InitializeData();
        }

        public IEnumerable<RoomReservation> All
        {
            get { return _roomReservationList; }
        }

        public bool DoesRoomReservationExist(int id)
        {
            return _roomReservationList.Any(roomReservation => roomReservation.RoomReservationId == id);
        }

        public RoomReservation Find(int id)
        {
            return _roomReservationList.FirstOrDefault(roomReservation => roomReservation.RoomReservationId == id);
        }

        public void Insert(RoomReservation item)
        {
            _roomReservationList.Add(item);
        }

        public void Update(RoomReservation roomReservation)
        {
            var selectedRoomReservation = this.Find(roomReservation.RoomReservationId);
            var index = _roomReservationList.IndexOf(selectedRoomReservation);
            _roomReservationList.RemoveAt(index);
            _roomReservationList.Insert(index, roomReservation);
        }

        public void Delete(int RoomReservationId)
        {
            _roomReservationList.Remove(this.Find(RoomReservationId));
        }

        private void InitializeData()
        {
            _roomReservationList = new List<RoomReservation>();

            var roomReservation1 = new RoomReservation
            {
                RoomReservationId = 1,
                RoomId = 1,
                StartDateTime = new DateTime(2022, 8, 3, 13, 00, 00),
                EndDateTime = new DateTime(2022, 8, 3, 16, 00, 00)

            };

            var roomReservation2 = new RoomReservation
            {
                RoomReservationId = 2,
                RoomId = 2,
                StartDateTime = new DateTime(2022, 8, 6, 12, 00, 00),
                EndDateTime = new DateTime(2022, 8, 6, 13, 00, 00)
            };

            var roomReservation3 = new RoomReservation
            {
                RoomReservationId = 3,
                RoomId = 3,
                StartDateTime = new DateTime(2022, 8, 10, 16, 00, 00),
                EndDateTime =new DateTime(2022, 8, 10, 17, 00, 00)

            };

            _roomReservationList.Add(roomReservation1);
            _roomReservationList.Add(roomReservation2);
            _roomReservationList.Add(roomReservation3);
        }

    }
}