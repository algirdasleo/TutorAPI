namespace TutorAPI.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int TutorId { get; set; }
        public int StudentId { get; set; }
    }
}