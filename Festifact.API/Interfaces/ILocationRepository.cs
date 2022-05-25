using System.Collections.Generic;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Interfaces
{
    public interface ILocationRepository
    {
        bool DoesLocationExist(int id);
        IEnumerable<Location> All { get; }
        Location Find(int locationId);
        void Insert(Location location);
        void Update(Location location);
        void Delete(int locationId);
        
    }
}