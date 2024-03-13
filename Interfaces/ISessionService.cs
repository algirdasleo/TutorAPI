using TutorAPI.Models;
namespace TutorAPI
{
    public interface ISessionService
    {
        Task<Session?> GetSessionByIdAsync(int sessionId);
        Task<List<Session>> GetSessionsByTutorProfileIdAsync(int tutorProfileId);
        Task<List<Session>> GetSessionsByStudentProfileIdAsync(int studentProfileId);
        Task<int> AddSessionAsync(Session session);
        Task<bool> UpdateSessionAsync(Session session);
        Task<bool> DeleteSessionAsync(int sessionId);
        Task<bool> UpdateSessionStatusAsync(int sessionId, string status);
    }
}