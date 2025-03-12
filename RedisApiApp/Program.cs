using RedisApiApp.Models;
using RedisApiApp.Service;
using RedisApiApp.Service.Interfaces;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var redis = ConnectionMultiplexer.Connect("localhost:6379");
builder.Services.AddSingleton<IConnectionMultiplexer>(redis);

builder.Services.AddSingleton<IUserRepositoryService, UserRepositoryService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

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

app.Run();
