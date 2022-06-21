using Festifact.API.Interfaces;
using Festifact.API.Models;
using Festifact.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteController(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }
        public enum ErrorCode
        {
            FavoriteNameRequired,
            FavoriteIdInUse,
            RecordNotFound,
            CouldNotCreateFavorite,
            CouldNotUpdateFavorite,
            CouldNotDeleteFavorite
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_favoriteRepository.All);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Favorite favorite)
        {
            try
            {
                bool itemExists = _favoriteRepository.DoesFavoriteExist(favorite.FavoriteId);
                if (itemExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, ErrorCode.FavoriteIdInUse.ToString());
}
                _favoriteRepository.Insert(favorite);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateFavorite.ToString());
            }
            return Ok(favorite);
        }

        [HttpGet("show" + "{id}")]
        public IActionResult FavoriteShow()
        {
            return Ok(_favoriteRepository.favoriteShows());
        }

        [HttpGet("Artist" + "{id}")]
        public IActionResult FavoriteArtist()
        {
            return Ok(_favoriteRepository.favoriteArtists());
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _favoriteRepository.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _favoriteRepository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteFavorite.ToString());
            }
            return NoContent();
        }
    }
}
