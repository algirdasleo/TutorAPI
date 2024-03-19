using TutorAPI.Interfaces;
using TutorAPI.Models;
using Dapper;

namespace TutorAPI.Service
{
    public class ReviewService : IReviewService
    {
        private readonly IDatabaseService _databaseService;
        private readonly ILogger<ReviewService> _logger;
        public ReviewService (IDatabaseService databaseService, ILogger<ReviewService> logger)
        {
            _databaseService = databaseService;
            _logger = logger;
        }
        public async Task<List<Review>> GetReviewsAsync()
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                var reviews = await connection.QueryAsync<Review>("SELECT * FROM Reviews"); // QueryAsync<T> gražina IEnumerable<T>
                return reviews.ToList();
            }
        }
        public async Task<Review?> GetReviewByReviewId(int reviewId)
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = "SELECT * FROM Reviews WHERE ReviewId = @ReviewId";
                var review = await connection.QueryFirstOrDefaultAsync<Review>(sqlQuery, new {ReviewId = reviewId});
                if (review == null)
                    _logger.LogWarning($"Review with id {reviewId} not found");
                return review;
            }
        }
        public async Task<List<Review>> GetReviewsByTutorId(int tutorId)
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = "SELECT * FROM Reviews WHERE TutorId = @TutorId";
                var reviews = await connection.QueryAsync<Review>(sqlQuery, new {TutorId = tutorId});
                if (!reviews.Any())
                    _logger.LogWarning($"Reviews for tutorId {tutorId} not found");
                return reviews.ToList();
            }
        }
        public async Task<List<Review>> GetReviewsByStudentId(int studentId)
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = "SELECT * FROM Reviews WHERE StudentId = @StudentId";
                var reviews = await connection.QueryAsync<Review>(sqlQuery, new {StudentId = studentId});
                return reviews.ToList();
            }
        }

        public async Task<int> AddReviewAsync(Review review)
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = @"
                    INSERT INTO Reviews (Rating, Comment, TutorId, StudentId, CreatedAt)
                    VALUES (@Rating, @Comment, @TutorId, @StudentId, @CreatedAt);
                    SELECT last_insert_rowid();";
                var reviewId = await connection.QueryFirstOrDefaultAsync<int>(sqlQuery, review);
                return reviewId;
            }
        }
        public async Task<bool> UpdateReviewAsync(Review review)
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = @"
                    UPDATE Reviews
                    SET Rating = @Rating, Comment = @Comment, 
                        TutorId = @TutorId, StudentId = @StudentId,
                        CreatedAt = @CreatedAt, UpdatedAt = @UpdatedAt
                    WHERE ReviewId = @ReviewId";
                review.UpdatedAt = DateTime.UtcNow;
                var changedRows = await connection.ExecuteAsync(sqlQuery, review);
                return changedRows > 0;
            }
        }
        public async Task<bool> DeleteReviewAsync(int reviewId)
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = @"
                    DELETE FROM Reviews
                    WHERE ReviewId = @ReviewId";
                var changedRows = await connection.ExecuteAsync(sqlQuery, new {ReviewId = reviewId});
                return changedRows > 0;
            }
        }
    }
}