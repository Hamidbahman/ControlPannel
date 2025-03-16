using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ControlPannel.Domain.Entities;

namespace controlpannel.application.Services;

[ApiController]
[Route("api/service-menu")]
public class ServiceAndMenuController : ControllerBase
{
    private readonly ServiceAndMenuService _service;

    public ServiceAndMenuController(ServiceAndMenuService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Process([FromBody] long applicationId)
    {
        var result = await _service.GetAllMenusByApplicationId(applicationId);
        return Ok(result);
    }
}
