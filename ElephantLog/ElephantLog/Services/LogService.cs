using System;
using System.Collections.Generic;
using System.Text;
using ElephantLog.Domain;
using ElephantLog.Repositories;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace ElephantLog.Services
{
    public class LogService : ILogService
    {
        public ILogger<LogService> Log { get; }
        public ILogRepository LogRepository { get; }

        public LogService(ILogger<LogService> log, ILogRepository logRepository)
        {
            Log = log;
            LogRepository = logRepository;
        }

        public void LogMessage(LogEvent logEvent)
        {
            LogRepository.Save(logEvent);
        }
    }
}
