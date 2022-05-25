using System.Collections.Generic;
using System.Linq;
using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Services
{
    public class LocationRepository : ILocationRepository
    {
        private List<Location> _LocationList;

        public LocationRepository()
        {
            InitializeData();
        }

        public IEnumerable<Location> All
        {
            get { return _LocationList; }
        }

        public bool DoesLocationExist(int id)
        {
            return _LocationList.Any(location => location.LocationId == id);
        }

        public Location Find(int id)
        {
            return _LocationList.FirstOrDefault(location => location.LocationId == id);
        }

        public void Insert(Location item)
        {
            _LocationList.Add(item);
        }

        public void Update(Location location)
        {
            var selectedLocation = this.Find(location.LocationId);
            var index = _LocationList.IndexOf(selectedLocation);
            _LocationList.RemoveAt(index);
            _LocationList.Insert(index, location);
        }

        public void Delete(int LocationId)
        {
            _LocationList.Remove(this.Find(LocationId));
        }

        private void InitializeData()
        {
            _LocationList = new List<Location>();

            var location1 = new Location
            {
                LocationId = 1,
                Name = "Dekmantel Location",
                Description = "Dekmantel is an electronic music location in Amsterdam. A cutting edge affair, this location annually curates the most creative and influential acts in house, techno and more. ",
                Banner = "https://i.imgur.com/anluDmy.jpg",
                TicketsAvailable = 471,
                TicketsLimit = 1555,
                Type = "Music",
                Genre = "Techno",
                Location = "Amstelveen",
                AgeCatagory = "18+",
                StartDate = new DateTime(2022, 8, 3, 13, 00, 00),
                EndDate = new DateTime(2022, 8, 7, 23, 00, 00),
                OrganisatorId = 1
            };

            var location2 = new Location
            {
                LocationId = 2,
                Name = "Blijdorp Location",
                Description = "Blijdorp combines ‘Music, Art & Happiness’ at its events, with the summer edition as an annual highlight. Join us for our 7th summer edition, where the Roel Langerakpark will host a green land of discovery, with stages set amongst its forests and alongside its lake.",
                Banner = "https://i.imgur.com/dnkzAtE.jpg",
                TicketsAvailable = 1132,
                TicketsLimit = 3000,
                Type = "Music",
                Genre = "Techno",
                Location= "Rotterdam",
                AgeCatagory = "18+",
                StartDate = new DateTime(2022, 8, 6, 12, 00, 00),
                EndDate = new DateTime(2022, 8, 6, 23, 00, 00),
                OrganisatorId = 1
            };

            var location3 = new Location
            {
                LocationId = 3,
                Name = "Sziget Location",
                Description = "The Sziget Location is one of the largest music and cultural locations in Europe. It is held every August in northern Budapest, Hungary, on Óbudai-sziget, a leafy 108-hectare island on the Danube. More than 1,000 performances take place each year.",
                Banner = "https://i.imgur.com/Gpjfr81.jpg",
                TicketsAvailable = 3521,
                TicketsLimit = 385000,
                Type = "Music",
                Genre = "Rock",
                Location = "Budapest",
                AgeCatagory = "ALL, Guidance under 14",
                StartDate = new DateTime(2022, 8, 10, 16, 00, 00),
                EndDate = new DateTime(2022, 8, 15, 4, 00, 00),
                OrganisatorId = 2
            };

            _LocationList.Add(location1);
            _LocationList.Add(location2);
            _LocationList.Add(location3);
        }

    }
}