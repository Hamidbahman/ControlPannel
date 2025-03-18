using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using controlpannel.application.Dtos.UserDto;
using controlpannel.application.Services;
using ControlPannel.Domain.Entities;

namespace controlpannel.api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get all users with sorting options
        /// </summary>
        [HttpPost("getAll")]
        public async Task<IActionResult> GetAllUsers([FromQuery] string sortBy = "FirstName", [FromQuery] bool descending = false)
        {
            Expression<Func<User, object>> sortExpression = sortBy.ToLower() switch
            {
                "firstname" => u => u.FirstName,
                "email" => u => u.Email,
                _ => throw new ArgumentException("Invalid sorting field. Allowed fields: FirstName, Email.")
            };

            var users = await _userService.GetAllUsersAsync(sortExpression, descending);
            return Ok(users);
        }

        /// <summary>
        /// Get user by email
        /// </summary>
        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            if (user == null) return NotFound("User not found.");
            return Ok(user);
        }

        /// <summary>
        /// Add a new user
        /// </summary>
        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequestDto dto)
        {
            if (dto == null) return BadRequest("User data is required.");
            await _userService.AddUserAsync(dto);
            return CreatedAtAction(nameof(GetUserByEmail), new { email = dto.Email }, dto);
        }

        /// <summary>
        /// Update an existing user
        /// </summary>
        [HttpPost("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequestDto dto)
        {
            if (dto == null) return BadRequest("User data is required.");
            await _userService.Update(dto);
            return NoContent();
        }
    }
}
