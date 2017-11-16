using System;
using System.Collections.Generic;
using System.Text;
using ElephantLog.Domain;
using ElephantLog.Services;
using Microsoft.AspNetCore.Mvc;
using Dag37.MQ.Lib;

namespace ElephantLog.Controllers
{
    public class LogController
    {
        public ILogService LogService { get; }

        public LogController(ILogService logService)
        {
            LogService = logService;
        }

        [Event("Events", "#")]
        public void LogMessage(LogEvent logEvent)
        {
            Console.WriteLine("EVENT");
            LogService.LogMessage(logEvent);
        }
    }
}
