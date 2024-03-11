using TutorAPI.Interfaces;
using Microsoft.Data.Sqlite;
using System.Data;

namespace TutorAPI.Service
{
    public class DatabaseService : IDatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IDbConnection CreateConnection() =>
            new SqliteConnection(_connectionString);
    }
}