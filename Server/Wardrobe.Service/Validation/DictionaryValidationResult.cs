using System.Collections.Generic;
using System.Linq;
using Wardrobe.Service.Interfaces.Validation;

namespace Wardrobe.Service.Validation
{
    public class DictionaryValidationResult : Dictionary<string, string>, IValidationResult
    {
        public void AddError(string key, string errorMessage)
        {
            this[key] = errorMessage;
        }

        public bool IsValid()
        {
            return !Keys.Any();
        }

        public string GetValidationResult()
        {
            return string.Format("Validation Errors: {0}", string.Join(",", this.Select(kvp => string.Format("{0} => {1}", kvp.Key, kvp.Value))));
        }
    }
}
