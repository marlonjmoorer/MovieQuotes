

using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MovieQuotes.Handlers
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate next;

        public ExceptionHandler(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await response.WriteAsync(JsonConvert.SerializeObject(new
            {
                error = new
                {
                    message = exception.Message,
                    exception = exception.GetType().Name
                }
            }));
        }
    }
}