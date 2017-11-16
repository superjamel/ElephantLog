using System;
using System.Collections.Generic;
using System.Text;

namespace ElephantLog.Domain
{
    public class LogEvent
    {
        public string Body { get; set; }
        public string Server { get; set; }
        public DateTime? TimeLogged { get; set; }
    }
}
