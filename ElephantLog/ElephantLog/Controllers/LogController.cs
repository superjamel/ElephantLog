using System;
using System.Collections.Generic;
using System.Text;
using ElephantLog.Domain;
using ElephantLog.Services;
using Microsoft.AspNetCore.Mvc;
using Dag37.MQ.Lib;

namespace ElephantLog.Controllers
{
    [Route("log")]
    public class LogController : Controller
    {
        public ILogService LogService { get; }

        public LogController(ILogService logService)
        {
            LogService = logService;
        }

        [Event("Event", "#")]
        public void LogMessage(LogEvent logEvent)
        {
            if (logEvent.TimeLogged == null)
            {
                logEvent.TimeLogged = DateTime.Now;
            }
            LogService.LogMessage(logEvent);
        }
    }
}
