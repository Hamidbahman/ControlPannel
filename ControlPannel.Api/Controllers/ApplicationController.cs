using System.Threading.Tasks;
using controlpannel.application.Dtos;
using controlpannel.application.Services;
using controlpannel.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace controlpannel.api.Controllers
{
    [ApiController]
    [Route("api/application")]
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationService _applicationService;

        public ApplicationController(ApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] AddApplicationRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var application = await _applicationService.CreateApplicationAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = application.Id }, application);
        }

        [HttpPost("getById")]
        public async Task<IActionResult> GetById([FromBody] long id)
        {
            var application = await _applicationService.GetApplicationByIdAsync(id);
            if (application == null)
                return NotFound($"Application with ID {id} not found.");
            return Ok(application);
        }
        
        [HttpPost("getByTitle")]
        public async Task<IActionResult> GetByTitle([FromBody] string title)
        {
            var application = await _applicationService.GetApplicationByTitle(title);
            if (application == null)
                return NotFound($"Application with Title {title} not found.");
            return Ok(application);
        }

[HttpPost("getAll")]
public async Task<IActionResult> GetAll([FromBody] AplicationSortingRequestDto sortingRequest)
{
    var applications = await _applicationService.GetAllApplicationsAsync(sortingRequest);
    return Ok(applications);
}


        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateApplicationRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _applicationService.UpdateApplicationAsync(dto);
            if (!updated)
                return NotFound($"Application with ID {dto.Id} not found.");

            return NoContent();
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] long id)
        {
            var deleted = await _applicationService.DeleteApplicationAsync(id);
            if (!deleted)
                return NotFound($"Application with ID {id} not found.");

            return Ok(new { message = "Application deleted successfully" });
        }
    }
}
