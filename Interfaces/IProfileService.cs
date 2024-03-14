using TutorAPI.Models;

namespace TutorAPI.Interfaces
{
    public interface IProfileService
    {
        Task<List<Profile>> GetAllProfilesAsync();
        Task<Profile?> GetProfileByIdAsync(int profileId);
        Task<int> CreateProfileAsync(Profile profile);
        Task<bool> UpdateProfileAsync(Profile updatedProfile);
        Task<bool> DeleteProfileAsync(int profileId);
    }
}