using API.Controllers;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Persistencia.Data;

using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.ConfigureCors();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddAplicationServices();
builder.Services.AddSwaggerGen();

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

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
