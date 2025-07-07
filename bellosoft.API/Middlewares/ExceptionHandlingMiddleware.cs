using bellosoft.Domain.Entities.Errors;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace bellosoft.API.Middlewares
{
    public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled error");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var (status, title) = exception switch
            {
                NotFoundException => (HttpStatusCode.NotFound, "Resource not found"),
                BadRequestException => (HttpStatusCode.BadRequest, "Invalid request"),
                _ => (HttpStatusCode.InternalServerError, "Internal server error")
            };

            var problem = new ProblemDetails
            {
                Status = (int)status,
                Title = title,
                Detail = exception.Message,
                Instance = context.Request.Path,
                Type = $"https://httpstatuses.com/{(int)status}"
            };

            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = (int)status;

            var result = JsonSerializer.Serialize(problem);
            return context.Response.WriteAsync(result);
        }
    }
}
