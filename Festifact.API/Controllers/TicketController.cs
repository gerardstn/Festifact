using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public enum ErrorCode
        {
            TicketNameRequired,
            TicketIdInUse,
            RecordNotFound,
            CouldNotCreateTicket,
            CouldNotUpdateTicket,
            CouldNotDeleteTicket
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_ticketRepository.All);
        }



        [HttpPut]
        public IActionResult Edit([FromBody] Ticket ticket)
        {
            try
            {
                if (ticket == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TicketNameRequired.ToString());
                }
                var existingItem = _ticketRepository.Find(ticket.TicketId);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _ticketRepository.Update(ticket);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateTicket.ToString());
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _ticketRepository.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _ticketRepository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteTicket.ToString());
            }
            return NoContent();
        }
    }
}
