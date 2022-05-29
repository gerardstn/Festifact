using System.Collections.Generic;
using System.Linq;
using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Services
{
    public class RatingRepository : IRatingRepository
    {
        private List<Rating> _ratingList;

        public RatingRepository()
        {
            InitializeData();
        }

        public IEnumerable<Rating> All
        {
            get { return _ratingList; }
        }

        public bool DoesRatingExist(int id)
        {
            return _ratingList.Any(rating => rating.RatingId == id);
        }

        public Rating Find(int id)
        {
            return _ratingList.FirstOrDefault(rating => rating.RatingId == id);
        }

        public void Insert(Rating item)
        {
            _ratingList.Add(item);
        }

        public void Update(Rating rating)
        {
            var selectedRating = this.Find(rating.RatingId);
            var index = _ratingList.IndexOf(selectedRating);
            _ratingList.RemoveAt(index);
            _ratingList.Insert(index, rating);
        }

        public void Delete(int RatingId)
        {
            _ratingList.Remove(this.Find(RatingId));
        }

        private void InitializeData()
        {
            _ratingList = new List<Rating>();

            var rating1 = new Rating
            {
                RatingId = 1,
                Message = "awesome show",
                Stars = 5,
                ShowId = 1,
                VisitorId = 1,
            };

            var rating2 = new Rating
            {
                RatingId = 2,
                Message = null,
                Stars = 4,
                ShowId = 1,
                VisitorId = 2,
            };

            var rating3 = new Rating
            {
                RatingId = 3,
                Message = "Sick atmosphere!",
                Stars = 5,
                ShowId = 3,
                VisitorId = 2,
            };

            var rating4 = new Rating
            {
                RatingId = 3,
                Message = "Dirty facilities",
                Stars = 2,
                ShowId = 3,
                VisitorId = 3,
            };

            _ratingList.Add(rating1);
            _ratingList.Add(rating2);
            _ratingList.Add(rating3);
            _ratingList.Add(rating4);

        }

    }
}