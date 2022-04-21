using System.Collections.Generic;
using System.Linq;
using Festifact.API.Interfaces;
using Festifact.API.Models;

namespace Festifact.API.Services
{
    public class FestifactRepository : IFestifactRepository
    {
        private List<Festival> _festivalList;

        public FestifactRepository()
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

        public void Insert(Festival item)
        {
            _festivalList.Add(item);
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
                Name = "Lowlands",
                Description = "lorum ipsom dolar sit amet",
                Banner = "https://blabla.com/img.jpg",
                TicketsAvailable = 100,
                TicketsLimit = 100,
                Type = "something",
                Genre = "punk",
                AgeCatagory = "16+",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };

            var festival2 = new Festival
            {
                FestivalId = 2,
                Name = "Lowlands",
                Description = "lorum ipsom dolar sit amet",
                Banner = "https://blabla.com/img.jpg",
                TicketsAvailable = 100,
                TicketsLimit = 100,
                Type = "something",
                Genre = "punk",
                AgeCatagory = "16+",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };

            var festival3 = new Festival
            {
                FestivalId = 3,
                Name = "Lowlands",
                Description = "lorum ipsom dolar sit amet",
                Banner = "https://blabla.com/img.jpg",
                TicketsAvailable = 100,
                TicketsLimit = 100,
                Type = "something",
                Genre = "punk",
                AgeCatagory = "16+",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now


            };

            _festivalList.Add(festival1);
            _festivalList.Add(festival2);
            _festivalList.Add(festival3);
        }
    }
}