using TutorAPI.Interfaces;
using TutorAPI.Models;
using Dapper;

namespace TutorAPI.Service
{
    public class StudentProfileService : IStudentProfileService
    {
        private readonly IDatabaseService _databaseService;
        private readonly ILogger<StudentProfileService> _logger;

        public StudentProfileService (IDatabaseService databaseService, ILogger<StudentProfileService> logger)
        {
            _databaseService = databaseService;
            _logger = logger;
        }

        public async Task<List<StudentProfile>> GetStudentProfilesAsync()
        {
            using (var connection = _databaseService.CreateConnection())
            {
                await connection.OpenAsync();
                string sqlQuery = "SELECT * FROM StudentProfiles";
                var studentProfiles = await connection.QueryAsync<StudentProfile>(sqlQuery);
                return studentProfiles.ToList();
            }
        }

        public async Task<StudentProfile?> GetStudentProfileByProfileId(int profileId)
        {
            using (var connection = _databaseService.CreateConnection())
            {
                await connection.OpenAsync();
                string sqlQuery = "SELECT * FROM StudentProfiles WHERE ProfileId = @ProfileId";
                var studentProfile = await connection.QueryFirstOrDefaultAsync<StudentProfile>(sqlQuery, new { ProfileId = profileId });
                return studentProfile;
            }
        }
        
        public async Task<StudentProfile?> GetStudentProfileByUserId(int userId)
        {
            using (var connection = _databaseService.CreateConnection())
            {
                await connection.OpenAsync();
                string sqlQuery = "SELECT * FROM StudentProfiles WHERE UserId = @UserId";
                var studentProfile = await connection.QueryFirstOrDefaultAsync<StudentProfile>(sqlQuery, new { UserId = userId });
                return studentProfile;
            }
        }
        
        public async Task<int> AddStudentProfileAsync(StudentProfile studentProfile)
        {
            using (var connection = _databaseService.CreateConnection())
            {
                await connection.OpenAsync();
                string sqlQuery = @"
                    INSERT INTO StudentProfiles (UserId, Grade)
                    VALUES (@UserId, @Grade);
                    SELECT last_insert_rowid();";
                int profileId = await connection.ExecuteScalarAsync<int>(sqlQuery, studentProfile);
                return profileId;
            }
        }
        
        public async Task<bool> UpdateStudentProfileAsync(StudentProfile studentProfile)
        {
            using (var connection = _databaseService.CreateConnection())
            {
                await connection.OpenAsync();
                string sqlQuery = @"
                    UPDATE StudentProfiles
                    SET Grade = @Grade
                    WHERE ProfileId = @ProfileId;";
                int changedRows = await connection.ExecuteAsync(sqlQuery, studentProfile);
                return changedRows == 1;
            }
        }
        
        public async Task<bool> DeleteStudentProfileAsync(int profileId)
        {
            using (var connection = _databaseService.CreateConnection())
            {
                await connection.OpenAsync();
                string sqlQuery = "DELETE FROM StudentProfiles WHERE ProfileId = @ProfileId";
                int changedRows = await connection.ExecuteAsync(sqlQuery, new { ProfileId = profileId });
                return changedRows > 0;
            }
        }
        
    }
}