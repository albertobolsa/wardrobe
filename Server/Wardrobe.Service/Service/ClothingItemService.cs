using System;
using System.Collections.Generic;
using Wardrobe.DataAccess.Interfaces;
using Wardrobe.Model.Entities;
using Wardrobe.Service.Interfaces;

namespace Wardrobe.Service.Service
{
    public class ClothingItemService : IClothingItemService
    {
        private readonly IWardrobeRepository _repository;
        public ClothingItemService(IWardrobeRepository repository)
        {
            _repository = repository;
        }

        public List<ClothingItem> GetClothingItems(Guid userId)
        {
            return _repository.GetClothingItems(userId);
        }

        public ClothingItem GetClothingItemById(Guid clothingItemId)
        {
            return _repository.GetClothingItemById(clothingItemId);
        }

        public List<ClothingItem> GetClothingItemsByLocationId(Guid locationId)
        {
            return _repository.GetClothingItemsByLocationId(locationId);
        }

        public void AddLocation(ClothingItem clothingItem)
        {
            clothingItem.Id = Guid.NewGuid();
            _repository.AddClothingItem(clothingItem);
        }

        public void UpdateClothingItem(Guid id, ClothingItem clothingItem)
        {
            _repository.UpdateClothingItem(id, clothingItem);
        }

        public void DeleteClothingItem(Guid id)
        {
            _repository.DeleteClothingItem(id);
        }
    }
}
