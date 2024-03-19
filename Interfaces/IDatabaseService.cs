using System.Data.Common;

namespace TutorAPI.Interfaces
{
    public interface IDatabaseService
    {
        Task<DbConnection> CreateConnection();
    }
}