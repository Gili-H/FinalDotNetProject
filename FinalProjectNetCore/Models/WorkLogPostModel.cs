namespace FinalProjectNetCore.Models
{
    public class WorkLogPostModel
    {


        public int Id { get; set; }
        public int UserId { get; set; } //Foreign Key
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
