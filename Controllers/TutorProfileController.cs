using TutorAPI.Interfaces;
using TutorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TutorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TutorProfileController : ControllerBase
    {
        private readonly ITutorProfileService _tutorProfileService;

        public TutorProfileController(ITutorProfileService tutorProfileService)
        {
            _tutorProfileService = tutorProfileService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetTutorProfiles()
        {
            var profiles = await _tutorProfileService.GetTutorProfilesAsync();
            return  Ok(profiles);
        }

        [HttpGet("ByProfileId/{profileId}")]
        public async Task<IActionResult> GetTutorProfileByProfileId(int profileId)
        {
            var profile = await _tutorProfileService.GetTutorProfileByProfileId(profileId);
            return Ok(profile);
        }

        [HttpGet("ByUserId/{userId}")]
        public async Task<IActionResult> GetTutorProfileByUserId(int userId)
        {
            var profile = await _tutorProfileService.GetTutorProfileByUserId(userId);
            return Ok(profile);
        }        

        [HttpPost]
        public async Task<IActionResult> CreateTutorProfile(TutorProfile profile)
        {
            var profileId = await _tutorProfileService.AddTutorProfileAsync(profile);
            var actionName = nameof(GetTutorProfileByProfileId);
            var routeValues = new { id = profileId };
            return CreatedAtAction(actionName, routeValues, profile);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTutorProfile(TutorProfile profile)
        {
            var success = await _tutorProfileService.UpdateTutorProfileAsync(profile);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{profileId}")]
        public async Task<IActionResult> DeleteTutorProfile(int profileId)
        {
            var success = await _tutorProfileService.DeleteTutorProfileAsync(profileId);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}