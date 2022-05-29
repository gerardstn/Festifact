using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        public enum ErrorCode
        {
            ImageNameRequired,
            ImageIdInUse,
            RecordNotFound,
            CouldNotCreateImage,
            CouldNotUpdateImage,
            CouldNotDeleteImage
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_imageRepository.All);
        }



        [HttpPut]
        public IActionResult Edit([FromBody] Image image)
        {
            try
            {
                if (image == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.ImageNameRequired.ToString());
                }
                var existingItem = _imageRepository.Find(image.ImageId);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _imageRepository.Update(image);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateImage.ToString());
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _imageRepository.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _imageRepository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteImage.ToString());
            }
            return NoContent();
        }
    }
}
