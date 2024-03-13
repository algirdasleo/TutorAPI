using TutorAPI.Models;

namespace TutorApi.Interfaces
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetAllSubjectsAsync();
        Task<Subject?> GetSubjectByIdAsync(int id);
        Task<int> CreateSubjectAsync(Subject subject);
        Task<bool> UpdateSubjectAsync(Subject subject);
        Task<bool> DeleteSubjectAsync(int id);
    }
}