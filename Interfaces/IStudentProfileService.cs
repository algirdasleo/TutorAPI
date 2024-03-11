using TutorAPI.Models;
namespace TutorAPI.Interfaces
{
    public interface IStudentProfileService
    {
        Task<List<StudentProfile>> GetStudentProfilesAsync();
        Task<StudentProfile> GetStudentProfileByProfileId(int profileId);
        Task<StudentProfile> GetStudentProfileByUserId(int userId);
        Task<StudentProfile> AddStudentProfileAsync(StudentProfile studentProfile);
        Task<StudentProfile> UpdateStudentProfileAsync(StudentProfile studentProfile);
        Task DeleteStudentProfileAsync(int profileId);
    }
}