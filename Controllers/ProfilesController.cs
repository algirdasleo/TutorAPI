using Microsoft.AspNetCore.Mvc;
using TutorAPI.Models;
using TutorAPI.Interfaces;
namespace TutorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileService _profileService;
        public ProfilesController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Profile>>> GetAllProfilesAsync()
        {
            var profiles = await _profileService.GetAllProfilesAsync();
            return Ok(profiles);
        }

        [HttpGet("{profileId}")]
        public async Task<ActionResult<Profile>> GetProfileByIdAsync(int profileId)
        {
            var profile = await _profileService.GetProfileByIdAsync(profileId);
            if (profile == null)
                return NotFound();
            return Ok(profile);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateProfileAsync([FromBody] Profile profile)
        {
            var profileId = await _profileService.CreateProfileAsync(profile);
            return Ok(profileId);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProfileAsync([FromBody] Profile updatedProfile)
        {
            var success = await _profileService.UpdateProfileAsync(updatedProfile);
            if (!success)
                return NotFound();
            return Ok();
        }

        [HttpDelete("{profileId}")]
        public async Task<ActionResult> DeleteProfileAsync(int profileId)
        {
            var success = await _profileService.DeleteProfileAsync(profileId);
            if (!success)
                return NotFound();
            return Ok();
        }
    } 
}