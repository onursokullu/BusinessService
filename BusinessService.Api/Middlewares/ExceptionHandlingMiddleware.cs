using System.Net;


namespace BusinessService.Logic.Errors.Common
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AppException ex)
            {
                _logger.LogError($"AppException caught: {ex.Message}");
                context.Response.StatusCode = (int)ex.Error.StatusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(new
                {
                    errorCode = ex.Error.StatusCode,
                    errorMessage = ex.Error.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unhandled exception: {ex.Message}");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(new
                {
                    errorCode = "internalServerError",
                    errorMessage = "An unexpected error occurred"
                });
            }
        }
    }
}
