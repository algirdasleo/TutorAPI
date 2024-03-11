using TutorAPI.Models;

namespace TutorAPI.Interfaces
{
    public interface IReviewService
    {
        Task<List<Review>> GetReviewsAsync();
        Task<Review> GetReviewByReviewId(int reviewId);
        Task<List<Review>> GetReviewsByTutorId(int tutorId);
        Task<List<Review>> GetReviewsByStudentId(int studentId);
        Task<Review> AddReviewAsync(Review review);
        Task<Review> UpdateReviewAsync(Review review);
        Task DeleteReviewAsync(int reviewId);
    }
}