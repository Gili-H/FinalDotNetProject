using FinalProject.Core.DTOs;
using FinalProjectNetCore.Data.Entities;

namespace FinalProjectNetCore
{
    public class Mapping
    {
        public UserDto MapToUserDto(User user)
        {
            return new UserDto { Id = user.Id, Name = user.Name, Email = user.Email, Password = user.Password };
        }

        public AdminDto MapToAdminDto(Admin admin)
        {
            return new AdminDto { Id = admin.Id, Name = admin.Name };
        }

        public LeaveRequestDto MapToLeaveDto(LeaveRequest leaveRequest)
        {
            return new LeaveRequestDto { Id = leaveRequest.Id, UserId = leaveRequest.UserId, StartDate = leaveRequest.StartDate, EndDate = leaveRequest.EndDate };
        }

        public WorkLogDto MapToWorkLogDto(WorkLog workLog)
        {
            return new WorkLogDto { Id = workLog.Id, UserId = workLog.UserId, EndTime = workLog.EndTime, StartTime = workLog.EndTime };
        }


    }
}
