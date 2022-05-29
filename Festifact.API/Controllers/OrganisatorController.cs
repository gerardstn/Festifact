using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganisatorController : ControllerBase
    {
        private readonly IOrganisatorRepository _organisatorRepository;

        public OrganisatorController(IOrganisatorRepository organisatorRepository)
        {
            _organisatorRepository = organisatorRepository;
        }
        public enum ErrorCode
        {
            OrganisatorNameRequired,
            OrganisatorIdInUse,
            RecordNotFound,
            CouldNotCreateOrganisator,
            CouldNotUpdateOrganisator,
            CouldNotDeleteOrganisator
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_organisatorRepository.All);
        }



        [HttpPut]
        public IActionResult Edit([FromBody] Organisator organisator)
        {
            try
            {
                if (organisator == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.OrganisatorNameRequired.ToString());
                }
                var existingItem = _organisatorRepository.Find(organisator.OrganisatorId);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _organisatorRepository.Update(organisator);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateOrganisator.ToString());
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _organisatorRepository.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _organisatorRepository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteOrganisator.ToString());
            }
            return NoContent();
        }
    }
}
