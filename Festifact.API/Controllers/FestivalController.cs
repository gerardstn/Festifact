using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FestivalController : ControllerBase
    {
        private readonly IFestivalRepository _festifactRepository;

        public FestivalController(IFestivalRepository festifactRepository)
        {
            _festifactRepository = festifactRepository;
        }
        public enum ErrorCode
        {
            FestivalNameRequired,
            FestivalIdInUse,
            RecordNotFound,
            CouldNotCreateFestival,
            CouldNotUpdateFestival,
            CouldNotDeleteFestival
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_festifactRepository.All);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Festival festival)
        {
            try
            {
                if (festival == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.FestivalNameRequired.ToString());
                }
                bool itemExists = _festifactRepository.DoesFestivalExist(festival.FestivalId);
                if (itemExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, ErrorCode.FestivalIdInUse.ToString());
                }
                _festifactRepository.Insert(festival);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateFestival.ToString());
            }
            return Ok(festival);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Festival festival)
        {
            try
            {
                if (festival == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.FestivalNameRequired.ToString());
                }
                var existingItem = _festifactRepository.Find(festival.FestivalId);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _festifactRepository.Update(festival);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateFestival.ToString());
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _festifactRepository.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _festifactRepository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteFestival.ToString());
            }
            return NoContent();
        }
    }
}
