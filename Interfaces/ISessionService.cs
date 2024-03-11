using TutorAPI.Models;
namespace TutorAPI
{
    public interface ISessionService
    {
        Task<Session> GetSessionByIdAsync(int sessionId);
        Task<List<Session>> GetSessionsByTutorProfileIdAsync(int tutorProfileId);
        Task<List<Session>> GetSessionsByStudentProfileIdAsync(int studentProfileId);
        Task<Session> AddSessionAsync(Session session);
        Task<Session> UpdateSessionAsync(Session session);
        Task DeleteSessionAsync(int sessionId);
        Task UpdateSessionStatusAsync(int sessionId, string status);
    }
}