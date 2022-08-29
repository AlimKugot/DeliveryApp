using Microsoft.AspNetCore.Http.Extensions;

namespace InterviewSolution.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            _logger.LogInformation("[{DT}] :: {RequestMethod} request to URL: {URL}", 
                                            DateTime.Now, 
                                            httpContext.Request.Method,
                                            httpContext.Request.GetDisplayUrl());
            await _next(httpContext);
        }
    }
}
