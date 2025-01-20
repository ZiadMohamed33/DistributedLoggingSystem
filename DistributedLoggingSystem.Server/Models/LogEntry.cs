using System.ComponentModel.DataAnnotations;

namespace DistributedLoggingSystem.Server.Models
{
    public class LogEntry
    {
        [Key]
        public int Id { get; set; } // Primary Key
        public string Service { get; set; }
        public string Level { get; set; } 
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
