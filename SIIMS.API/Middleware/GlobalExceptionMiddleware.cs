using SIIMS.Domain.Exceptions;
using System.Net;
using SIIMS.API.Models;


namespace SIIMS.API.Middleware
{
    /// <summary>
    /// Middleware that catches all unhandled exceptions
    /// and converts them into proper HTTP responses.
    /// </summary>
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Handles the HTTP request and catches exceptions globally.
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(DomainException ex)
            {
                _logger.LogWarning(ex, "Domain exception occurred.");

                await WriteErrorResponse(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (SIIMS.Application.Common.NotFoundException ex)
            {
                _logger.LogInformation(ex, "Resource not found");

                await WriteErrorResponse(
                    context,
                    HttpStatusCode.NotFound,
                    ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred");

                await WriteErrorResponse(
                context,
                HttpStatusCode.InternalServerError,
                "An unexpected error occurred.");
            }
        }

        public static async Task WriteErrorResponse (HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new ErrorResponse
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
