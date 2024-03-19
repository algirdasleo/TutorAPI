using System.ComponentModel.DataAnnotations;

namespace TutorAPI.Models
{
    public class User
    {
        public int? UserId { get; set; }
        [Required]
        [StringLength(50), MinLength(3)]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        [StringLength(50), MinLength(3)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid Phone Number [Format: +1234567890)]")]
        public string? PhoneNumber { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        public UserType UserType { get; set; } // Enum: Student, Tutor, Admin
        public Profile? Profile { get; set; } = null!;
        // public bool isActive { get; set; }
    }
}