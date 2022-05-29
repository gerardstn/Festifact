using System.Collections.Generic;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Interfaces
{
    public interface IVisitorRepository
    {
        bool DoesVisitorExist(int id);
        IEnumerable<Visitor> All { get; }
        Visitor Find(int visitorId);
        void Insert(Visitor visitor);
        void Update(Visitor visitor);
        void Delete(int visitorId);
        
    }
}