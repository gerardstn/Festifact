using System.Collections.Generic;
using System.Linq;
using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Services
{
    public class ArtistRepository : IArtistRepository
    {
        private List<Artist> _artistList;

        public ArtistRepository()
        {
            InitializeData();
        }

        public IEnumerable<Artist> All
        {
            get { return _artistList; }
        }

        public bool DoesArtistExist(int id)
        {
            return _artistList.Any(artist => artist.ArtistId == id);
        }

        public Artist Find(int id)
        {
            return _artistList.FirstOrDefault(artist => artist.ArtistId == id);
        }

        public void Insert(Artist item)
        {
            _artistList.Add(item);
        }

        public void Update(Artist artist)
        {
            var selectedArtist = this.Find(artist.ArtistId);
            var index = _artistList.IndexOf(selectedArtist);
            _artistList.RemoveAt(index);
            _artistList.Insert(index, artist);
        }

        public void Delete(int ArtistId)
        {
            _artistList.Remove(this.Find(ArtistId));
        }

        private void InitializeData()
        {
            _artistList = new List<Artist>();

            var artist1 = new Artist
            {
                ArtistId = 1,
                Name = "Animistic Beliefs",
                Genre = "Electro",
                Description = "Rotterdam based duo delivering a lush and heavy tapestry of hypnotising electro made by their drumcomputers and (modular) synthesizers.",
                Image = "https://shapeplatform.eu/wp-content/uploads/2020/01/img-5122-1200x800-q70.jpeg",
                CountryOrigin = "Rotterdam",
                Type = "Music"
            };

            var artist2 = new Artist
            {
                ArtistId = 2,
                Name = "CHAOS IN THE CBD",
                Genre = "Dance/Electro",
                Description= "New Zealand brothers Ben and Louis Helliker-Hales are Chaos In The CBD. With their ever strengthening production credentials, the brothers have been able to mark themselves out as one of the most eminent underground duos to emerge out of the South Pacific.",
                Image= "https://imgproxy.ra.co/_/quality:100/plain/https://static.ra.co/images/events/flyer/2020/1/uk-0131-1369435-front.jpg",
                CountryOrigin = "New Zealand",
                Type = "Music"
            };

            var artist3 = new Artist
            {
                ArtistId = 3,
                Name = "Arctic Monkeys",
                Genre = "Rock",
                Description = "Arctic Monkeys are an English rock band formed in Sheffield in 2002. The group consists of Alex Turner, Jamie Cook, Nick O'Malley, and Matt Helders. Former band member Andy Nicholson left the band in 2006 shortly after their debut album was released.",
                Image = "https://guitar.com/wp-content/uploads/2022/04/Arctic-Monkeys-Credit-Gabriel-Olsen-Getty-Images-for-Radio-com@2000x1500.jpg",
                CountryOrigin = "England",
                Type = "Music"
            };

            _artistList.Add(artist1);
            _artistList.Add(artist2);
            _artistList.Add(artist3);
        }

    }
}