using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using DealCoin.Models;

namespace DealCoin.Controllers
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MaintenanceMiddleware
    {
        private readonly RequestDelegate _next;
        public MaintenanceMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext,IOptionsSnapshot<MaintenanceOption> _conf)
        {
            if (_conf.Value.Ismaintenance == true)
            {
                await httpContext.Response.WriteAsync("<!doctype html><title> Site Maintenance </title><style>body{text-align: center;padding: 150px;}h1{font-size: 50px;}body{font: 20px Helvetica, sans-serif;color: #333;} article{ display: block;text-align: left;width: 650px;margin: 0 auto;}a{color: #dc8100;text-decoration: none;}a:hover{color: #333;text-decoration: none;}</style><article><h1> We & rsquo; ll be back soon!</h1> <div> <p> Sorry for the inconvenience but we & rsquo; re performing some maintenance at the moment.Otherwise we&rsquo; ll be back online shortly!</p> <p> &mdash; The Team</p></div></article>");
            }
            else
            {
                await _next(httpContext);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MaintenanceMiddlewareExtensions
    {
        public static IApplicationBuilder UseMaintenanceMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MaintenanceMiddleware>();
        }
    }
}
