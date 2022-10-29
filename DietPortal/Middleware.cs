using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace DietPortal
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;
        ILogger<Middleware> _logger;
        

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }
        
       

       

        public async Task Invoke(HttpContext httpContext, ILogger<Middleware> logger)
        {
            
            _logger = logger;

            try
            {
                await _next(httpContext);
            }
            
            catch (Exception ex)
            {
                _logger.LogError("error from my middleare: " + ex.Message + "stack tracre is: " + ex.StackTrace);
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseOurMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
