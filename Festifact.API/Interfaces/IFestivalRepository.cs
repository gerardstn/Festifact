using System.Collections.Generic;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Interfaces
{
    public interface IFestivalRepository
    {
        bool DoesFestivalExist(int id);
        IEnumerable<Festival> All { get; }
        Festival Find(int festivalId);
        void Insert(Festival festival);
        void Update(Festival festival);
        void Delete(int festivalId);
        
        IEnumerable<Festival> SearchFunction( string type, string genre, string age, string location, DateTime date);

    }
}