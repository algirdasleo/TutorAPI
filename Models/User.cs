namespace TutorAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public UserType UserType { get; set; } // Enum: Student, Tutor, Admin
        
        // public bool isActive { get; set; }
    }
}