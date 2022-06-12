using System.Collections.Generic;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Interfaces
{
    public interface IRoomReservationRepository
    {
        bool DoesRoomReservationExist(int id);
        IEnumerable<RoomReservation> All { get; }
        RoomReservation Find(int roomReservationId);
        void Insert(RoomReservation roomReservation);
        void Update(RoomReservation roomReservation);
        void Delete(int roomReservationId);
        IEnumerable<RoomReservation> GetRoomReservations(int id);

    }
}