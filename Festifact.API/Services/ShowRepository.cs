using System.Collections.Generic;
using System.Linq;
using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Services
{
    public class ShowRepository : IShowRepository
    {
        private List<Show> _showList;

        public ShowRepository()
        {
            InitializeData();
        }

        public IEnumerable<Show> All
        {
            get { return _showList; }
        }

        public bool DoesShowExist(int id)
        {
            return _showList.Any(show => show.ShowId == id);
        }

        public Show Find(int id)
        {
            return _showList.FirstOrDefault(show => show.ShowId == id);
        }

        public void Insert(Show item)
        {
            _showList.Add(item);
        }

        public void Update(Show festival)
        {
            var selectedFestival = this.Find(festival.FestivalId);
            var index = _showList.IndexOf(selectedFestival);
            _showList.RemoveAt(index);
            _showList.Insert(index, festival);
        }

        public void Delete(int FestivalId)
        {
            _showList.Remove(this.Find(FestivalId));
        }

        private void InitializeData()
        {
            _showList = new List<Show>();

            var show1 = new Show
            {
                ShowId = 1,
                Name = "Animistic Beliefs (live)",
                Description = "‘Animism’ is the belief that all objects, natural phenomena, and plants have a soul. In the hands of Linh Luu and Marvin Lalihatu, modular synths and drum computers do come alive. Animistic Beliefs infuses their ingenious music with their personal and political stories, and cultural elements taken from their own Southeast Asian heritage. From killer electronics with a punk attitude to slick electro in Drexciyan fashion; the Rotterdam-based duo can pull anything from analog machinery, and they do that damn well.",
                Image = "https://shapeplatform.eu/wp-content/uploads/2020/01/img-5122-1200x800-q70.jpeg",
                FestivalId = 1,
                ArtistId = 1,
                MovieId = null,
                RoomReservationId = 1,
                FestivalDay = 1,
                StartDate = new DateTime(2022, 8, 3, 13, 00, 00),
                EndDate = new DateTime(2022, 8, 3, 23, 00, 00)
            };

            var show2 = new Show
            {
                ShowId = 2,
                Name = "CHAOS IN THE CBD",
                Description = "De in Nieuw-Zeeland geboren broers Ben en Louis Helliker-Hales (ook bekend als Chaos In The CBD) creëren ingetogen house en techno met elementen van jazz. De broers, geboren in 1989, werden opgevoed met het luisteren naar de rockplaten van hun ouders en voegden zich in hun vroege tienerjaren bij jazz- en indiebands. Halverwege de jaren 2000 ontdekten ze elektronische muziek en leerden ze uiteindelijk te produceren en te DJ’en. In 2011 begonnen ze te touren in Europa en moedigden ze hen aan om Auckland permanent te verlaten voor een betere toegang tot hun Europese publiek; ze verhuisden naar Peckham, Londen in 2012.",
                Image = "https://www.blijdorpfestival.nl/wp-content/uploads/2022/02/Chaos-in-the-CBD-700x700.png",
                FestivalId = 2,
                ArtistId = 2,
                MovieId = null,
                RoomReservationId = null,
                FestivalDay = 1,
                StartDate = new DateTime(2022, 8, 6, 12, 00, 00),
                EndDate = new DateTime(2022, 8, 6, 23, 00, 00)
            };

            var show3 = new Show
            {
                ShowId = 3,
                Name = "Arctic Monkeys",
                Description = "Arctic Monkeys are an English rock band formed in Sheffield in 2002. The group consists of Alex Turner, Jamie Cook, Nick O'Malley, and Matt Helders. Former band member Andy Nicholson left the band in 2006 shortly after their debut album was released.",
                Image = "https://shapeplatform.eu/wp-content/uploads/2020/01/img-5122-1200x800-q70.jpeg",
                FestivalId = 3,
                ArtistId = 3,
                MovieId = null,
                RoomReservationId = 1,
                FestivalDay = 6,
                StartDate = new DateTime(2022, 8, 15, 21, 00, 00),
                EndDate = new DateTime(2022, 8, 15, 23, 00, 00)
            };

            _showList.Add(show1);
            _showList.Add(show2);
            _showList.Add(show3);
        }

        IEnumerable<Show> IShowRepository.GetFestivalShows(int festivalId)
        {
            IEnumerable<Show> FiltredList = _showList;
            FiltredList = FiltredList.Where(show => show.FestivalId.Equals(festivalId));
            return FiltredList;
        }
    }
}