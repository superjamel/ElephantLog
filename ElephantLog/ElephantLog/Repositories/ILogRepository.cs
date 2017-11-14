using System;
using System.Collections.Generic;
using System.Text;
using ElephantLog.Domain;

namespace ElephantLog.Repositories
{
    public interface ILogRepository
    {
        void Save(LogEvent logEvent);
    }
}
