using TutorAPI.Models;
using System.Threading.Tasks;

namespace TutorAPI.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> AuthenticateUserAsync(string username, string password);
        Task<bool> IsUsernameTakenAsync(string username);
        Task<bool> IsEmailTakenAsync(string email);
        Task<bool> IsPhoneNumberTakenAsync(string phoneNumber);
        Task<bool> ChangePasswordAsync(int id, string oldPassword, string newPassword);
    }
}