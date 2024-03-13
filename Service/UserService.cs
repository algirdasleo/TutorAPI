using TutorAPI.Interfaces;
using TutorAPI.Models;
using Dapper;

namespace TutorAPI.Service
{
    public class UserService
    {
        private readonly IDatabaseService _databaseService;
        private readonly ILogger<UserService> _logger;

        public UserService(IDatabaseService databaseService, ILogger<UserService> logger)
        {
            _databaseService = databaseService;
            _logger = logger;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            using (var connection = _databaseService.CreateConnection())
            {
                await connection.OpenAsync();
                string sqlQuery = "SELECT * FROM Users";
                var users = await connection.QueryAsync<User>(sqlQuery);
                return users.ToList();
            }
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            using (var connection = _databaseService.CreateConnection())
            {
                await connection.OpenAsync();
                string sqlQuery = "SELECT * FROM Users WHERE UserId = @UserId";
                var user = await connection.QueryFirstOrDefaultAsync<User>(sqlQuery, new { UserId = id });
                return user;
            }
        }

        public async Task<User> CreateUserAsync(User user)
        {
            using (var connection = _databaseService.CreateConnection())
            {
                await connection.OpenAsync();
                string sqlQuery = @"
                    INSERT INTO Users (Username, Password, Email, PhoneNumber, UserType, RegistrationDate)
                    VALUES (@Username, @Password, @Email, @PhoneNumber, @UserType, @RegistrationDate);
                    SELECT last_insert_rowid();";
                int userId = await connection.ExecuteScalarAsync<int>(sqlQuery, user);
                user.UserId = userId;
                return user;
            }
        }

        
    }
}