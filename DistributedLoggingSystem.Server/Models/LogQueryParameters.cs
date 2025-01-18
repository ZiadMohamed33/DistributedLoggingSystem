namespace DistributedLoggingSystem.Server.Models
{
    public class LogQueryParameters
    {
        public string Service { get; set; }
        public string Level { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
