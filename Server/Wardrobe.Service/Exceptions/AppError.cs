namespace Wardrobe.Service.Exceptions
{
    public class AppError
    {
        public string Message { get; set; }
        public string Stacktrace { get; set; }

        public AppError(string message, string stacktrace)
        {
            Message = message;
            Stacktrace = stacktrace;
        }
    }
}
