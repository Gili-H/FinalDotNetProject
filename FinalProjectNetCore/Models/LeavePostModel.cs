namespace FinalProjectNetCore.Models
{
    public class LeavePostModel
    {
        public int Id { get; set; }
        public int UserId { get; set; } //Foreign Key
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
