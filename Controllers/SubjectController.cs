using TutorAPI.Interfaces;
using TutorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TutorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllSubjects()
        {
            var subjects = await _subjectService.GetAllSubjectsAsync();
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSubjectById(int id)
        {
            var subject = await _subjectService.GetSubjectByIdAsync(id);
            if (subject == null)
                return NotFound();
            return Ok(subject);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSubject(Subject subject)
        {
            var subjectId = await _subjectService.CreateSubjectAsync(subject);
            subject.SubjectId = subjectId;
            var actionName = nameof(GetSubjectById);
            var routeValues = new {id = subjectId};
            return CreatedAtAction(actionName, routeValues, subject);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSubject(Subject subject)
        {
            var success = await _subjectService.UpdateSubjectAsync(subject);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{subjectId}")]
        public async Task<ActionResult> DeleteSubject(int subjectId)
        {
            var success = await _subjectService.DeleteSubjectAsync(subjectId);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}