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
        
        IEnumerable<Festival> SearchFunction(string name, string type, string genre);
        Task<OkObjectResult> FindByType(string type);
        Task<OkObjectResult> FindByGenre(string genre);
        Task<OkObjectResult> FindByAge(string age);
        Task<OkObjectResult> FindByLocation(string location);
        Task<OkObjectResult> FindByDate(DateTime newDate);

    }
}