using System;
using Wardrobe.Model.Entities;
using Wardrobe.Service.Interfaces.Validation;
using Wardrobe.Service.Utils;
using V = Wardrobe.Service.Resources.Validation;

namespace Wardrobe.Service.Validation.Entities
{
    public static class ImageValidationExtensions
    {
        public static IValidationResult Validate(this Image image)
        {
            var result = new DictionaryValidationResult();

            if (image.Id == Guid.Empty)
            {
                result.AddError(V.Image_Id, V.Image_Id_Invalid);
            }

            if (!ValidationUtils.IsValidString(image.Name, 200, true))
            {
                result.AddError(V.Image_Name, V.Image_Name_Invalid);
            }

            if (image.ImageFile.Length == 0)
            {
                result.AddError(V.Image_ImageFile, V.Image_ImageFile_Invalid);
            }

            return result;
        }
    }
}
