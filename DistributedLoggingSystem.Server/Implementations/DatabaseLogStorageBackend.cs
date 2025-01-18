using DistributedLoggingSystem.Server.Models;
using System;

namespace DistributedLoggingSystem.Server.Implementations
{
    public class DatabaseLogStorageBackend
    {

        public DatabaseLogStorageBackend(/*AppDbContext context*/)
        {
           // _context = context;
        }

        /*public async Task StoreLogAsync(LogEntry logEntry)
        {
            _context.LogEntries.Add(logEntry);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LogEntry>> RetrieveLogsAsync(LogQueryParameters parameters)
        {
            return await _context.LogEntries
                .Where(l =>
                    (string.IsNullOrEmpty(parameters.Service) || l.Service == parameters.Service) &&
                    (string.IsNullOrEmpty(parameters.Level) || l.Level == parameters.Level) &&
                    (!parameters.StartTime.HasValue || l.Timestamp >= parameters.StartTime) &&
                    (!parameters.EndTime.HasValue || l.Timestamp <= parameters.EndTime))
                .ToListAsync();
        }*/
    }
}
