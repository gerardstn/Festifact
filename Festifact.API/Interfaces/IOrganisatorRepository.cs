using System.Collections.Generic;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Interfaces
{
    public interface IOrganisatorRepository
    {
        bool DoesOrganisatorExist(int id);
        IEnumerable<Organisator> All { get; }
        Organisator Find(int organisatorId);
        void Insert(Organisator organisator);
        void Update(Organisator organisator);
        void Delete(int organisatorId);
        
    }
}