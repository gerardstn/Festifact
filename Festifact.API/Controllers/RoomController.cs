using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public enum ErrorCode
        {
            RoomNameRequired,
            RoomIdInUse,
            RecordNotFound,
            CouldNotCreateRoom,
            CouldNotUpdateRoom,
            CouldNotDeleteRoom
        }

        [HttpGet("location/" + "{id}")]
        public IActionResult LocationShows(int id)
        {
            return Ok(_roomRepository.GetLocationRooms(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Room room)
        {
            try
            {
                if (room == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.RoomNameRequired.ToString());
                }
                bool itemExists = _roomRepository.DoesRoomExist(room.RoomId);
                if (itemExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, ErrorCode.RoomIdInUse.ToString());
                }
                _roomRepository.Insert(room);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateRoom.ToString());
            }
            return Ok(room);
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_roomRepository.All);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Room room)
        {
            try
            {
                if (room == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.RoomNameRequired.ToString());
                }
                var existingItem = _roomRepository.Find(room.RoomId);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _roomRepository.Update(room);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateRoom.ToString());
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _roomRepository.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _roomRepository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteRoom.ToString());
            }
            return NoContent();
        }
    }
}
