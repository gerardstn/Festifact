using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public enum ErrorCode
        {
            LocationNameRequired,
            LocationIdInUse,
            RecordNotFound,
            CouldNotCreateLocation,
            CouldNotUpdateLocation,
            CouldNotDeleteLocation
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_locationRepository.All);
        }



        [HttpPut]
        public IActionResult Edit([FromBody] Location location)
        {
            try
            {
                if (location == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.LocationNameRequired.ToString());
                }
                var existingItem = _locationRepository.Find(location.LocationId);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _locationRepository.Update(location);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateLocation.ToString());
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _locationRepository.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _locationRepository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteLocation.ToString());
            }
            return NoContent();
        }
    }
}
