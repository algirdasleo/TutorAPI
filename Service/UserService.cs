using TutorAPI.Interfaces;
using TutorAPI.Models;
using Dapper;

namespace TutorAPI.Service
{
    public class UserService : IUserService
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
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = "SELECT * FROM Users";
                var users = await connection.QueryAsync<User>(sqlQuery);
                return users.ToList();
            }
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = "SELECT * FROM Users WHERE UserId = @UserId";
                var user = await connection.QueryFirstOrDefaultAsync<User>(sqlQuery, new { UserId = id });
                return user;
            }
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = @"
                    UPDATE Users
                    SET Username = @Username, Password = @Password, Email = @Email, PhoneNumber = @PhoneNumber, UserType = @UserType
                    WHERE UserId = @UserId";
                var changedRows = await connection.ExecuteAsync(sqlQuery, user);
                return changedRows > 0;
            }
        }

        public async Task<int> CreateUserAsync(User user)
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = @"
                    INSERT INTO Users (Username, Password, Email, PhoneNumber, UserType, RegistrationDate)
                    VALUES (@Username, @Password, @Email, @PhoneNumber, @UserType, @RegistrationDate);
                    SELECT last_insert_rowid();";
                int userId = await connection.ExecuteScalarAsync<int>(sqlQuery, user);
                return userId;
            }
        }
        
        public async Task<bool> DeleteUserAsync(int id)
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = "DELETE FROM Users WHERE UserId = @UserId";
                return await connection.ExecuteAsync(sqlQuery, new { UserId = id }) > 0;
            }
        }
    }
}