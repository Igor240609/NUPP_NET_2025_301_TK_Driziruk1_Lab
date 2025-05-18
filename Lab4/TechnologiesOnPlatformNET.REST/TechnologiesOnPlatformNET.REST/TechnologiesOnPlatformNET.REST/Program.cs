using Microsoft.OpenApi.Models;
using TechnologiesOnPlatformNET.Infrastructure.Repositories;
using TechnologiesOnPlatformNET.Infrastructure.Services;
using TechnologiesOnPlatformNET.REST;
using TechnologiesOnPlatformNET.REST.Models;
using TechnologiesOnPlatformNET.REST.Services;
using AutoMapper;
using TechnologiesOnPlatformNET.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TechnologiesDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICrudServiceAsync<>), typeof(CrudServiceAsync<>));


builder.Services.AddScoped<AspNetCoreCrudService>();
builder.Services.AddScoped<DesktopTechnologyCrudService>();
builder.Services.AddScoped<DotNetTechnologyCrudService>();
builder.Services.AddScoped<WebTechnologyCrudService>();
builder.Services.AddScoped<WinFormsCrudService>();

builder.Services.AddSingleton(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfile());
}).CreateMapper());

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
