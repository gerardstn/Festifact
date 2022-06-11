using System.Collections.Generic;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Interfaces
{
    public interface IRoomRepository
    {
        bool DoesRoomExist(int id);
        IEnumerable<Room> All { get; }
        Room Find(int roomId);
        void Insert(Room room);
        void Update(Room room);
        void Delete(int roomId);
        IEnumerable<Room> GetLocationRooms(int locationId);

    }
}