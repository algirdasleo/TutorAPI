using TutorAPI.Models;

namespace TutorAPI.Interfaces
{
    public interface IReviewService
    {
        Task<List<Review>> GetReviewsAsync();
        Task<Review?> GetReviewByReviewId(int reviewId);
        Task<List<Review>> GetReviewsByTutorId(int tutorId);
        Task<List<Review>> GetReviewsByStudentId(int studentId);
        Task<int> AddReviewAsync(Review review);
        Task<bool> UpdateReviewAsync(Review review);
        Task<bool> DeleteReviewAsync(int reviewId);
    }
}