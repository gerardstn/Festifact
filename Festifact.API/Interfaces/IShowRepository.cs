using System.Collections.Generic;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Interfaces
{
    public interface IShowRepository
    {
        bool DoesShowExist(int id);
        IEnumerable<Show> All { get; }
        Show Find(int showId);
        void Insert(Show show);
        void Update(Show show);
        void Delete(int showId);
        IEnumerable<Show> GetFestivalShows(int festivalId);

    }
}