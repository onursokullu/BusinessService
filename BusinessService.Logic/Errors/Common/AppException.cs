using System.Diagnostics;

namespace BusinessService.Logic.Errors.Common
{
    public class AppException : Exception
    {
        public AppException(AppError error, Exception inner) : base(null, inner)
        {
            Message = error.Message;
            Error = error;
        }

        public AppException(AppError error) : base(null, null)
        {
            Message = error.Message;
            Error = error;
        }

        private readonly StackTrace _stackAtCreation = new StackTrace(true);
        public override string Message { get; }

        public AppError Error { get; set; }

        public override string StackTrace => string.IsNullOrWhiteSpace(base.StackTrace) ? _stackAtCreation.ToString() : base.StackTrace;
    }
}
