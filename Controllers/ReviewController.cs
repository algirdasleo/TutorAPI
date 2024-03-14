using TutorAPI.Interfaces;
using TutorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TutorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllReviews()
        {
            var reviews = await _reviewService.GetReviewsAsync();
            return Ok(reviews);
        }

        [HttpGet("ById/{reviewId}")]
        public async Task<ActionResult> GetReviewById(int reviewId)
        {
            var review = await _reviewService.GetReviewByReviewId(reviewId);
            if (review == null)
                return NotFound();
            return Ok(review);
        }

        [HttpGet("ByTutorId/{tutorId}")]
        public async Task<ActionResult> GetReviewByTutorId(int tutorId)
        {
            var review = await _reviewService.GetReviewsByTutorId(tutorId);
            if (review == null)
                return NotFound();
            return Ok(review);
        }

        [HttpGet("ByStudentId/{studentId}")]
        public async Task<ActionResult> GetReviewByStudentId(int studentId)
        {
            var review = await _reviewService.GetReviewsByStudentId(studentId);
            if (review == null)
                return NotFound();
            return Ok(review);
        }

        [HttpPost]
        public async Task<ActionResult> CreateReview(Review review)
        {
            var reviewId = await _reviewService.AddReviewAsync(review);
            review.ReviewId = reviewId;
            var actionName = nameof(GetReviewById);
            var routeValues = new {reviewId = reviewId};
            return CreatedAtAction(actionName, routeValues, review);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateReview(Review review)
        {
            var success = await _reviewService.UpdateReviewAsync(review);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{reviewId}")]
        public async Task<ActionResult> DeleteReview(int reviewId)
        {
            var success = await _reviewService.DeleteReviewAsync(reviewId);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }   
}