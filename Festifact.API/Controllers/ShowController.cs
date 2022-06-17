using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShowController : ControllerBase
    {
        private readonly IShowRepository _showRepository;

        public ShowController(IShowRepository showRepository)
        {
            _showRepository = showRepository;
        }
        public enum ErrorCode
        {
            ShowNameRequired,
            ShowIdInUse,
            RecordNotFound,
            CouldNotCreateShow,
            CouldNotUpdateShow,
            CouldNotDeleteShow
        }

        [HttpPost]
        public IActionResult Create([FromBody] Show show)
        {
            try
            {
                if (show == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.ShowNameRequired.ToString());
                }
                bool itemExists = _showRepository.DoesShowExist(show.ShowId);
                if (itemExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, ErrorCode.ShowIdInUse.ToString());
                }
                _showRepository.Insert(show);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateShow.ToString());
            }
            return Ok(show);
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_showRepository.All);
        }

        [HttpGet("festival/"+"{id}" )]
        public IActionResult FestivalShows(int id)
        {
            return Ok(_showRepository.GetFestivalShows(id));
        }


        [HttpGet("artist/" + "{id}")]
        public IActionResult ArtistShows(int id)
        {
            return Ok(_showRepository.GetArtistShows(id));
        }




        [HttpPut]
        public IActionResult Edit([FromBody] Show show)
        {
            try
            {
                if (show == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.ShowNameRequired.ToString());
                }
                var existingItem = _showRepository.Find(show.ShowId);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _showRepository.Update(show);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateShow.ToString());
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _showRepository.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _showRepository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteShow.ToString());
            }
            return NoContent();
        }
    }
}
