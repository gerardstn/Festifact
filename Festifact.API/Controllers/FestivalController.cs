using Festifact.API.Infrastructure;
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


        [Route("api/[controller]/search")]
        [HttpGet]
        public async Task<IActionResult> SearchListResult(String Type, String Genre, String Age, String Location, String Date)
        {
            var searchListResult = Ok(_festifactRepository.All);

            //methode maken die checkt of een string leeg is, en vervolgens voor bepaalde lege samen iets uitvoert en uitpoept
           

            if (!String.IsNullOrEmpty(Type))
            {
                searchListResult = await _festifactRepository.FindByType(Type);
            }
            if (!String.IsNullOrEmpty(Genre))
            {
                searchListResult = await _festifactRepository.FindByGenre(Genre);
            }
            if (!String.IsNullOrEmpty(Age))
            {
                searchListResult = await _festifactRepository.FindByAge(Age);
            }
            if (!String.IsNullOrEmpty(Location))
            {
                searchListResult = await _festifactRepository.FindByLocation(Location);
            }
            if (!String.IsNullOrEmpty(Date))
            {
                DateTime newDate = DateHelper.StringToDateTime(Date);
                searchListResult = await _festifactRepository.FindByDate(newDate);
            }

            if (!String.IsNullOrEmpty(Date) && !String.IsNullOrEmpty(Location))
            {
                DateTime newDate = DateHelper.StringToDateTime(Date);
                searchListResult = await _festifactRepository.FindByDate(newDate);
            }

            if (searchListResult == null)
            {
                return NotFound();
            }

            return Ok(searchListResult);
        }

        [Route("api/[controller]/search/v2")]
        [HttpGet]
        public IActionResult SearchTemp(string Name, string Type, string Genre)
        {

            return Ok(_festifactRepository.SearchFunction(Name, Type, Genre));
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
