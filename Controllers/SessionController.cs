using TutorAPI.Interfaces;
using TutorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TutorAPI;

namespace TutorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpGet("BySessionId/{sessionId}")]
        public async Task<ActionResult> GetSessionById(int sessionId)
        {
            var session = await _sessionService.GetSessionByIdAsync(sessionId);
            return Ok(session);
        }
        
        [HttpGet("ByTutorProfileId/{tutorProfileId}")]
        public async Task<ActionResult> GetSessionsByTutorProfileId(int tutorProfileId)
        {
            var sessions = await _sessionService.GetSessionsByTutorProfileIdAsync(tutorProfileId);
            return Ok(sessions);
        }
        
        [HttpGet("ByStudentProfileId/{studentProfileId}")]
        public async Task<ActionResult> GetSessionsByStudentProfileId(int studentProfileId)
        {
            var sessions = await _sessionService.GetSessionsByStudentProfileIdAsync(studentProfileId);
            return Ok(sessions);
        }
        
        [HttpPost]
        public async Task<ActionResult> AddSession(Session session)
        {
            var sessionId = await _sessionService.AddSessionAsync(session);
            var actionName = nameof(GetSessionById);
            var routeValues = new {sessionId = sessionId};
            return CreatedAtAction(actionName, routeValues, session);
        }
        
        [HttpPut]
        public async Task<ActionResult> UpdateSession(Session session)
        {
            var success = await _sessionService.UpdateSessionAsync(session);
            if (!success)
                return NotFound();
            return NoContent();
        }
        
        [HttpPut("{sessionId}/{status}")]
        public async Task<ActionResult> UpdateSessionStatus(int sessionId, string status)
        {
            var success = await _sessionService.UpdateSessionStatusAsync(sessionId, status);
            if (!success)
                return NotFound();
            return NoContent();
        }
        
        [HttpDelete("{sessionId}")]
        public async Task<ActionResult> DeleteSession(int sessionId)
        {
            var success = await _sessionService.DeleteSessionAsync(sessionId);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}