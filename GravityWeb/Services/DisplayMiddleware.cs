using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GravityWeb
{
    public class DisplayMiddleware
    {
        private readonly RequestDelegate _next;
        public DisplayMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, DisplayService displayService)
        {
            httpContext.Response.ContentType = "text/html;charset=utf-8";
            await httpContext.Response.WriteAsync(displayService.Display());
        }
    }
}

