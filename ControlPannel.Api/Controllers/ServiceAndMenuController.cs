using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using controlpannel.application.Services;
using ControlPannel.Domain.Entities;

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
    public async Task<IActionResult> Process([FromBody] ProcessRequest request)
    {
        if (request == null || request.ApplicationId <= 0)
        {
            return BadRequest("Invalid Application ID.");
        }

        var menuSortExpression = GetMenuSortExpression(request.MenuSortBy);
        var serviceSortExpression = GetServiceSortExpression(request.ServiceSortBy);

        // Call the service
        var result = await _service.GetAllMenusByApplicationId(
            request.ApplicationId,
            menuSortExpression, request.MenuDescending,
            serviceSortExpression, request.ServiceDescending
        );

        return Ok(result);
    }

    private Expression<Func<Menu, object>> GetMenuSortExpression(string sortBy)
    {
        return sortBy?.ToLower() switch
        {
            "createdate" => m => m.CreateDate,
            _ => m => m.Id
        };
    }

    private Expression<Func<Service, object>> GetServiceSortExpression(string sortBy)
    {
        return sortBy?.ToLower() switch
        {
            "createdate" => s => s.CreateDate,
            "actee" => s => s.ActeeId,
            _ => s => s.Id
        };
    }
}
public class ProcessRequest
{
    public long ApplicationId { get; set; }
    public string MenuSortBy { get; set; } = "id";  // Default sorting
    public bool MenuDescending { get; set; } = false;
    public string ServiceSortBy { get; set; } = "id";  // Default sorting
    public bool ServiceDescending { get; set; } = false;
}