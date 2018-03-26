namespace Wardrobe.Service.Interfaces.Validation
{
    public interface IValidationResult
    {
        void AddError(string key, string errorMessage);
        bool IsValid();
        string GetValidationResult();
    }
}
