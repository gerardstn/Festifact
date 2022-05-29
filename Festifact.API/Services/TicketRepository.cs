using System.Collections.Generic;
using System.Linq;
using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Services
{
    public class TicketRepository : ITicketRepository
    {
        private List<Ticket> _ticketList;

        public TicketRepository()
        {
            InitializeData();
        }

        public IEnumerable<Ticket> All
        {
            get { return _ticketList; }
        }

        public bool DoesTicketExist(int id)
        {
            return _ticketList.Any(ticket => ticket.TicketId == id);
        }

        public Ticket Find(int id)
        {
            return _ticketList.FirstOrDefault(ticket => ticket.TicketId == id);
        }

        public void Insert(Ticket item)
        {
            _ticketList.Add(item);
        }

        public void Update(Ticket ticket)
        {
            var selectedTicket = this.Find(ticket.TicketId);
            var index = _ticketList.IndexOf(selectedTicket);
            _ticketList.RemoveAt(index);
            _ticketList.Insert(index, ticket);
        }

        public void Delete(int TicketId)
        {
            _ticketList.Remove(this.Find(TicketId));
        }

        private void InitializeData()
        {
            _ticketList = new List<Ticket>();

            var ticket1 = new Ticket
            {
                TicketId = 1,
                FestivalId = 3,
                VisitorId = 2,
                PurchaseDate = DateTime.Now,
                Price = 55
            };

            var ticket2 = new Ticket
            {
                TicketId = 2,
                FestivalId = 1,
                VisitorId = 3,
                PurchaseDate = DateTime.Now,
                Price = 22

            };

            var ticket3 = new Ticket
            {
                TicketId = 3,
                FestivalId = 2,
                VisitorId = 1,
                PurchaseDate = DateTime.Now,
                Price = 27.5
            };

            _ticketList.Add(ticket1);
            _ticketList.Add(ticket2);
            _ticketList.Add(ticket3);
        }

    }
}