using Microsoft.EntityFrameworkCore;
using Wardrobe.Model.Entities;

namespace Wardrobe.DataAccess.Context
{
    public class WardrobeDataContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<ClothingItem> ClothingItems { get; set; }
        public DbSet<Image> Images { get; set; }

        public WardrobeDataContext(DbContextOptions<WardrobeDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClothingItemImage>().HasKey(c => new { c.ImageId, c.ClothingItemId });
        }
    }
}
