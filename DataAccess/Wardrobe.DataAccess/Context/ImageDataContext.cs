using Microsoft.EntityFrameworkCore;
using Wardrobe.Model.Entities;

namespace Wardrobe.DataAccess.Context
{
    public class ImageDataContext : DbContext
    {
        public DbSet<Image> Images { get; set; }
        public DbSet<ClothingItemImage> ClothingItemImages { get; set; }
       
        public ImageDataContext(DbContextOptions<ImageDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClothingItemImage>().HasKey(c => new { c.ImageId, c.ClothingItemId });
        }
    }
}
