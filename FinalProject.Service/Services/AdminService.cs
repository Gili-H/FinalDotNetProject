using FinalProjcet.Data.Interfaces;
using FinalProjcet.Data.Repositories;
using FinalProject.Service.Interfaces;
using FinalProjectNetCore.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.Service.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepositoryManager _repositoryManager;

        public AdminService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            return await _repositoryManager.Admins.GetAllAsync();
        }

        public async Task<Admin?> GetByIdAsync(int id)
        {
            return await _repositoryManager.Admins.GetByIdAsync(id);
        }

        public async Task<Admin> AddAsync(Admin admin)
        {
            var addedAdmin = await _repositoryManager.Admins.AddAsync(admin);
            await _repositoryManager.SaveAsync();
            return addedAdmin;
        }

        public async Task<Admin> UpdateAsync(Admin admin)
        {
            var updatedAdmin = await _repositoryManager.Admins.UpdateAsync(admin);
            await _repositoryManager.SaveAsync();
            return updatedAdmin;
        }

        public async Task DeleteAsync(int id)
        {
            await _repositoryManager.Admins.DeleteAsync(id);
            await _repositoryManager.SaveAsync();
        }
    }
}
