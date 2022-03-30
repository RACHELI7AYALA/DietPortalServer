using BL;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietPortal
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware1
    {
        private readonly RequestDelegate _next;
        IRatingBl rbl;
        public Middleware1(RequestDelegate next)
        {
            _next = next;
        }

        public async Task<Task> Invoke(HttpContext httpContext, IRatingBl iratingbl)
        {
            this.rbl = iratingbl;
            Rating r = new Rating();
            r.Host = httpContext.Request.Host.ToString();
            r.Method = httpContext.Request.Method.ToString();
            r.Path = httpContext.Request.Path.ToString();
            r.Referer = httpContext.Request.Headers["Referer"].ToString();
            r.UserAgent = httpContext.Request.Headers["User-Agent"].ToString();
            r.RecordDate = DateTime.Now;
            await rbl.AddRequest(r);
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class Middleware1Extensions
    {
        public static IApplicationBuilder UseMiddleware1(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware1>();
        }
    }
}
