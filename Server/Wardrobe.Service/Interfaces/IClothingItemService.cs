using System;
using System.Collections.Generic;
using Wardrobe.Model.Entities;

namespace Wardrobe.Service.Interfaces
{
    public interface IClothingItemService
    {
        List<ClothingItem> GetClothingItems();
        ClothingItem GetClothingItemById(Guid clothingItemId);
        List<ClothingItem> GetClothingItemsByLocationId(Guid locationId);
        void AddLocation(ClothingItem clothingItem);
        void UpdateClothingItem(Guid id, ClothingItem clothingItem);
        void DeleteClothingItem(Guid id);
    }
}
