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

        public void LinkImageToClothingItem(Guid imageId, Guid clothingItemId)
        {
            var link = new ClothingItemImage();
            link.ClothingItemId = clothingItemId;
            link.ImageId = imageId;

            _context.ClothingItemImages.Add(link);
            _context.SaveChanges();
        }

        public void UnlinkImageToClothingItem(Guid imageId, Guid clothingItemId)
        {
            var links = _context.ClothingItemImages.Where(l => l.ImageId == imageId && l.ClothingItemId == clothingItemId);

            foreach (var link in links)
            {
                _context.ClothingItemImages.Remove(link);
            }

            if (links.Any())
            {
                _context.SaveChanges();
            }
        }
    }
}
