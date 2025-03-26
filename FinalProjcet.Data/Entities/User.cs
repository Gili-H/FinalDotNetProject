using System.ComponentModel.DataAnnotations;

namespace FinalProjectNetCore.Data.Entities
{
    public class User
    {
 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //קשרים
        public List<WorkLog> WorkLogs { get; set; }
        public List<LeaveRequest> LeaveRequests { get; set; }
        public int AdminId {  get; set; } //Foreign Key
        public Admin? Admin {  get; set; }


    }
}
