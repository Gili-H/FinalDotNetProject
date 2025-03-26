using AutoMapper;
using FinalProject.Core.DTOs;
using FinalProject.Service.Interfaces;
using FinalProjectNetCore.Data.Entities;
using FinalProjectNetCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProjectNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger; // הוספת הלוגר

        public UserController(IUserService userService, IMapper mapper, ILogger<UserController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Fetching all users");
            var users = await _userService.GetAllAsync();
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            _logger.LogInformation("Successfully retrieved {count} users", userDtos?.Count());

            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            _logger.LogInformation("Fetching user with ID {id}", id);
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                _logger.LogWarning("User with ID {id} not found", id);
                return NotFound();
            }

            var userDto = _mapper.Map<UserDto>(user);
            _logger.LogInformation("Successfully retrieved user: {user}", userDto);

            return Ok(userDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserPostModel value)
        {
            _logger.LogInformation("Creating new user with email {email}", value.Email);

            var userToAdd = new User
            {
                Id = value.Id,
                Name = value.Name,
                Email = value.Email,
                Password = value.Password
            };

            var user = await _userService.AddAsync(userToAdd);
            _logger.LogInformation("User created successfully with ID {id}", user.Id);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserPostModel value)
        {
            _logger.LogInformation("Updating user with ID {id}", id);
            var userToUpdate = new User
            {
                Id = value.Id,
                Name = value.Name,
                Email = value.Email,
                Password = value.Password
            };

            var updatedUser = await _userService.UpdateAsync(userToUpdate);
            if (updatedUser == null)
            {
                _logger.LogWarning("Failed to update user with ID {id}", id);
                return NotFound();
            }

            _logger.LogInformation("User with ID {id} updated successfully", id);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            _logger.LogInformation("Deleting user with ID {id}", id);
            await _userService.DeleteAsync(id);
            _logger.LogInformation("User with ID {id} deleted successfully", id);

            return Ok();
        }
    }
}
