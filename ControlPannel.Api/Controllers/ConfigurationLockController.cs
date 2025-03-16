using controlpannel.application.Dtos;
using controlpannel.application.Dtos.ConfigurationLockDtos;
using controlpannel.application.Services;
using Microsoft.AspNetCore.Mvc;

namespace controlpannel.api.Controllers;

[ApiController]
[Route("api/configurationlock")]
public class ConfigurationLockController : ControllerBase
{
    private readonly ConfigurationLockService _configurationLockService;

    public ConfigurationLockController(ConfigurationLockService configurationLockService)
    {
        _configurationLockService = configurationLockService;
    }

    [HttpPost("getAllByApplication")]
    public async Task<IActionResult> GetAllByApplicationId([FromBody] ConfigurationLockSortingRequestDto sortingRequest)
    {
        var locks = await _configurationLockService.GetAllByApplicationIdAsync(
            sortingRequest.ApplicationId, 
            sortingRequest.SortByField, 
            sortingRequest.Descending
        );
        return Ok(locks);
    }

    [HttpPost("getById")]
    public async Task<IActionResult> GetById([FromBody] long id)
    {
        var lockConfig = await _configurationLockService.GetByIdAsync(id);
        if (lockConfig == null)
            return NotFound($"ConfigurationLock with ID {id} not found.");
        return Ok(lockConfig);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] AddConfigurationLockRequestDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _configurationLockService.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = dto.ApplicationId }, dto);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateConfigurationLockRequestDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _configurationLockService.UpdateAsync(dto);
        return NoContent();
    }

    [HttpPost("delete")]
    public async Task<IActionResult> Delete([FromBody] long id)
    {
        var deleted = await _configurationLockService.DeleteAsync(id);
        if (!deleted)
            return NotFound($"ConfigurationLock with ID {id} not found.");

        return Ok(new { message = "ConfigurationLock deleted successfully" });
    }
}
