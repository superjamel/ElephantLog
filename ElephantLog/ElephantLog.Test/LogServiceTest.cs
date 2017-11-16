using System;
using System.Collections.Generic;
using System.Text;
using ElephantLog.Domain;
using ElephantLog.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RabbitMQ.Client;
using ElephantLog.Controllers;
using Microsoft.AspNetCore;
using ElephantLog.Test.Integrations;
using Microsoft.AspNetCore.Hosting;

namespace ElephantLog.Test
{
    [TestClass]
    public class LogServiceTest
    {
        [TestMethod]
        public void LogMessage_GivenEventMessage_ShouldWriteMessageToDb()
        {
            //var mock = new Mock<ILogger<LogService>>();
            //var sut = new LogService(mock.Object);

            //var eventToLog = new LogEvent();
            //sut.LogMessage(eventToLog);

            ////mock.Verify(logger => logger.LogInformation(It.IsAny<string>()));
            //Assert.Fail("TODO");
        }
        [TestMethod]
        public void LogMessage_GivenEventMessage_ShouldReceivedMessage()
        {
            using (var webHost = WebHost.CreateDefaultBuilder()
                .UseStartup<IntegrationStartup>()
                .Build())
            {
                var connectionFactory = new ConnectionFactory { HostName = "localhost", Port = 5672 };
                var connection = connectionFactory.CreateConnection();
                var channel = connection.CreateModel();
                channel.BasicPublish(exchange: "Events",
                                routingKey: "audit.info",
                                basicProperties: null,
                                body: Encoding.UTF8.GetBytes("{ \"Body\": \"foobar message\"}"));

                var handled = LogController.LogFlag.WaitOne(1000);
                Assert.IsTrue(handled);
                Assert.AreEqual(1, LogController.Messages.Count);
            }
        }
    }
}
