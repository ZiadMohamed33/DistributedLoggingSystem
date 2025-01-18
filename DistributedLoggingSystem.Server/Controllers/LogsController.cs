using DistributedLoggingSystem.Server.Interfaces;
using DistributedLoggingSystem.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace DistributedLoggingSystem.Server.Controllers
{
    [ApiController]
    [Route("v1/logs")]
    public class LogsController : ControllerBase
    {
        private readonly ILogStorageBackend _logStorageBackend;

        public LogsController(ILogStorageBackend logStorageBackend)
        {
            _logStorageBackend = logStorageBackend;
        }

        [HttpPost]
        public async Task<IActionResult> StoreLog([FromBody] LogEntry logEntry)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _logStorageBackend.StoreLogAsync(logEntry);
            return Ok(new { message = "Log stored successfully." });
        }

        [HttpGet]
        public async Task<IActionResult> GetLogs([FromQuery] LogQueryParameters parameters)
        {
            var logs = await _logStorageBackend.RetrieveLogsAsync(parameters);
            return Ok(logs);
        }
    }
}
