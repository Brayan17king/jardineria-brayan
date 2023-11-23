using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UnitOfWork;
using AspNetCoreRateLimit;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) => services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin() // WithOrigins("https://domain.com")
                .AllowAnyMethod() // WithMethods("GET", "POST")
                .AllowAnyHeader(); // WithHeaders("accept", "content-type")
            });
        });
        public static void ConfigureRateLimiting(this IServiceCollection services) // 2611
        {
            services.AddMemoryCache();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddInMemoryRateLimiting();
            services.Configure<IpRateLimitOptions>(options =>
            {
                options.EnableEndpointRateLimiting = true;
                options.StackBlockedRequests = false;
                options.HttpStatusCode = 429;
                options.RealIpHeader = "X-Real-IP";
                options.GeneralRules = new List<RateLimitRule>
                {
                    new RateLimitRule
                    {
                        Endpoint = "*",  // Si quiere usar todos ponga *
                        Period = "5s", // Periodo de tiempo para hacer peticiones
                        Limit = 8         // Numero de peticiones durante el periodo de tiempo
                    }
                };
            });
        } 
    }
}