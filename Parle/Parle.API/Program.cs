using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Parle.Domain.Services;
using Parle.Infrastructure.Context;
using Parle.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ParleContext>(options =>
{
    var migrationsAssembly = typeof(ParleContext).GetTypeInfo().Assembly.GetName().Name;
    var connectionString = builder.Configuration.GetConnectionString("SqlLite");
    options.UseSqlite(connectionString, sqlLiteOptions =>
    {
        sqlLiteOptions.MigrationsAssembly(migrationsAssembly);
    });
    //TODO ROCKY CAN EXPLAIN LATER 
}, ServiceLifetime.Scoped, ServiceLifetime.Scoped);
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

//TODO ROCKY CAN EXPLAIN LATER (Singleton vs Scoped)
builder.Services.AddScoped<IMenuService, MenuService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();