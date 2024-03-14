using TutorAPI.Interfaces;
using TutorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TutorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentProfileController : ControllerBase
    {
        private readonly IStudentProfileService _studentProfileService;

        public StudentProfileController(IStudentProfileService studentProfileService)
        {
            _studentProfileService = studentProfileService;
        }

        [HttpGet]
        public async Task<ActionResult> GetStudentProfiles()
        {
            var profiles = await _studentProfileService.GetStudentProfilesAsync();
            return Ok(profiles);
        }

        [HttpGet("ByProfileId/{profileId}")]
        public async Task<ActionResult> GetProfileByProfileId(int profileId)
        {
            var profile = await _studentProfileService.GetStudentProfileByProfileId(profileId);
            if (profile == null)
                return NotFound();
            return Ok(profile);
        }

        [HttpGet("ByUserId/{userId}")]
        public async Task<ActionResult> GetProfileByUserId(int userId)
        {
            var profile = await _studentProfileService.GetStudentProfileByUserId(userId);
            if (profile == null)
                return NotFound();
            return Ok(profile);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProfile(StudentProfile studentProfile)
        {
            var profileId = await _studentProfileService.AddStudentProfileAsync(studentProfile);
            var actionName = nameof(GetProfileByProfileId);
            var routeValues = new {profileId = profileId};
            return CreatedAtAction(actionName, routeValues, studentProfile);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProfile(StudentProfile studentProfile)
        {
            var success = await _studentProfileService.UpdateStudentProfileAsync(studentProfile);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{profileId}")]
        public async Task<ActionResult> DeleteProfile(int profileId)
        {
            var success = await _studentProfileService.DeleteStudentProfileAsync(profileId);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}