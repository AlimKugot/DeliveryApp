using InterviewSolution.Dto;
using System.Net;
using System.Text.Json;

namespace InterviewSolution.Middleware
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

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e.Message, HttpStatusCode.InternalServerError, "Internal server error");
            }
        }

        private async Task HandleExceptionAsync(
            HttpContext httpContext,
            string exceptionMsg,
            HttpStatusCode httpStatusCode,
            string message)
        {
            _logger.LogError("[{DT}] :: Exception message: {MSG}", DateTime.Now, exceptionMsg);

            HttpResponse response = httpContext.Response;

            response.ContentType = "application/json";
            response.StatusCode = (int)httpStatusCode;

            ErrorDto errorDto = new()
            {
                Message = message,
                StatusCode = (int)httpStatusCode
            };

            string result = JsonSerializer.Serialize(errorDto);

            await response.WriteAsJsonAsync(result);
        }
    }
}
