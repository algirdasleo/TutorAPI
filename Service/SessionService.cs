using TutorAPI.Interfaces;
using TutorAPI.Models;
using Dapper;

namespace TutorAPI.Service
{
    public class SessionService : ISessionService
    {
        private readonly IDatabaseService _databaseService;
        private readonly ILogger<SessionService> _logger;

        public SessionService(IDatabaseService databaseService, ILogger<SessionService> logger)
        {
            _databaseService = databaseService;
            _logger = logger;
        }

        public async Task<Session?> GetSessionByIdAsync(int sessionId)
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = "SELECT * FROM Sessions WHERE SessionId = @SessionId";
                return await connection.QueryFirstOrDefaultAsync<Session>(sqlQuery, new { SessionId = sessionId });
            }
        }

        public async Task<List<Session>> GetSessionsByUserIdAsync(int userId)
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = "SELECT * FROM Sessions WHERE TutorProfileId = @UserId OR StudentProfileId = @UserId";
                return (await connection.QueryAsync<Session>(sqlQuery, new { UserId = userId })).ToList();
            }
        }

        public async Task<int> AddSessionAsync(Session session)
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = @"
                    INSERT INTO Sessions (TutorProfileId, StudentProfileId, Date, Time, Duration, Location, Status)
                    VALUES (@TutorProfileId, @StudentProfileId, @Date, @Time, @Duration, @Location, @Status);
                    SELECT last_insert_rowid();";
                int sessionId = await connection.ExecuteScalarAsync<int>(sqlQuery, session);
                return sessionId;
            }
        }

        public async Task<bool> UpdateSessionAsync(Session session)
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = @"
                    UPDATE Sessions
                    SET TutorProfileId = @TutorProfileId, StudentProfileId = @StudentProfileId, Date = @Date, Time = @Time, Duration = @Duration, Location = @Location, Status = @Status
                    WHERE SessionId = @SessionId";
                int changedRows = await connection.ExecuteAsync(sqlQuery, session);
                return changedRows > 0;
            }
        }

        public async Task<bool> DeleteSessionAsync(int sessionId)
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = "DELETE FROM Sessions WHERE SessionId = @SessionId";
                int changedRows = await connection.ExecuteAsync(sqlQuery, new { SessionId = sessionId });
                return changedRows > 0;
            }
        }
        
        public async Task<bool> UpdateSessionStatusAsync(int sessionId, string status)
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = "UPDATE Sessions SET Status = @Status WHERE SessionId = @SessionId";
                int changedRows = await connection.ExecuteAsync(sqlQuery, new { SessionId = sessionId, Status = status });
                return changedRows > 0;
            }
        }
    }
}