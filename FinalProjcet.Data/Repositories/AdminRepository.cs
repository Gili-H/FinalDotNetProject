using FinalProjcet.Data.Interfaces;
using FinalProjectNetCore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProjcet.Data.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DataContext _context;

        public AdminRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task<Admin?> GetByIdAsync(int id)
        {
            return await _context.Admins.FindAsync(id);
        }

        public async Task<Admin> AddAsync(Admin admin)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
            return admin;
        }

        public async Task<Admin> UpdateAsync(Admin admin)
        {
            var existing = await GetByIdAsync(admin.Id);
            if (existing == null)
            {
                throw new KeyNotFoundException("Admin not found");
            }

            existing.Name = admin.Name;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await GetByIdAsync(id);
            if (existing != null)
            {
                _context.Admins.Remove(existing);
                await _context.SaveChangesAsync();
            }
        }
    }
}
