using System;
using Wardrobe.Model.Entities;
using Wardrobe.Service.Interfaces.Validation;
using Wardrobe.Service.Utils;
using V = Wardrobe.Service.Resources.Validation;

namespace Wardrobe.Service.Validation.Entities
{
    public static class LocationValidationExtensions
    {
        public static IValidationResult Validate(this Location location)
        {
            var result = new DictionaryValidationResult();

            if (location.Id == Guid.Empty)
            {
                result.AddError(V.Location_Id, V.Location_Id_Invalid);
            }

            if (!ValidationUtils.IsValidString(location.Name, 200, true))
            {
                result.AddError(V.Location_Name, V.Location_Name_Invalid);
            }

            if (location.Latitude < -90 || location.Latitude > 90)
            {
                result.AddError(V.Location_Latitude, V.Location_Latitude_Invalid);
            }

            if (location.Latitude < -180 || location.Latitude > 180)
            {
                result.AddError(V.Location_Longitude, V.Location_Longitude_Invalid);
            }

            return result;
        }
    }
}