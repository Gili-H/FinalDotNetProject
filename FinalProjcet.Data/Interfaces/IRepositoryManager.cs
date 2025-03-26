using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjcet.Data.Interfaces
{
    public interface IRepositoryManager
    {
        IUserRepository Users { get; }
        IAdminRepository Admins { get; }
        IWorkLogRepository WorkLogs { get; }
        ILeaveRequestRepository Leaves { get; }
        Task SaveAsync();
    }
}
