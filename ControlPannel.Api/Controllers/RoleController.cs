using controlpannel.application.Dtos.RoleDtos;
using controlpannel.application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace controlpannel.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManagement _roleManagement;

        public RoleController(RoleManagement roleManagement)
        {
            _roleManagement = roleManagement;
        }

        [HttpPost("getAllRolesByApplicationId")]
        public async Task<IActionResult> GetAllByApplicationId([FromBody] RoleSortingDto sortingRequest)
        {
            var roles = await _roleManagement.GetAllByApplicationIdAsync(
                sortingRequest.ApplicationId,
                sortingRequest.SortByField,
                sortingRequest.Descending
            );
            return Ok(roles);
        }

        [HttpPost("getById/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var role = await _roleManagement.GetByIdAsync(id);
            if (role == null)
                return NotFound($"Role with ID {id} not found.");
            return Ok(role);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] AddRoleRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _roleManagement.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.ApplicationId }, dto);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateRoleRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _roleManagement.UpdateAsync(dto);
            return NoContent(); 
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _roleManagement.DeleteAsync(id);
            if (!result)
                return NotFound($"Role with ID {id} not found.");

            return NoContent();
        }
    }
}
