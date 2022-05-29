using System.Collections.Generic;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Interfaces
{
    public interface IMovieRepository
    {
        bool DoesMovieExist(int id);
        IEnumerable<Movie> All { get; }
        Movie Find(int movieId);
        void Insert(Movie movie);
        void Update(Movie movie);
        void Delete(int movieId);
        
    }
}