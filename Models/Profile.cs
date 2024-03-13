using System.ComponentModel.DataAnnotations;
namespace TutorAPI.Models
{
    public abstract class Profile
    {
        public int ProfileId { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; } = null!; // User nebus null
        public UserType UserType { get; set; }
    }
}