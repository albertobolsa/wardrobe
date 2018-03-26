using System;
using Wardrobe.Model.Entities;
using Wardrobe.Service.Interfaces.Validation;
using Wardrobe.Service.Utils;
using V = Wardrobe.Service.Resources.Validation;

namespace Wardrobe.Service.Validation.Entities
{
    public static class ClothingItemValidationExtensions
    {
        public static IValidationResult Validate(this ClothingItem clothingItem)
        {
            var result = new DictionaryValidationResult();

            if (clothingItem.Id == Guid.Empty)
            {
                result.AddError(V.ClothingItem_Id, V.ClothingItem_Id_Empty);
            }

            if (!ValidationUtils.IsValidString(clothingItem.Type, 200, true))
            {
                result.AddError(V.ClothingItem_Type, V.ClothingItem_Type_Invalid);
            }

            if (!ValidationUtils.IsValidString(clothingItem.Size, 200, true))
            {
                result.AddError(V.ClothingItem_Size, V.ClothingItem_Size_Invalid);
            }

            if (!ValidationUtils.IsValidString(clothingItem.PurchaseLocation, 200, true))
            {
                result.AddError(V.ClothingItem_PurchaseLocation, V.ClothingItem_PurchaseLocation_Invalid);
            }

            if (!ValidationUtils.IsValidString(clothingItem.Currency, 50, true))
            {
                result.AddError(V.ClothingItem_Currency, V.ClothingItem_Currency_Invalid);
            }

            if (!ValidationUtils.IsValidString(clothingItem.Comments, 200, true))
            {
                result.AddError(V.ClothingItem_Comments, V.ClothingItem_Comments_Invalid);
            }

            return result;
        }
    }
}
