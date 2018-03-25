using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace Wardrobe.Service.Logging
{
    public class DbLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, DbLogger> _loggers = new ConcurrentDictionary<string, DbLogger>();
        private readonly LogLevel _level;
        private readonly string _connectionString;

        public DbLoggerProvider(LogLevel level, string connectionString)
        {
            _level = level;
            _connectionString = connectionString;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new DbLogger(name, _level, _connectionString));
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}
