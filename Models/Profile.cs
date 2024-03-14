using System.ComponentModel.DataAnnotations;
namespace TutorAPI.Models
{
    public abstract class Profile
    {
        public int ProfileId { get; set; }
        [Required]
        public int UserId { get; set; }
        public UserType UserType { get; set; }
    }
}