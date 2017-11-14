using System;
using System.Collections.Generic;
using System.Text;
using ElephantLog.Domain;
using ElephantLog.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ElephantLog.Test
{
    [TestClass]
    public class LogServiceTest
    {
        [TestMethod]
        public void LogMessage_GivenEventMessage_ShouldWriteMessageToDb()
        {
            var mock = new Mock<ILogger<LogService>>();
            var sut = new LogService(mock.Object);

            var eventToLog = new LogEvent();
            sut.LogMessage(eventToLog);

            mock.Verify(logger => logger.LogInformation(It.IsAny<string>()));
        }
    }
}
