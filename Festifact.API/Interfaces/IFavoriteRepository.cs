using System.Collections.Generic;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Interfaces
{
    public interface IFavoriteRepository
    {
        bool DoesFavoriteExist(int id);
        IEnumerable<Favorite> All { get; }
        Favorite Find(int favoriteId);
        void Insert(Favorite favorite);
        void Delete(int favoriteId);
        IEnumerable<Favorite> GetFavoriteShows(int id);
        IEnumerable<Favorite> GetFavoriteArtists(int id);

    }
}