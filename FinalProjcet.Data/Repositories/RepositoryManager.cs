using FinalProjcet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjcet.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {

        private readonly DataContext _context;
        public IUserRepository Users { get; }
        public IAdminRepository Admins { get; }
        public IWorkLogRepository WorkLogs { get; }
        public ILeaveRequestRepository Leaves { get; }


        public RepositoryManager(DataContext context, IUserRepository userRepository, IAdminRepository admins, IWorkLogRepository workLog, ILeaveRequestRepository leaves)
        {
            _context = context;
            Users = userRepository;
            Admins = admins;
            WorkLogs = workLog;
            Leaves = leaves;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
