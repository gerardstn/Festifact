using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomReservationController : ControllerBase
    {
        private readonly IRoomReservationRepository _roomReservationRepository;

        public RoomReservationController(IRoomReservationRepository roomReservationRepository)
        {
            _roomReservationRepository = roomReservationRepository;
        }
        public enum ErrorCode
        {
            RoomReservationNameRequired,
            RoomReservationIdInUse,
            RecordNotFound,
            CouldNotCreateRoomReservation,
            CouldNotUpdateRoomReservation,
            CouldNotDeleteRoomReservation
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_roomReservationRepository.All);
        }

        [HttpGet("room/" + "{id}")]
        public IActionResult FestivalRooms(int id)
        {
            return Ok(_roomReservationRepository.GetRoomReservations(id));
        }

        [HttpPut]
        public IActionResult Edit([FromBody] RoomReservation roomReservation)
        {
            try
            {
                if (roomReservation == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.RoomReservationNameRequired.ToString());
                }
                var existingItem = _roomReservationRepository.Find(roomReservation.RoomReservationId);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _roomReservationRepository.Update(roomReservation);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateRoomReservation.ToString());
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _roomReservationRepository.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _roomReservationRepository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteRoomReservation.ToString());
            }
            return NoContent();
        }
    }
}
