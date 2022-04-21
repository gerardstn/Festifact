using System.Collections.Generic;
using Festifact.API.Models;

namespace Festifact.API.Interfaces
{
    public interface IFestifactRepository
    {
        bool DoesFestivalExist(int id);
        IEnumerable<Festival> All { get; }
        Festival Find(int festivalId);
        void Insert(Festival festival);
        void Update(Festival festival);
        void Delete(int festivalId);

    }
}
