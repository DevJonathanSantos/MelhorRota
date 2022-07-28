using MelhorRota.Data.Context;
using MelhorRota.Interfaces;
using MelhorRota.Repositories;
using MelhorRota.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();
builder.Services.AddTransient<DataContext>();
builder.Services.AddTransient<IAeroportoService, AeroportoService>();
builder.Services.AddTransient<IAeroportoRepository, AeroportoRepository>();

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

app.UseRouting();

app.UseCors(option => option.AllowAnyOrigin().AllowAnyHeader()); 

app.UseAuthorization();

app.MapControllers();

app.Run();
