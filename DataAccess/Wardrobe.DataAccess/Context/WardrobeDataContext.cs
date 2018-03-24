using Microsoft.EntityFrameworkCore;
using Wardrobe.Model.Entities;

namespace Wardrobe.DataAccess.Context
{
    public class WardrobeDataContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }

        public WardrobeDataContext(DbContextOptions<WardrobeDataContext> options) : base(options)
        {

        }
    }
}
