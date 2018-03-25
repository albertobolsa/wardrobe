using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wardrobe.Model.Entities.Logging
{
    [Table("LogMessage")]
    public class LogMessage
    {
        public int Id { get; set; }
        public int LogLevel { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
