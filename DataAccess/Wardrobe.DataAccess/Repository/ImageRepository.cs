using System;
using System.Linq;
using Wardrobe.DataAccess.Context;
using Wardrobe.DataAccess.Interfaces;
using Wardrobe.Model.Entities;

namespace Wardrobe.DataAccess.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly ImageDataContext _context;

        public ImageRepository(ImageDataContext dbContext)
        {
            _context = dbContext;
        }

        public Guid AddImage(Image image)
        {
            _context.Add(image);
            _context.SaveChanges();

            return image.Id;
        }

        public Image GetImage(Guid imageId)
        {
            return _context.Images.FirstOrDefault(img => img.Id == imageId);
        }

        public void DeleteImage(Guid imageId)
        {
            _context.Images.Remove(_context.Images.FirstOrDefault(img => img.Id == imageId));
            _context.SaveChanges();
        }
    }
}
