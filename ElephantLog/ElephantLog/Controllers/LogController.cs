using System;
using System.Collections.Generic;
using System.Text;
using ElephantLog.Domain;
using ElephantLog.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public IActionResult LogMessage([FromBody] LogEvent logEvent)
        {
            LogService.LogMessage(logEvent);
            return Ok();
        }
    }
}
