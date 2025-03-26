using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.DTOs
{
    public class LeaveRequestDto
    {
        public int Id { get; set; }
        public int UserId { get; set; } //Foreign Key
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
