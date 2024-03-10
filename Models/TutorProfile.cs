namespace TutorAPI.Models
{
    public class TutorProfile : Profile
    {
        public string Description { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string Qualifications { get; set; } = string.Empty;
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public List<Session> Sessions { get; set; } = new List<Session>();
        public string Availability { get; set; } = string.Empty;
    }
}