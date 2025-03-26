using FinalProjcet.Data.Interfaces;
using FinalProjcet.Data.Repositories;
using FinalProject.Service.Interfaces;
using FinalProjectNetCore.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.Service.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly IRepositoryManager _repositoryManager;

        public LeaveRequestService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<LeaveRequest>> GetAllAsync()
        {
            return await _repositoryManager.Leaves.GetAllAsync();
        }

        public async Task<LeaveRequest?> GetByIdAsync(int id)
        {
            return await _repositoryManager.Leaves.GetByIdAsync(id);
        }

        public async Task<LeaveRequest> AddAsync(LeaveRequest leaveRequest)
        {
            var addedLeaveRequest = await _repositoryManager.Leaves.AddAsync(leaveRequest);
            await _repositoryManager.SaveAsync();
            return addedLeaveRequest;
        }

        public async Task<LeaveRequest> UpdateAsync(LeaveRequest leaveRequest)
        {
            var updatedLeaveRequest = await _repositoryManager.Leaves.UpdateAsync(leaveRequest);
            await _repositoryManager.SaveAsync();
            return updatedLeaveRequest;
        }

        public async Task DeleteAsync(int id)
        {
            await _repositoryManager.Leaves.DeleteAsync(id);
            await _repositoryManager.SaveAsync();
        }
    }
}
