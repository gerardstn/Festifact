using Festifact.API.Interfaces;
using Festifact.API.Models;
using Festifact.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FestivalController : ControllerBase
    {
        private readonly IFestivalRepository _festivalRepository;

        public FestivalController(IFestivalRepository festivalRepository)
        {
            _festivalRepository = festivalRepository;
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
            return Ok(_festivalRepository.All);
        }

        [HttpGet("organisation/"+ "{id}")]
        public IActionResult OrganisationFestivals(int id)
        {
            return Ok(_festivalRepository.GetOrganisationFestivals(id));
        }


        [HttpGet("search")]
        public IActionResult Search(string Type, string Genre, string Age, string Location, DateTime Date)
        {
            return Ok(_festivalRepository.SearchFunction(Type, Genre, Age, Location, Date));
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
                bool itemExists = _festivalRepository.DoesFestivalExist(festival.FestivalId);
                if (itemExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, ErrorCode.FestivalIdInUse.ToString());
                }
                _festivalRepository.Insert(festival);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateFestival.ToString());
            }
            return Ok(festival);
        }

        [HttpGet("{id}")]
        public IActionResult GetFestival(int id)
        {
            return Ok(_festivalRepository.Find(id));
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
                var existingItem = _festivalRepository.Find(festival.FestivalId);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _festivalRepository.Update(festival);
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
                var item = _festivalRepository.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _festivalRepository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteFestival.ToString());
            }
            return NoContent();
        }
    }
}
