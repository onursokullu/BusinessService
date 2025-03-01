using System.Net;

namespace BusinessService.Logic.Errors.Common
{
    public class AppError
    {
        public readonly string ErrorKey;

        public readonly string Message;

        public readonly HttpStatusCode StatusCode;

        public AppError(string errorKey, string message)
            : this(HttpStatusCode.BadRequest, errorKey, message)
        {
        }

        public AppError(HttpStatusCode statusCode, string errorKey, string message)
        {
            StatusCode = statusCode;
            ErrorKey = errorKey;
            Message = message;
        }

        public AppError(HttpStatusCode statusCode, string errorKey, string format, params object[] args)
            : this(statusCode, errorKey, string.Format(format, args))
        {
        }
    }
}
