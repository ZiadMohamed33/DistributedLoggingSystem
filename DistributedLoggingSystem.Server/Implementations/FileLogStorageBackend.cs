using DistributedLoggingSystem.Server.Interfaces;
using DistributedLoggingSystem.Server.Models;
using System.Text.Json;

public class FileLogStorageBackend : ILogStorageBackend
{
    private readonly string _logDirectory;

    public FileLogStorageBackend(IConfiguration configuration)
    {
        _logDirectory = configuration.GetValue<string>("LogDirectory") ?? "/var/logs/distributed_system";
    }

    public async Task StoreLogAsync(LogEntry logEntry)
    {
        var filePath = Path.Combine(_logDirectory, $"{DateTime.UtcNow:yyyy-MM-dd}.log");

        Directory.CreateDirectory(_logDirectory);

        var logData = JsonSerializer.Serialize(logEntry) + Environment.NewLine;

        await File.AppendAllTextAsync(filePath, logData);
    }

    public async Task<IEnumerable<LogEntry>> RetrieveLogsAsync(LogQueryParameters parameters)
    {
        var logFiles = Directory.GetFiles(_logDirectory, "*.log");
        var logs = new List<LogEntry>();

        foreach (var file in logFiles)
        {
            var lines = await File.ReadAllLinesAsync(file);
            foreach (var line in lines)
            {
                var log = JsonSerializer.Deserialize<LogEntry>(line);

                if (log != null &&
                    (string.IsNullOrEmpty(parameters.Service) || log.Service == parameters.Service) &&
                    (string.IsNullOrEmpty(parameters.Level) || log.Level == parameters.Level) &&
                    (!parameters.StartTime.HasValue || log.Timestamp >= parameters.StartTime) &&
                    (!parameters.EndTime.HasValue || log.Timestamp <= parameters.EndTime))
                {
                    logs.Add(log);
                }
            }
        }

        return logs;
    }
}