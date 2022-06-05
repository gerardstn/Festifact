using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistController(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }
        public enum ErrorCode
        {
            ArtistNameRequired,
            ArtistIdInUse,
            RecordNotFound,
            CouldNotCreateArtist,
            CouldNotUpdateArtist,
            CouldNotDeleteArtist
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_artistRepository.All);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Artist artist)
        {
            try
            {
                if (artist == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.ArtistNameRequired.ToString());
                }
                bool itemExists = _artistRepository.DoesArtistExist(artist.ArtistId);
                if (itemExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, ErrorCode.ArtistIdInUse.ToString());
                }
                _artistRepository.Insert(artist);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateArtist.ToString());
            }
            return Ok(artist);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Artist artist)
        {
            try
            {
                if (artist == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.ArtistNameRequired.ToString());
                }
                var existingItem = _artistRepository.Find(artist.ArtistId);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _artistRepository.Update(artist);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateArtist.ToString());
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _artistRepository.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _artistRepository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteArtist.ToString());
            }
            return NoContent();
        }
    }
}
