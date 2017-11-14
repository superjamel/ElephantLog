using System;
using System.Collections.Generic;
using System.Text;
using ElephantLog.Domain;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ElephantLog.Services
{
    public class LogService : ILogService
    {
        public ILogger<LogService> Log { get; }

        public LogService(ILogger<LogService> log)
        {
            Log = log;
        }

        public void LogMessage(LogEvent logEvent)
        {
            Log.LogInformation(JsonConvert.SerializeObject(logEvent));
        }
    }
}
