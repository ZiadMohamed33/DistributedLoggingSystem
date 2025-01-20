using DistributedLoggingSystem.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace DistributedLoggingSystem.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<LogEntry> LogEntries { get; set; }

    }
}
