using System;
using System.Collections.Generic;
using System.Text;
using ElephantLog.Domain;

namespace ElephantLog.Services
{
    public interface ILogService
    {
        void LogMessage(LogEvent logEvent);
    }
}
