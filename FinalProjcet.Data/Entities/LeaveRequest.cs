using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectNetCore.Data.Entities
{
    public class LeaveRequest
    {

        public int Id { get; set; }
        public int UserId { get; set; } //Foreign Key
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [MaxLength(500)]
        public string Reason { get; set; }

        public User? User { get; set; } 
    }
}
