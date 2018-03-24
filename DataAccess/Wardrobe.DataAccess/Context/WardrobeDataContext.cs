using Microsoft.EntityFrameworkCore;
using Wardrobe.Model.Entities;

namespace Wardrobe.DataAccess.Context
{
    public class WardrobeDataContext : DbContext
    {
        public DbSet<Location> Location { get; set; }

        public WardrobeDataContext(DbContextOptions<WardrobeDataContext> options) : base(options)
        {

        }
    }
}
