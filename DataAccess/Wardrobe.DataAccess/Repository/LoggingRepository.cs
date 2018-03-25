using System.Collections.Generic;
using System.Linq;
using Wardrobe.DataAccess.Context;
using Wardrobe.DataAccess.Interfaces;
using Wardrobe.Model.Entities.Logging;

namespace Wardrobe.DataAccess.Repository
{
    public class LoggingRepository : ILoggingRepository
    {
        private readonly LogDataContext _context;
        public LoggingRepository(LogDataContext dbContext)
        {
            _context = dbContext;
        }

        public List<LogMessage> GetLogMessages()
        {
            return _context.LogMessages.ToList();
        }

        public LogMessage GetLogMessageById(int logMessageId)
        {
            return _context.LogMessages.SingleOrDefault(l => l.Id == logMessageId);
        }

        public void AddLogMessage(LogMessage logMessage)
        {
            _context.LogMessages.Add(logMessage);
            _context.SaveChanges();
        }

        public void UpdateLogMessage(int id, LogMessage logMessage)
        {
            _context.LogMessages.Update(logMessage);
            _context.SaveChanges();
        }

        public void DeleteLogMessage(int id)
        {
            _context.LogMessages.Remove(GetLogMessageById(id));
            _context.SaveChanges();
        }
    }
}
