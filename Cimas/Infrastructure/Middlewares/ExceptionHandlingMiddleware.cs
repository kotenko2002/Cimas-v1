using Cimas.Models.Exception;
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
            catch (Exception ex)
            {
                await HandleExceptionAsync(
                    httpContext,
                    ex.Message,
                    HttpStatusCode.InternalServerError,
                    "hello man!");
            }
        }

        private async Task HandleExceptionAsync(
            HttpContext context,
            string exMsg,
            HttpStatusCode httpStatusCode,


            string message)
        {
            HttpResponse response = context.Response;

            response.ContentType = "application/json";
            response.StatusCode = (int)httpStatusCode;

            ErrorResponse errorResponse = new()
            {
                Message = message,
                StatusCode = (int)httpStatusCode
            };

            //string result = JsonSerializer.Serialize(errorResponse);

            await response.WriteAsJsonAsync(errorResponse);
        }
    }
}
