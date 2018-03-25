using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Wardrobe.DataAccess.Context;
using Wardrobe.Model.Entities.Logging;

namespace Wardrobe.Service.Logging
{
    public class DbLogger : ILogger
    {
        private readonly string _name;
        private readonly string _connectionsString;
        private readonly LogLevel _level;
        
        public DbLogger(string name, LogLevel level, string connectionString)
        {
            _name = name;
            _level = level;
            _connectionsString = connectionString;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            if (logLevel == LogLevel.None)
            {
                return false;
            }

            return (int)logLevel >= (int)_level;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }
            
            var optionsBuilder = new DbContextOptionsBuilder<LogDataContext>();
            optionsBuilder.UseSqlServer(_connectionsString);
            using (var context = new LogDataContext(optionsBuilder.Options))
            {
                context.LogMessages.Add(new LogMessage
                {
                    LogLevel = (int) logLevel,
                    Timestamp = DateTime.UtcNow,
                    Message = formatter(state, exception)
                });
                context.SaveChanges();
            }
        }
    }
}
