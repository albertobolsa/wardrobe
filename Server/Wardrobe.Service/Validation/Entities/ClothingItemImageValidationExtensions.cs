using System;
using Wardrobe.Model.Entities;
using Wardrobe.Service.Interfaces.Validation;
using V = Wardrobe.Service.Resources.Validation;

namespace Wardrobe.Service.Validation.Entities
{
    public static class ClothingItemImageValidationExtensions
    {
        public static IValidationResult Validate(this ClothingItemImage clothingItemImage)
        {
            var result = new DictionaryValidationResult();

            if (clothingItemImage.ClothingItemId == Guid.Empty)
            {
                result.AddError(V.ClothingItemImage_ClothingItemId, V.ClothingItemImage_ClothingItemId_Empty);
            }

            if (clothingItemImage.ImageId == Guid.Empty)
            {
                result.AddError(V.ClothingItemImage_ImageId, V.ClothingItemImage_ImageId_Empty);
            }

            return result;
        }
    }
}
