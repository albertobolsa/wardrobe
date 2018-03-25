using System;
using System.Collections.Generic;
using System.Linq;
using Wardrobe.Model.Entities;

namespace Wardrobe.DataAccess.Repository
{
    public partial class WardrobeRepository
    {
        public List<ClothingItem> GetClothingItems(Guid userId)
        {
            return _context.ClothingItems.ToList();
        }

        public ClothingItem GetClothingItemById(Guid clothingItemId)
        {
            return _context.ClothingItems.SingleOrDefault(c => c.Id == clothingItemId);
        }

        public List<ClothingItem> GetClothingItemsByLocationId(Guid locationId)
        {
            return _context.ClothingItems.Where(c => c.LocationId == locationId).ToList();
        }

        public void AddLocation(ClothingItem clothingItem)
        {
            _context.ClothingItems.Add(clothingItem);
            _context.SaveChanges();
        }

        public void UpdateClothingItem(Guid id, ClothingItem clothingItem)
        {
            _context.ClothingItems.Update(clothingItem);
            _context.SaveChanges();
        }

        public void DeleteClothingItem(Guid id)
        {
            _context.ClothingItems.Remove(GetClothingItemById(id));
            _context.SaveChanges();
        }
    }
}