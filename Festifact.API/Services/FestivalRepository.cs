using System.Collections.Generic;
using System.Linq;
using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Services
{
    public class FestivalRepository : IFestivalRepository
    {
        private List<Festival> _festivalList;

        public FestivalRepository()
        {
            InitializeData();
        }

        public IEnumerable<Festival> All
        {
            get { return _festivalList; }
        }

        public bool DoesFestivalExist(int id)
        {
            return _festivalList.Any(festival => festival.FestivalId == id);
        }

        public Festival Find(int id)
        {
            return _festivalList.FirstOrDefault(festival => festival.FestivalId == id);
        }

        public void Insert(Festival festival)
        {
            _festivalList.Add(festival);
        }

        public void Update(Festival festival)
        {
            var selectedFestival = this.Find(festival.FestivalId);
            var index = _festivalList.IndexOf(selectedFestival);
            _festivalList.RemoveAt(index);
            _festivalList.Insert(index, festival);
        }

        public void Delete(int FestivalId)
        {
            _festivalList.Remove(this.Find(FestivalId));
        }

        private void InitializeData()
        {
            _festivalList = new List<Festival>();

            var festival1 = new Festival
            {
                FestivalId = 1,
                Name = "Dekmantel Festival",
                Description = "Dekmantel is an electronic music festival in Amsterdam. A cutting edge affair, this festival annually curates the most creative and influential acts in house, techno and more. ",
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

            var festival2 = new Festival
            {
                FestivalId = 2,
                Name = "Blijdorp Festival",
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

            var festival3 = new Festival
            {
                FestivalId = 3,
                Name = "Sziget Festival",
                Description = "The Sziget Festival is one of the largest music and cultural festivals in Europe. It is held every August in northern Budapest, Hungary, on Óbudai-sziget, a leafy 108-hectare island on the Danube. More than 1,000 performances take place each year.",
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

            _festivalList.Add(festival1);
            _festivalList.Add(festival2);
            _festivalList.Add(festival3);
        }
        IEnumerable<Festival> IFestivalRepository.GetOrganisationFestivals(int organisationId)
        {
            IEnumerable<Festival> FiltredList = _festivalList;
            FiltredList = FiltredList.Where(festival => festival.OrganisatorId.Equals(organisationId));
            return FiltredList;
        }

        IEnumerable<Festival> IFestivalRepository.SearchFunction(string type, string genre, string age, string location, DateTime date)
        {
            IEnumerable<Festival> FiltredList = _festivalList;
                FiltredList = FiltredList.Where(festival => festival.Type.ToLower().Contains(type.ToLower()));
                FiltredList = FiltredList.Where(festival => festival.Genre.ToLower().Contains(genre.ToLower()));
                FiltredList = FiltredList.Where(festival => festival.AgeCatagory.ToLower().Contains(age.ToLower()));
                FiltredList = FiltredList.Where(festival => festival.Location.ToLower().Contains(location.ToLower()));
                FiltredList = FiltredList.Where(festival => festival.StartDate.Date <= (date.Date));
            return FiltredList; 
        }
    }
}