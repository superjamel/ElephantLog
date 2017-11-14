using System;
using System.Collections.Generic;
using System.Text;
using ElephantLog.Domain;
using ElephantLog.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElephantLog.Test
{
    [TestClass]
    public class LogServiceTest
    {
        [TestMethod]
        public void LogMessage_GivenEventMessage_ShouldWriteMessageToDb()
        {
            var sut = new LogService();

            var eventToLog = new LogEvent();
            sut.LogMessage(eventToLog);

            Assert.Fail("TODO");
        }
    }
}
