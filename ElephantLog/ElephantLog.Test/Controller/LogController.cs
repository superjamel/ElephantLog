using Dag37.MQ.Lib;
using ElephantLog.Domain;
using ElephantLog.Repositories;
using ElephantLog.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ElephantLog.Test
{
    public class LogController
    {
        private ILogger<LogController> Log { get; }
        private LogRepository Repository { get; set; }
        public LogController(ILogger<LogController> log,LogRepository repository)
        {
            Log = log;
            Repository = repository;
        }

        public static List<LogEvent> Messages { get; set; } = new List<LogEvent>();

        public static AutoResetEvent LogFlag = new AutoResetEvent(false);

        [Event("Events", "#")]
        public void HandleLogEvent(LogEvent logMesage)
        {
            Log.LogInformation("Called " + nameof(HandleLogEvent));
            Messages.Add(logMesage);
            LogFlag.Set();
        }

    }
}
