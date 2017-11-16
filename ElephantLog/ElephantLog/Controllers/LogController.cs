using System;
using System.Collections.Generic;
using System.Text;
using ElephantLog.Domain;
using ElephantLog.Services;
using Microsoft.AspNetCore.Mvc;
using Dag37.MQ.Lib;
using Microsoft.Extensions.Logging;

namespace ElephantLog.Controllers
{
    public class LogController
    {
        public ILogService LogService { get; }
        public ILogger<LogController> Log { get; }

        public LogController(ILogService logService, ILogger<LogController> log)
        {
            LogService = logService;
            Log = log;
        }

        [Event("Events", "#")]
        public void LogMessage(LogEvent logEvent)
        {
            Log.LogInformation("Received event {0} from {1}", logEvent.Body, logEvent.Server ?? "null");
            if (logEvent.TimeLogged == null)
            {
                logEvent.TimeLogged = DateTime.Now;
            }
            LogService.LogMessage(logEvent);
        }
    }
}
