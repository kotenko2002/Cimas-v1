using Cimas.Models.Exception;
using Cimas.Сommon.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cimas.Infrastructure.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (NotFoundException ex)
            {
                await HandleExceptionAsync(
                    httpContext,
                    ex.Message,
                    HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(
                    httpContext,
                    ex.Message,
                    HttpStatusCode.InternalServerError);
            }
        }

        private async Task HandleExceptionAsync(
            HttpContext context,
            string message,
            HttpStatusCode httpStatusCode)
        {
            HttpResponse response = context.Response;

            response.StatusCode = (int)httpStatusCode;

            ErrorResponse errorResponse = new()
            {
                Message = message,
                StatusCode = (int)httpStatusCode
            };

            await response.WriteAsJsonAsync(errorResponse);
        }
    }
}
