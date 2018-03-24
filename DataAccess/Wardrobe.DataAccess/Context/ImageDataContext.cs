using Microsoft.EntityFrameworkCore;
using Wardrobe.Model.Entities;

namespace Wardrobe.DataAccess.Context
{
    public class ImageDataContext : DbContext
    {
        public DbSet<Image> Images { get; set; }

        public ImageDataContext(DbContextOptions<ImageDataContext> options) : base(options)
        {
        }
    }
}
