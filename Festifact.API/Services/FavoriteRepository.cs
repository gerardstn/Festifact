using System.Collections.Generic;
using System.Linq;
using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Services
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private List<Favorite> _favoriteList;

        public FavoriteRepository()
        {
            InitializeData();
        }

        public IEnumerable<Favorite> All
        {
            get { return _favoriteList; }
        }

        public bool DoesFavoriteExist(int id)
        {
            return _favoriteList.Any(favorite => favorite.FavoriteId == id);
        }

        public Favorite Find(int id)
        {
            return _favoriteList.FirstOrDefault(favorite => favorite.FavoriteId == id);
        }

        public void Insert(Favorite item)
        {
            _favoriteList.Add(item);
        }

        public void Delete(int FavoriteId)
        {
            _favoriteList.Remove(this.Find(FavoriteId));
        }

        private void InitializeData()
        {
            _favoriteList = new List<Favorite>();

            var favorite1 = new Favorite
            {
                FavoriteId = 1,
                VisitorId = 1,
                ShowId = 1,
                ArtistId = null
            };

            var favorite2 = new Favorite
            {
                FavoriteId = 2,
                VisitorId = 1,
                ShowId = null,
                ArtistId = 1

            };

            var favorite3 = new Favorite
            {
                FavoriteId = 3,
                VisitorId = 1,
                ShowId = 2,
                ArtistId = null
            };

            _favoriteList.Add(favorite1);
            _favoriteList.Add(favorite2);
            _favoriteList.Add(favorite3);
        }

        public IEnumerable<Favorite> GetFavoriteShows(int visitorId)
        {
            IEnumerable<Favorite> FiltredList = _favoriteList;
            FiltredList = FiltredList.Where(favorite => favorite.VisitorId.Equals(visitorId));
            FiltredList = FiltredList.Where(favorite => favorite.ArtistId.Equals(0));

            return FiltredList;
        }

        public IEnumerable<Favorite> GetFavoriteArtists(int visitorId)
        {
            IEnumerable<Favorite> FiltredList = _favoriteList;
            FiltredList = FiltredList.Where(favorite => favorite.VisitorId.Equals(visitorId));
            FiltredList = FiltredList.Where(favorite => favorite.ShowId.Equals(0));
            return FiltredList;
        }
    }
}