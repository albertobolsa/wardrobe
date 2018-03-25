using System;
using System.Collections.Generic;
using Wardrobe.Model.Entities;

namespace Wardrobe.DataAccess.Interfaces
{
    public interface IWardrobeRepository
    {
        List<Location> GetLocations(Guid userId);
        Location GetLocationById(Guid locationId);
        void AddLocation(Location location);
        void UpdateLocation(Guid id, Location location);
        void DeleteLocation(Guid id);

        List<ClothingItem> GetClothingItems(Guid userId);
        ClothingItem GetClothingItemById(Guid clothingItemId);
        List<ClothingItem> GetClothingItemsByLocationId(Guid locationId);
        void AddLocation(ClothingItem clothingItem);
        void UpdateClothingItem(Guid id, ClothingItem clothingItem);
        void DeleteClothingItem(Guid id);
    }
}
