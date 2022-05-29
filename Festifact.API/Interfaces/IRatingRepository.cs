using System.Collections.Generic;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Interfaces
{
    public interface IRatingRepository
    {
        bool DoesRatingExist(int id);
        IEnumerable<Rating> All { get; }
        Rating Find(int ratingId);
        void Insert(Rating rating);
        void Update(Rating rating);
        void Delete(int ratingId);
        
    }
}