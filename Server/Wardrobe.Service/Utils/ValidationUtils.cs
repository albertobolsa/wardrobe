namespace Wardrobe.Service.Utils
{
    public class ValidationUtils
    {
        public static bool IsValidString(string value, int maxLength, bool isNullable)
        {
            if (string.IsNullOrEmpty(value))
            {
                return isNullable;
            }

            return value.Length <= maxLength;
        }
    }
}
