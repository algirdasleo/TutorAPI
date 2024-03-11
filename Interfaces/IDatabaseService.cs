using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;

namespace TutorAPI.Interfaces
{
    public interface IDatabaseService
    {
        IDbConnection CreateConnection();
    }
}