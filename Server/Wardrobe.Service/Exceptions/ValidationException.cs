using System;
using Wardrobe.Service.Interfaces.Validation;

namespace Wardrobe.Service.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(IValidationResult validationResult)
            : base(validationResult.GetValidationResult())
        {
        }
    }
}
