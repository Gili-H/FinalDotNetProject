using FinalProjcet.Data.Interfaces;
using FinalProjcet.Data.Repositories;
using FinalProject.Service.Interfaces;
using FinalProjectNetCore.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.Service.Services
{
    public class WorkLogService : IWorkLogService
    {
        private readonly IRepositoryManager _repositoryManager;

        public WorkLogService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<WorkLog>> GetAllAsync()
        {
            return await _repositoryManager.WorkLogs.GetAllAsync();
        }

        public async Task<WorkLog?> GetByIdAsync(int id)
        {
            return await _repositoryManager.WorkLogs.GetByIdAsync(id);
        }

        public async Task<WorkLog> AddAsync(WorkLog workLog)
        {
            var addedWorkLog = await _repositoryManager.WorkLogs.AddAsync(workLog);
            await _repositoryManager.SaveAsync();
            return addedWorkLog;
        }

        public async Task<WorkLog> UpdateAsync(WorkLog workLog)
        {
            var updatedWorkLog = await _repositoryManager.WorkLogs.UpdateAsync(workLog);
            await _repositoryManager.SaveAsync();
            return updatedWorkLog;
        }

        public async Task DeleteAsync(int id)
        {
            await _repositoryManager.WorkLogs.DeleteAsync(id);
            await _repositoryManager.SaveAsync();
        }
    }
}
