using DistributedLoggingSystem.Server.Models;

namespace DistributedLoggingSystem.Server.Interfaces
{
    public interface ILogStorageBackend
    {
        Task StoreLogAsync(LogEntry logEntry);
        Task<IEnumerable<LogEntry>> RetrieveLogsAsync(LogQueryParameters parameters);
    }
}
