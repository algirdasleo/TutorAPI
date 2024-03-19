namespace TutorAPI.Models
{
    public class Session
    {
        public int? SessionId { get; set; }
        public int? TutorProfileId { get; set; }
        public int? StudentProfileId { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }                           // 30, 60, 90, 120 mins
        public string? Location { get; set; } = string.Empty;        // Online, In-Person
        public string Status { get; set; } = string.Empty;          // Planned, Confirmed, Completed, Cancelled
        public Review? UserReview { get; set; }
    }
}