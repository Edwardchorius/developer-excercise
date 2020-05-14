
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Web.ExceptionHandlingMiddleware.Models;
using Domain.Abstractions.Exceptions;
using Newtonsoft.Json;

namespace Web.ExceptionHandlingMiddleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ApplicationException ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, ApplicationException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.Body.FlushAsync();

            var response = new ValidationErrorResponse(
                exception.Message,
                new Dictionary<string, string[]>
                {
                    { exception.PropertyName, new[] { exception.Message } }
                });

            var result = JsonConvert.SerializeObject(response);
            await context.Response.WriteAsync(result);
        }
    }
}
