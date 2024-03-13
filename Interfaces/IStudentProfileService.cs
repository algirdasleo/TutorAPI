using TutorAPI.Models;
namespace TutorAPI.Interfaces
{
    public interface IStudentProfileService
    {
        Task<List<StudentProfile>> GetStudentProfilesAsync();
        Task<StudentProfile> GetStudentProfileByProfileId(int profileId);
        Task<StudentProfile> GetStudentProfileByUserId(int userId);
        Task<int> AddStudentProfileAsync(StudentProfile studentProfile);
        Task<bool> UpdateStudentProfileAsync(StudentProfile studentProfile);
        Task<bool> DeleteStudentProfileAsync(int profileId);
    }
}