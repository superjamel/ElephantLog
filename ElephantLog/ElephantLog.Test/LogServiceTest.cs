using System;
using System.Collections.Generic;
using System.Text;
using ElephantLog.Domain;
using ElephantLog.Repositories;
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
            var repo = new Mock<ILogRepository>();
            var sut = new LogService(mock.Object, repo.Object);

            var eventToLog = new LogEvent();
            sut.LogMessage(eventToLog);

            //mock.Verify(logger => logger.LogInformation(It.IsAny<string>()));
            Assert.Fail("TODO");
        }
    }
}
