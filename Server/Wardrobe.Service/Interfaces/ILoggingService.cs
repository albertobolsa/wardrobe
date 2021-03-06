﻿using System.Collections.Generic;
using Wardrobe.Model.Entities.Logging;

namespace Wardrobe.Service.Interfaces
{
    public interface ILoggingService
    {
        List<LogMessage> GetLogMessages();
        LogMessage GetLogMessageById(int logMessageId);
        void AddLogMessage(LogMessage logMessage);
        void UpdateLogMessage(int id, LogMessage logMessage);
        void DeleteLogMessage(int id);
    }
}
