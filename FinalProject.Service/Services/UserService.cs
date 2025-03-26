using FinalProjcet.Data.Interfaces;
using FinalProjcet.Data.Repositories;
using FinalProject.Service.Interfaces;
using FinalProjectNetCore.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;

        public UserService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _repositoryManager.Users.GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _repositoryManager.Users.GetByIdAsync(id);
        }

        public async Task<User> AddAsync(User user)
        {
            var addedUser = await _repositoryManager.Users.AddAsync(user);
            await _repositoryManager.SaveAsync();
            return addedUser;
        }

        public async Task<User> UpdateAsync(User user)
        {
            var updatedUser = await _repositoryManager.Users.UpdateAsync(user);
            await _repositoryManager.SaveAsync();
            return updatedUser;
        }

        public async Task DeleteAsync(int id)
        {
            await _repositoryManager.Users.DeleteAsync(id);
            await _repositoryManager.SaveAsync();
        }
    }
}
