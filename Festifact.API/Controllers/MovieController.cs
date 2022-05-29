using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public enum ErrorCode
        {
            MovieNameRequired,
            MovieIdInUse,
            RecordNotFound,
            CouldNotCreateMovie,
            CouldNotUpdateMovie,
            CouldNotDeleteMovie
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_movieRepository.All);
        }



        [HttpPut]
        public IActionResult Edit([FromBody] Movie movie)
        {
            try
            {
                if (movie == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.MovieNameRequired.ToString());
                }
                var existingItem = _movieRepository.Find(movie.MovieId);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _movieRepository.Update(movie);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateMovie.ToString());
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _movieRepository.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _movieRepository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteMovie.ToString());
            }
            return NoContent();
        }
    }
}
