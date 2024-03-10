namespace TutorAPI.Models
{
    public class Session
    {
        public int SessionId { get; set; }
        public int TutorProfileId { get; set; }
        public TutorProfile TutorProfile { get; set; } = null!;     
        public int StudentProfileId { get; set; }
        public StudentProfile StudentProfile { get; set; } = null!; 
        public string Date { get; set; } = string.Empty;            // yyyy-mm-dd
        public string Time { get; set; } = string.Empty;            // 24 hour format
        public string Duration { get; set; } = string.Empty;        // 30, 60, 90, 120 mins
        public string Location { get; set; } = string.Empty;        // Online, In-Person
        public string Status { get; set; } = string.Empty;          // Planned, Confirmed, Completed, Cancelled
    }
}