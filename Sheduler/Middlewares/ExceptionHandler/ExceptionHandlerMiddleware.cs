using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sheduler.Middlewares.ExceptionHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Sheduler.Middlewares.ExceptionHandler
{
    public class ExceptionHandlingMiddleware
    {
        private RequestDelegate Next { get; }
        private ILogger<ExceptionHandlingMiddleware> Logger { get; }

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            Next = next ?? throw new ArgumentNullException(nameof(next));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await Next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string[] messages;

            if (exception is RestException restException)
            {
                Logger.LogError(exception, "Rest error");
                context.Response.StatusCode = (int) restException.Code;
            }
            else
            {
                Logger.LogError(exception, "Server error");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            
            context.Response.ContentType = "appliation/json";

            string responce = JsonConvert.SerializeObject(new { errors = new { Rest = new string[] {exception.Message} } });
            
            await context.Response.WriteAsync(responce);
            
        }
    }
}
