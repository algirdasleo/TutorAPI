using TutorAPI.Interfaces;
using TutorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TutorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            var userId = await _userService.CreateUserAsync(user);
            user.UserId = userId;
            var actionName = nameof(GetUserById);
            var routeValues = new { id = userId };
            return CreatedAtAction(actionName, routeValues, user);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateUser(User user)
        {
            var changedRows = await _userService.UpdateUserAsync(user);
            if (changedRows == false)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleted = await _userService.DeleteUserAsync(id);
            if (deleted == false)
                return NotFound();
            return NoContent();
        }
    }
}