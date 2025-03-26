using AutoMapper;
using FinalProject.Core.DTOs;
using FinalProject.Service.Interfaces;
using FinalProjectNetCore.Data.Entities;
using FinalProjectNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProjectNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly ILeaveRequestService _leaveRequestService;
        private readonly IMapper _mapper;
        private readonly ILogger<LeaveRequestController> _logger; // הוספת הלוגר

        public LeaveRequestController(ILeaveRequestService leaveRequestService, IMapper mapper, ILogger<LeaveRequestController> logger)
        {
            _leaveRequestService = leaveRequestService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Fetching all leave requests");
            var leaveRequests = await _leaveRequestService.GetAllAsync();
            var leaveRequestDtos = _mapper.Map<IEnumerable<LeaveRequestDto>>(leaveRequests);
            _logger.LogInformation("Successfully retrieved {count} leave requests", leaveRequestDtos?.Count());

            return Ok(leaveRequestDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            _logger.LogInformation("Fetching leave request with ID {id}", id);
            var leaveRequest = await _leaveRequestService.GetByIdAsync(id);
            if (leaveRequest == null)
            {
                _logger.LogWarning("Leave request with ID {id} not found", id);
                return NotFound();
            }

            var leaveRequestDto = _mapper.Map<LeaveRequestDto>(leaveRequest);
            _logger.LogInformation("Successfully retrieved leave request: {leaveRequest}", leaveRequestDto);

            return Ok(leaveRequestDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LeavePostModel value)
        {
            _logger.LogInformation("Creating new leave request for user {userId}, from {start} to {end}",
                value.UserId, value.StartDate, value.EndDate);

            var leaveToAdd = new LeaveRequest
            {
                Id = value.Id,
                UserId = value.UserId,
                StartDate = value.StartDate,
                EndDate = value.EndDate
            };

            var newLeave = await _leaveRequestService.AddAsync(leaveToAdd);
            _logger.LogInformation("Leave request created successfully with ID {id}", newLeave.Id);

            return Ok(newLeave);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] LeavePostModel value)
        {
            _logger.LogInformation("Updating leave request with ID {id}", id);
            var leaveToUpdate = new LeaveRequest
            {
                Id = value.Id,
                UserId = value.UserId,
                StartDate = value.StartDate,
                EndDate = value.EndDate
            };

            var updatedLeave = await _leaveRequestService.UpdateAsync(leaveToUpdate);

            if (updatedLeave == null)
            {
                _logger.LogWarning("Failed to update leave request with ID {id}", id);
                return NotFound();
            }

            _logger.LogInformation("Leave request with ID {id} updated successfully", id);
            return Ok(updatedLeave);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            _logger.LogInformation("Deleting leave request with ID {id}", id);
            await _leaveRequestService.DeleteAsync(id);
            _logger.LogInformation("Leave request with ID {id} deleted successfully", id);

            return Ok();
        }
    }
}
