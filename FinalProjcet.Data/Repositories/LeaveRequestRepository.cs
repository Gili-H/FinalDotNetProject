using FinalProjcet.Data.Interfaces;
using FinalProjectNetCore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProjcet.Data.Repositories
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly DataContext _context;

        public LeaveRequestRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LeaveRequest>> GetAllAsync()
        {
            return await _context.LeaveRequests.ToListAsync();
        }

        public async Task<LeaveRequest?> GetByIdAsync(int id)
        {
            return await _context.LeaveRequests.FindAsync(id);
        }

        public async Task<LeaveRequest> AddAsync(LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Add(leaveRequest);
            await _context.SaveChangesAsync();
            return leaveRequest;
        }

        public async Task<LeaveRequest> UpdateAsync(LeaveRequest leaveRequest)
        {
            var existing = await GetByIdAsync(leaveRequest.Id);
            if (existing == null)
            {
                throw new KeyNotFoundException("Leave request not found");
            }

            existing.StartDate = leaveRequest.StartDate;
            existing.EndDate = leaveRequest.EndDate;
            existing.UserId = leaveRequest.UserId;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await GetByIdAsync(id);
            if (existing != null)
            {
                _context.LeaveRequests.Remove(existing);
                await _context.SaveChangesAsync();
            }
        }
    }
}
