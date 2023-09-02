//using Dominio.Interfaces;
//using Infrastructure.Repository;
//using Infrastructure.UnitWork;
using Aplicacion.UnitOfWork;
using AspNetCoreRateLimit;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
//falta una dependency

using Microsoft.Extensions.DependencyInjection;
namespace API.Controllers;
    public static class ApplicationServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            )
        );
        public static void AddAplicationServices(this IServiceCollection services)
        {
           services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        public static void ConfigureRateLimiting(this IServiceCollection services) 
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
                        Endpoint = "*",
                        Period = "10s",
                        Limit = 2
                    }
                };

            });
        }
    }