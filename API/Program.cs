using API.Controllers;
using AspNetCoreRateLimit;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Persistencia.Data;

using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.ConfigureCors();// -Se agrega el la configuracion del cors
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAplicationServices();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureRateLimiting();
//builder.Services.ConfigureVersioning();  
builder.Services.AddDbContext<SkeletonContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("ConexMysql");
    options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app => midware
app.UseHttpsRedirection();
app.UseCors("CorsPolicy"); //- le decimos que use el cors "CorsPolicy"
app.UseAuthorization();
app.UseIpRateLimiting();
app.MapControllers();
app.Run();
     