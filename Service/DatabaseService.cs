using TutorAPI.Interfaces;
using Microsoft.Data.Sqlite;
using System.Data.Common;
using Microsoft.Extensions.Configuration;

namespace TutorAPI.Service
{
    public class DatabaseService : IDatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<DbConnection> CreateConnection()
        {
            var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
