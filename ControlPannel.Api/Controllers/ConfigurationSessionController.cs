using controlpannel.application.Dtos;
using controlpannel.application.Dtos.ConfigurationSessionDtos;
using controlpannel.application.Services;
using Microsoft.AspNetCore.Mvc;

namespace controlpannel.api.Controllers;

[ApiController]
[Route("api/configurationsession")]
public class ConfigurationSessionController : ControllerBase
{
    private readonly ConfigurationSessionService _configurationSessionService;

    public ConfigurationSessionController(ConfigurationSessionService configurationSessionService)
    {
        _configurationSessionService = configurationSessionService;
    }

    [HttpPost("getAllByApplication")]
    public async Task<IActionResult> GetAllByApplicationId([FromBody] ConfigurationSessionSortingRequestDto sortingRequest)
    {
        var sessions = await _configurationSessionService.GetAllByApplicationIdAsync(sortingRequest.ApplicationId, sortingRequest.SortByField, sortingRequest.Descending);
        return Ok(sessions);
    }

    [HttpPost("getById")]
    public async Task<IActionResult> GetById([FromBody] long id)
    {
        var session = await _configurationSessionService.GetByIdAsync(id);
        if (session == null)
            return NotFound($"ConfigurationSession with ID {id} not found.");
        return Ok(session);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] AddConfigurationSessionRequestDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _configurationSessionService.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = dto.ApplicationId }, dto);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateConfigurationSessionRequestDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _configurationSessionService.UpdateAsync(dto);
        return NoContent();
    }

    [HttpPost("delete")]
    public async Task<IActionResult> Delete([FromBody] long id)
    {
        var deleted = await _configurationSessionService.DeleteAsync(id);
        if (!deleted)
            return NotFound($"ConfigurationSession with ID {id} not found.");

        return Ok(new { message = "ConfigurationSession deleted successfully" });
    }
}
