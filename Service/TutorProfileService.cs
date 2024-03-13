using TutorAPI.Interfaces;
using TutorAPI.Models;
using Dapper;

namespace TutorAPI.Service
{
    public class TutorProfileService : ITutorProfileService
    {
        private readonly IDatabaseService _databaseService;
        private readonly ILogger<TutorProfileService> _logger;

        public TutorProfileService (IDatabaseService databaseService, ILogger<TutorProfileService> logger)
        {
            _databaseService = databaseService;
            _logger = logger;
        }

        public async Task<List<TutorProfile>> GetTutorProfilesAsync()
        {
            using (var connection = _databaseService.CreateConnection())
            {
                await connection.OpenAsync();
                string sqlQuery = "SELECT * FROM TutorProfiles";
                var tutorProfiles = await connection.QueryAsync<TutorProfile>(sqlQuery);
                return tutorProfiles.ToList();
            }
        }

        public async Task<TutorProfile?> GetTutorProfileByProfileId(int profileId)
        {
            using (var connection = _databaseService.CreateConnection())
            {
                await connection.OpenAsync();
                string sqlQuery = "SELECT * FROM TutorProfiles WHERE ProfileId = @ProfileId";
                var tutorProfile = await connection.QueryFirstOrDefaultAsync<TutorProfile>(sqlQuery, new { ProfileId = profileId });
                return tutorProfile;
            }
        }
        
        public async Task<TutorProfile?> GetTutorProfileByUserId(int userId)
        {
            using (var connection = _databaseService.CreateConnection())
            {
                await connection.OpenAsync();
                string sqlQuery = "SELECT * FROM TutorProfiles WHERE UserId = @UserId";
                var tutorProfile = await connection.QueryFirstOrDefaultAsync<TutorProfile>(sqlQuery, new { UserId = userId });
                return tutorProfile;
            }
        }
        
        public async Task<int> AddTutorProfileAsync(TutorProfile tutorProfile)
        {
            using (var connection = _databaseService.CreateConnection())
            {
                await connection.OpenAsync();
                string sqlQuery = @"
                    INSERT INTO TutorProfiles (UserId, Description, Price, Qualifications)
                    VALUES (@UserId, @Description, @Price, @Qualifications);
                    SELECT last_insert_rowid();";
                int profileId = await connection.ExecuteScalarAsync<int>(sqlQuery, tutorProfile);
                return profileId;
            }
        }

        public async Task<bool> UpdateTutorProfileAsync(TutorProfile tutorProfile)
        {
            using (var connection = _databaseService.CreateConnection())
            {
                await connection.OpenAsync();
                string sqlQuery = @"
                    UPDATE TutorProfiles
                    SET Description = @Description, Price = @Price, Qualifications = @Qualifications
                    WHERE ProfileId = @ProfileId";
                int rowsAffected = await connection.ExecuteAsync(sqlQuery, tutorProfile);
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteTutorProfileAsync(int profileId)
        {
            using (var connection = _databaseService.CreateConnection())
            {
                await connection.OpenAsync();
                string sqlQuery = "DELETE FROM TutorProfiles WHERE ProfileId = @ProfileId";
                int rowsAffected = await connection.ExecuteAsync(sqlQuery, new { ProfileId = profileId });
                return rowsAffected > 0;
            }
        }
    }
}