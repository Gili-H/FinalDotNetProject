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
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;
        private readonly ILogger<AdminController> _logger; // הוספת הלוגר

        public AdminController(IAdminService adminService, IMapper mapper, ILogger<AdminController> logger)
        {
            _adminService = adminService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Fetching all admins");
            var admins = await _adminService.GetAllAsync();
            var adminDtos = _mapper.Map<IEnumerable<AdminDto>>(admins);
            _logger.LogInformation("Successfully retrieved {count} admins", adminDtos?.Count());

            return Ok(adminDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            _logger.LogInformation("Fetching admin with ID {id}", id);
            var admin = await _adminService.GetByIdAsync(id);
            if (admin == null)
            {
                _logger.LogWarning("Admin with ID {id} not found", id);
                return NotFound();
            }

            var adminDto = _mapper.Map<AdminDto>(admin);
            _logger.LogInformation("Successfully retrieved admin: {admin}", adminDto);

            return Ok(adminDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AdminPostModel value)
        {
            _logger.LogInformation("Creating new admin: {name}", value.Name);
            var adminToAdd = new Admin { Name = value.Name, Id = value.Id };
            var newAdmin = await _adminService.AddAsync(adminToAdd);
            _logger.LogInformation("Admin created successfully with ID {id}", newAdmin.Id);

            return Ok(newAdmin);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AdminPostModel value)
        {
            _logger.LogInformation("Updating admin with ID {id}", id);
            var adminToUpdate = new Admin { Name = value.Name, Id = value.Id };
            var updatedAdmin = await _adminService.UpdateAsync(adminToUpdate);

            if (updatedAdmin == null)
            {
                _logger.LogWarning("Failed to update admin with ID {id}", id);
                return NotFound();
            }

            _logger.LogInformation("Admin with ID {id} updated successfully", id);
            return Ok(updatedAdmin);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            _logger.LogInformation("Deleting admin with ID {id}", id);
            await _adminService.DeleteAsync(id);
            _logger.LogInformation("Admin with ID {id} deleted successfully", id);

            return Ok();
        }
    }
}
