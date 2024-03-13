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

        public DbConnection CreateConnection() => new SqliteConnection(_connectionString);
    }
}
