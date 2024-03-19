using System.ComponentModel.DataAnnotations;
namespace TutorAPI.Models
{
public class Profile
    {
        public int? ProfileId { get; set; }
        [Required]
        public int? UserId { get; set; }
        public string? Description { get; set; }
        public List<Subject>? Subjects { get; set; }
        public List<Session>? Sessions { get; set; }
        public string? Grade { get; set; }
        public double? Price { get; set; }
        public string? Qualifications { get; set; }
        public List<Availability>? Availabilities { get; set; }
    }
}