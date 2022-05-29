using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingController(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }
        public enum ErrorCode
        {
            RatingNameRequired,
            RatingIdInUse,
            RecordNotFound,
            CouldNotCreateRating,
            CouldNotUpdateRating,
            CouldNotDeleteRating
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_ratingRepository.All);
        }



        [HttpPut]
        public IActionResult Edit([FromBody] Rating rating)
        {
            try
            {
                if (rating == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.RatingNameRequired.ToString());
                }
                var existingItem = _ratingRepository.Find(rating.RatingId);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _ratingRepository.Update(rating);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateRating.ToString());
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _ratingRepository.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _ratingRepository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteRating.ToString());
            }
            return NoContent();
        }
    }
}
