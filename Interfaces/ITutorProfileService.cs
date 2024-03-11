using TutorAPI.Models;

namespace TutorAPI.Interfaces
{
    public interface ITutorProfileService
    {
        Task<List<TutorProfile>> GetTutorProfilesAsync();
        Task<TutorProfile> GetTutorProfileByProfileId(int profileId);
        Task<TutorProfile> GetTutorProfileByUserId(int userId);
        Task<TutorProfile> AddTutorProfileAsync(TutorProfile tutorProfile);
        Task<TutorProfile> UpdateTutorProfileAsync(TutorProfile tutorProfile);
        Task DeleteTutorProfileAsync(int profileId);
    }
}