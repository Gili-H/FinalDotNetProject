using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.DTOs
{
    public class WorkLogDto
    {
        public int Id { get; set; }
        public int UserId { get; set; } //Foreign Key
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
