//using Dominio.Interfaces;
//using Infrastructure.Repository;
//using Infrastructure.UnitWork;
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
    }
