using controlpannel.application.Dtos;
using controlpannel.application.Dtos.ConfigurationPassword;
using controlpannel.application.Services;
using Microsoft.AspNetCore.Mvc;

namespace controlpannel.api.Controllers;

[ApiController]
[Route("api/configurationpassword")]
public class ConfigurationPasswordController : ControllerBase
{
    private readonly ConfigurationPasswordService _configurationPasswordService;

    public ConfigurationPasswordController(ConfigurationPasswordService configurationPasswordService)
    {
        _configurationPasswordService = configurationPasswordService;
    }

    [HttpPost("getAllByApplication")]
    public async Task<IActionResult> GetAllByApplicationId([FromBody] ConfigurationPasswordSortingRequestDto sortingRequest)
    {
        var passwords = await _configurationPasswordService.GetAllByApplicationIdAsync(
            sortingRequest.ApplicationId, 
            sortingRequest.SortByField, 
            sortingRequest.Descending
        );
        return Ok(passwords);
    }

    [HttpPost("getById")]
    public async Task<IActionResult> GetById([FromBody] long id)
    {
        var passwordConfig = await _configurationPasswordService.GetByIdAsync(id);
        if (passwordConfig == null)
            return NotFound($"ConfigurationPassword with ID {id} not found.");
        return Ok(passwordConfig);
    }


    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] AddConfigurationPasswordRequestDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _configurationPasswordService.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = dto.ApplicationId }, dto);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateConfigurationPasswordRequestDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _configurationPasswordService.UpdateAsync(dto);
        return NoContent();
    }

    [HttpPost("delete")]
    public async Task<IActionResult> Delete([FromBody] long id)
    {
        var deleted = await _configurationPasswordService.DeleteAsync(id);
        if (!deleted)
            return NotFound($"ConfigurationPassword with ID {id} not found.");

        return Ok(new { message = "ConfigurationPassword deleted successfully" });
    }
}
