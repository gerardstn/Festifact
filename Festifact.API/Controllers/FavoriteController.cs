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


        [HttpPut]
        public IActionResult Edit([FromBody] Favorite favorite)
        {
            try
            {
                if (favorite == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.FavoriteNameRequired.ToString());
                }
                var existingItem = _favoriteRepository.Find(favorite.FavoriteId);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _favoriteRepository.Update(favorite);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateFavorite.ToString());
            }
            return NoContent();
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
