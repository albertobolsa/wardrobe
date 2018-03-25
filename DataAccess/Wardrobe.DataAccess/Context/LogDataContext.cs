using Microsoft.EntityFrameworkCore;
using Wardrobe.Model.Entities.Logging;

namespace Wardrobe.DataAccess.Context
{
    public class LogDataContext : DbContext
    {
        public DbSet<LogMessage> LogMessages { get; set; }

        public LogDataContext(DbContextOptions<LogDataContext> options) : base(options)
        {
        }
    }
}
