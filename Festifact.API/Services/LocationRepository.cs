using System.Collections.Generic;
using System.Linq;
using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Services
{
    public class LocationRepository : ILocationRepository
    {
        private List<Location> _locationList;

        public LocationRepository()
        {
            InitializeData();
        }

        public IEnumerable<Location> All
        {
            get { return _locationList; }
        }

        public bool DoesLocationExist(int id)
        {
            return _locationList.Any(location => location.LocationId == id);
        }

        public Location Find(int id)
        {
            return _locationList.FirstOrDefault(location => location.LocationId == id);
        }

        public void Insert(Location item)
        {
            _locationList.Add(item);
        }

        public void Update(Location location)
        {
            var selectedLocation = this.Find(location.LocationId);
            var index = _locationList.IndexOf(selectedLocation);
            _locationList.RemoveAt(index);
            _locationList.Insert(index, location);
        }

        public void Delete(int LocationId)
        {
            _locationList.Remove(this.Find(LocationId));
        }

        private void InitializeData()
        {
            _locationList = new List<Location>();

            var location1 = new Location
            {
                LocationId = 1,
                Name = "Amstelveen - Land van Bosse",
                LocationCoordinates= "52.30500719609079, 4.819965285765246"
            };

            var location2 = new Location
            {
                LocationId = 2,
                Name = "Rotterdam - Blijdorp",
                LocationCoordinates = "51.92520784090663, 4.441967977724767"

            };

            var location3 = new Location
            {
                LocationId = 3,
                Name = "Budapest - Óbuda Island",
                LocationCoordinates = "47.55193516840761, 19.054655720258925"
            };

            _locationList.Add(location1);
            _locationList.Add(location2);
            _locationList.Add(location3);
        }

    }
}