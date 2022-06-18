using Festifact.API.Interfaces;
using Festifact.API.Models;
using Festifact.API.Services;
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
            LoginDetailsRequired,
            VisitorIdInUse,
            RecordNotFound,
            CouldNotFindVisitor,
            CouldNotCreateVisitor,
            CouldNotUpdateVisitor,
            CouldNotDeleteVisitor
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_visitorRepository.All);
        }


        [HttpGet("login")]
        public IActionResult CheckCredentials(string Email, string Password)
        {
            try
            {
                if (Email == null || Password == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.LoginDetailsRequired.ToString());
                }
                var existingItem = _visitorRepository.FindByEmail(Email);
                if (existingItem == false)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotFindVisitor.ToString());
            }
            return Ok(_visitorRepository.Login(Email, Password));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Visitor visitor)
        {
            try
            {
                if (visitor == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.VisitorNameRequired.ToString());
}
                bool itemExists = _visitorRepository.DoesVisitorExist(visitor.VisitorId);
                if (itemExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, ErrorCode.VisitorIdInUse.ToString());
}
                _visitorRepository.Insert(visitor);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateVisitor.ToString());
            }
            return Ok(visitor);
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
