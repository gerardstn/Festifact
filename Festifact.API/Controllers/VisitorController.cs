using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitorController : ControllerBase
    {
        private readonly IVisitorRepository _visitorRepository;

        public VisitorController(IVisitorRepository visitorRepository)
        {
            _visitorRepository = visitorRepository;
        }
        public enum ErrorCode
        {
            VisitorNameRequired,
            VisitorIdInUse,
            RecordNotFound,
            CouldNotCreateVisitor,
            CouldNotUpdateVisitor,
            CouldNotDeleteVisitor
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_visitorRepository.All);
        }



        [HttpPut]
        public IActionResult Edit([FromBody] Visitor visitor)
        {
            try
            {
                if (visitor == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.VisitorNameRequired.ToString());
                }
                var existingItem = _visitorRepository.Find(visitor.VisitorId);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _visitorRepository.Update(visitor);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateVisitor.ToString());
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _visitorRepository.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _visitorRepository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteVisitor.ToString());
            }
            return NoContent();
        }
    }
}
