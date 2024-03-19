using TutorAPI.Models;
using TutorAPI.Interfaces;
using Dapper;

namespace TutorAPI.Service
{
    public class ProfileService : IProfileService
    {
        private readonly IDatabaseService _databaseService;

        public ProfileService(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<List<Profile>> GetAllProfilesAsync()
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                var profiles = await connection.QueryAsync<Profile>("SELECT * FROM Profiles");
                return profiles.ToList();
            }
        }

        public async Task<Profile?> GetProfileByIdAsync(int profileId)
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = "SELECT * FROM Profiles WHERE ProfileId = @ProfileId";
                var profile = await connection.QueryFirstOrDefaultAsync<Profile>(sqlQuery, new {ProfileId = profileId});
                return profile;
            }
        }

        public async Task<int> CreateProfileAsync(Profile profile)
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = @"
                    INSERT INTO Profiles (UserId, Description, Grade, Price, Qualifications)
                    VALUES (@UserId, @Description, @Grade, @Price, @Qualifications);
                    SELECT last_insert_rowid()";
                var profileId = await connection.QueryFirstOrDefaultAsync<int>(sqlQuery, profile);
                return profileId;
            }
        }

        public async Task<bool> UpdateProfileAsync(Profile updatedProfile)
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = @"
                UPDATE Profiles
                SET FirstName = @FirstName, LastName = @LastName, Email = @Email, 
                    PhoneNumber = @PhoneNumber, Description = @Description, TutorId = @TutorId
                WHERE ProfileId = @ProfileId";
                var changedRows = await connection.ExecuteAsync(sqlQuery, updatedProfile);
                return changedRows > 0;
            }
        }

        public async Task<bool> DeleteProfileAsync(int profileId)
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = "DELETE FROM Profiles WHERE ProfileId = @ProfileId";
                var changedRows = await connection.ExecuteAsync(sqlQuery, new {ProfileId = profileId});
                return changedRows > 0;
            }
        }
    }
}