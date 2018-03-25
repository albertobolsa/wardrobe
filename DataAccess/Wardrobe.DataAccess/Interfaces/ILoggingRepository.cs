using System.Collections.Generic;
using Wardrobe.Model.Entities.Logging;

namespace Wardrobe.DataAccess.Interfaces
{
    public interface ILoggingRepository
    {
        List<LogMessage> GetLogMessages();
        LogMessage GetLogMessageById(int logMessageId);
        void AddLogMessage(LogMessage logMessage);
        void UpdateLogMessage(int id, LogMessage logMessage);
        void DeleteLogMessage(int id);
    }
}
