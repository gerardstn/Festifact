using System.Collections.Generic;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Interfaces
{
    public interface ITicketRepository
    {
        bool DoesTicketExist(int id);
        IEnumerable<Ticket> All { get; }
        Ticket Find(int ticketId);
        void Insert(Ticket ticket);
        void Update(Ticket ticket);
        void Delete(int ticketId);
        IEnumerable<Ticket> GetVisitorTickets(int visitorId);


    }
}