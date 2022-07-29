using MelhorRota.Data.Context;
using MelhorRota.Data.Models;
using MelhorRota.Interfaces;
using MelhorRota.Repositories;
using MelhorRota.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MelhorRota;Trusted_Connection=True;MultipleActiveResultSets=true"));

builder.Services.AddCors();
builder.Services.AddTransient<DataContext>();
builder.Services.AddTransient<IAeroportoService, AeroportoService>();
builder.Services.AddTransient<IAeroportoRepository, AeroportoRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(option => option.AllowAnyOrigin().AllowAnyHeader()); 

app.UseAuthorization();

app.MapControllers();

app.Run();
