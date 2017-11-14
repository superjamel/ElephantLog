using System;
using System.Collections.Generic;
using System.Text;
using ElephantLog.Domain;
using MongoDB.Driver;

namespace ElephantLog.Repositories
{
    public class LogRepository : ILogRepository
    {
        public IMongoDatabase Database { get; }
        public IMongoCollection<LogEvent> Collection { get; }

        public LogRepository(IMongoDatabase database)
        {
            Database = database;
            Collection = Database.GetCollection<LogEvent>("LogEvents");
        }
        public void Save(LogEvent logEvent)
        {
            Collection.InsertOne(logEvent);
        }
    }
}
