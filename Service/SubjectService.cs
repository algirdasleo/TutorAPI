using TutorAPI.Interfaces;
using TutorAPI.Models;
using Dapper;

namespace TutorAPI.Service
{
    public class SubjectService : ISubjectService
    {
        private readonly IDatabaseService _databaseService;
        private readonly ILogger<SubjectService> _logger;
        public SubjectService(IDatabaseService databaseService, ILogger<SubjectService> logger)
        {
            _databaseService = databaseService;
            _logger = logger;
        }

        public async Task<List<Subject>> GetAllSubjectsAsync()
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = "SELECT * FROM Subjects";
                var subjects = await connection.QueryAsync<Subject>(sqlQuery);
                return subjects.ToList();
            }
        }

        public async Task<Subject?> GetSubjectByIdAsync(int id)
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = "SELECT * FROM Subjects WHERE SubjectId = @SubjectId";
                var subject = await connection.QueryFirstOrDefaultAsync<Subject>(sqlQuery, new { SubjectId = id });
                return subject;
            }
        }

        public async Task<int> CreateSubjectAsync(Subject subject)
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = @"
                    INSERT INTO Subjects (Name, Description)
                    VALUES (@Name, @Description);
                    SELECT last_insert_rowid();";
                int subjectId = await connection.ExecuteScalarAsync<int>(sqlQuery, subject);
                return subjectId;
            }
        }

        public async Task<bool> UpdateSubjectAsync(Subject subject)
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = @"
                    UPDATE Subjects
                    SET Name = @Name, Description = @Description
                    WHERE SubjectId = @SubjectId";
                int changedRows = await connection.ExecuteAsync(sqlQuery, subject);
                return changedRows > 0;
            }
        }

        public async Task<bool> DeleteSubjectAsync(int id)
        {
            using (var connection = await _databaseService.CreateConnection())
            {
                string sqlQuery = "DELETE FROM Subjects WHERE SubjectId = @SubjectId";
                int changedRows = await connection.ExecuteAsync(sqlQuery, new { SubjectId = id });
                return changedRows > 0;
            }
        }
    }
}