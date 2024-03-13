namespace TutorAPI.Models
{
    public class StudentProfile : Profile
    {
        public string Grade { get; set; } = string.Empty;
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public List<Session> Sessions { get; set; } = new List<Session>();
    }
}