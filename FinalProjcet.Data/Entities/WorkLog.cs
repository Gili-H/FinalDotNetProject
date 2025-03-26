using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectNetCore.Data.Entities
{
    public class WorkLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }     //Foreign Key
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        public User User { get; set; }
    }
}
