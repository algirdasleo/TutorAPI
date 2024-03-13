namespace TutorAPI.Models
{
    public class Availability
    {
        public int AvailabilityId { get; set; }
        public int TutorProfileId { get; set; }
        public TutorProfile TutorProfile { get; set; }  = null!;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Status { get; set; } = "Available"; // Available, Booked
    }
}