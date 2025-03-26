using FinalProjcet.Data.Interfaces;
using FinalProjectNetCore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjcet.Data.Repositories
{
    public class WorkLogRepository : IWorkLogRepository
    {
        private readonly DataContext _context;

        public WorkLogRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WorkLog>> GetAllAsync()
        {
            return await _context.WorkLogs
                .Where(w => !string.IsNullOrEmpty(w.User.Name))
                .Include(w => w.User)
                .ToListAsync();
        }

        public async Task<WorkLog?> GetByIdAsync(int id)
        {
            return await _context.WorkLogs.FindAsync(id);
        }

        public async Task<WorkLog> AddAsync(WorkLog w)
        {
            _context.WorkLogs.Add(w);
            await _context.SaveChangesAsync();
            return w;
        }

        public async Task<WorkLog> UpdateAsync(WorkLog w)
        {
            var existing = await GetByIdAsync(w.Id);
            if (existing is null)
            {
                throw new Exception("WorkLog not found");
            }

            existing.StartTime = w.StartTime;
            existing.EndTime = w.EndTime;
            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await GetByIdAsync(id);
            if (existing is not null)
            {
                _context.WorkLogs.Remove(existing);
                await _context.SaveChangesAsync();
            }
        }
    }
}
