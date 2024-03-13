using TutorAPI.Models;
using System.Threading.Tasks;

namespace TutorAPI.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task<int> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
    }
}