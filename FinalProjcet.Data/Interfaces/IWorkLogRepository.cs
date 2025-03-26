using FinalProjectNetCore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjcet.Data.Interfaces
{
    public interface IWorkLogRepository
    {

        Task<IEnumerable<WorkLog>> GetAllAsync();
        Task<WorkLog?> GetByIdAsync(int id);
        Task<WorkLog> AddAsync(WorkLog workLog);
        Task<WorkLog> UpdateAsync(WorkLog workLog);
        Task DeleteAsync(int id);
    }
}
