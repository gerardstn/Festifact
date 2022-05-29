using System.Collections.Generic;
using System.Linq;
using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Services
{
    public class MovieRepository : IMovieRepository
    {
        private List<Movie> _movieList;

        public MovieRepository()
        {
            InitializeData();
        }

        public IEnumerable<Movie> All
        {
            get { return _movieList; }
        }

        public bool DoesMovieExist(int id)
        {
            return _movieList.Any(movie => movie.MovieId == id);
        }

        public Movie Find(int id)
        {
            return _movieList.FirstOrDefault(movie => movie.MovieId == id);
        }

        public void Insert(Movie item)
        {
            _movieList.Add(item);
        }

        public void Update(Movie movie)
        {
            var selectedMovie = this.Find(movie.MovieId);
            var index = _movieList.IndexOf(selectedMovie);
            _movieList.RemoveAt(index);
            _movieList.Insert(index, movie);
        }

        public void Delete(int MovieId)
        {
            _movieList.Remove(this.Find(MovieId));
        }

        private void InitializeData()
        {
            _movieList = new List<Movie>();

            var movie1 = new Movie
            {
                MovieId = 1,
                Name = "Men",
                Actors = "Jessie Buckley, Rory Kinnear, Paapa Essiedu",
                Description = "A young woman goes on a solo vacation to the English countryside following the death of her ex-husband.",
                Director = "Alex Garland",
                ReleaseYear = new DateOnly(2022, 05, 20),
                CountryOrigin = "United Kingdom"
            };

            var movie2 = new Movie
            {
                MovieId = 2,
                Name = "THERE IS NO EVIL",
                Actors = " Baran Rasoulof, Masoud Tosifyan, Zhila Shahi",
                Description = "The four stories that are variations on the crucial themes of moral strength and the death penalty that ask to what extent individual freedom can be expressed under a despotic regime and its seemingly inescapable threats.",
                Director = "Mohammad Rasoulof",
                ReleaseYear = new DateOnly(2020, 06, 14),
                CountryOrigin = "Germany, Iran, Czech Republic"

            };


            _movieList.Add(movie1);
            _movieList.Add(movie2);
        }

    }
}