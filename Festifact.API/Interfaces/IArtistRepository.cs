using System.Collections.Generic;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Interfaces
{
    public interface IArtistRepository
    {
        bool DoesArtistExist(int id);
        IEnumerable<Artist> All { get; }
        Artist Find(int aristId);
        void Insert(Artist arist);
        void Update(Artist arist);
        void Delete(int aristId);
        
    }
}