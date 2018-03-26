using System.Collections.Generic;
using System.Linq;
using Wardrobe.Service.Interfaces.Validation;

namespace Wardrobe.Service.Validation
{
    public class DictionaryValidationResult : IValidationResult
    {
        private readonly Dictionary<string, string> _Result = new Dictionary<string, string>();

        public void AddError(string key, string errorMessage)
        {
            _Result[key] = errorMessage;
        }

        public bool IsValid()
        {
            return !_Result.Keys.Any();
        }

        public string GetValidationResult()
        {
            return string.Format("Validation Errors: {0}", string.Join(",", _Result.Select(kvp => string.Format("{0} => {1}", kvp.Key, kvp.Value))));
        }
    }
}
