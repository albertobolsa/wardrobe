using System;
using System.Collections.Generic;
using Wardrobe.DataAccess.Interfaces;
using Wardrobe.Model.Entities;
using Wardrobe.Service.Exceptions;
using Wardrobe.Service.Interfaces;
using Wardrobe.Service.Validation.Entities;

namespace Wardrobe.Service.Service
{
    public class ClothingItemService : IClothingItemService
    {
        private readonly IWardrobeRepository _repository;

        public ClothingItemService(IWardrobeRepository repository)
        {
            _repository = repository;
        }

        public List<ClothingItem> GetClothingItems()
        {
            return _repository.GetClothingItems();
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

            var validationResult = clothingItem.Validate();
            if (validationResult.IsValid())
            {
                _repository.AddClothingItem(clothingItem);
            }
            else
            {
                throw new ValidationException(validationResult);
            }
        }

        public void UpdateClothingItem(Guid id, ClothingItem clothingItem)
        {
            var validationResult = clothingItem.Validate();
            if (validationResult.IsValid())
            {
                _repository.UpdateClothingItem(id, clothingItem);
            }
            else
            {
                throw new ValidationException(validationResult);
            }
        }

        public void DeleteClothingItem(Guid id)
        {
            _repository.DeleteClothingItem(id);
        }

        public void TransferClothingItem(TransferItem transferItem)
        {
            var clothingItem = GetClothingItemById(transferItem.ClothingItemId);

            if (clothingItem == null)
            {
                throw new Exception(Resources.Error.ClothingItemService_ClothingItemNotFound);
            }

            clothingItem.LocationId = transferItem.LocationId;

            var validationResult = clothingItem.Validate();
            if (validationResult.IsValid())
            {
                _repository.UpdateClothingItem(clothingItem.Id, clothingItem);
            }
            else
            {
                throw new ValidationException(validationResult);
            }
        }
    }
}
