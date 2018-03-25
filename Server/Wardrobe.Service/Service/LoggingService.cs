using System.Collections.Generic;
using System.Linq;
using Wardrobe.DataAccess.Interfaces;
using Wardrobe.Model.Entities.Logging;
using Wardrobe.Service.Interfaces;

namespace Wardrobe.Service.Service
{
    public class LoggingService : ILoggingService
    {
        private readonly ILoggingRepository _repository;
        public LoggingService(ILoggingRepository repository)
        {
            _repository = repository;
        }

        public List<LogMessage> GetLogMessages()
        {
            return _repository.GetLogMessages().OrderByDescending(l => l.Timestamp).ToList();
        }

        public LogMessage GetLogMessageById(int logMessageId)
        {
            return _repository.GetLogMessageById(logMessageId);
        }

        public void AddLogMessage(LogMessage logMessage)
        {
            _repository.AddLogMessage(logMessage);
        }

        public void UpdateLogMessage(int id, LogMessage logMessage)
        {
            _repository.UpdateLogMessage(id, logMessage);
        }

        public void DeleteLogMessage(int id)
        {
            _repository.DeleteLogMessage(id);
        }
    }
}
