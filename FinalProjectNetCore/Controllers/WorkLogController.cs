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
    public class WorkLogController : ControllerBase
    {
        private readonly IWorkLogService _workLogService;
        private readonly IMapper _mapper;
        private readonly ILogger<WorkLogController> _logger; 

        public WorkLogController(IWorkLogService workLogService, IMapper mapper, ILogger<WorkLogController> logger)
        {
            _workLogService = workLogService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Fetching all work logs");
            var list = await _workLogService.GetAllAsync();
            var listDtos = _mapper.Map<IEnumerable<WorkLogDto>>(list);
            _logger.LogInformation("Successfully retrieved {count} work logs", listDtos?.Count());

            return Ok(listDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            _logger.LogInformation("Fetching work log with ID {id}", id);
            var workLog = await _workLogService.GetByIdAsync(id);
            if (workLog == null)
            {
                _logger.LogWarning("Work log with ID {id} not found", id);
                return NotFound();
            }

            var workLogDto = _mapper.Map<WorkLogDto>(workLog);
            _logger.LogInformation("Successfully retrieved work log: {workLog}", workLogDto);

            return Ok(workLogDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] WorkLogPostModel value)
        {
            _logger.LogInformation("Creating new work log for user ID {userId}", value.UserId);

            var workLogToAdd = new WorkLog
            {
                Id = value.Id,
                UserId = value.UserId,
                StartTime = value.StartTime,
                EndTime = value.EndTime
            };

            var workLog = await _workLogService.AddAsync(workLogToAdd);
            _logger.LogInformation("Work log created successfully with ID {id}", workLog.Id);

            return Ok(workLog);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] WorkLogPostModel value)
        {
            _logger.LogInformation("Updating work log with ID {id}", id);

            var workLogToUpdate = new WorkLog
            {
                Id = value.Id,
                UserId = value.UserId,
                StartTime = value.StartTime,
                EndTime = value.EndTime
            };

            var updatedWorkLog = await _workLogService.UpdateAsync(workLogToUpdate);
            if (updatedWorkLog == null)
            {
                _logger.LogWarning("Failed to update work log with ID {id}", id);
                return NotFound();
            }

            _logger.LogInformation("Work log with ID {id} updated successfully", id);
            return Ok(updatedWorkLog);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            _logger.LogInformation("Deleting work log with ID {id}", id);
            await _workLogService.DeleteAsync(id);
            _logger.LogInformation("Work log with ID {id} deleted successfully", id);

            return Ok();
        }
    }
}
