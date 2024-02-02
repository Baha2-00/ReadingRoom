using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ReadingRoom.Context;
using Serilog;
using System.Reflection;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ReadingRoomDBContext>(cnn => cnn.UseSqlServer(builder.Configuration.GetConnectionString("sqlconnect")));

//builder.Services.AddDbContext<BookStoreDBContext>(cnn => cnn.UseMySQL(builder.Configuration.GetConnectionString("mysqlconnect")));
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
string loggerPath = configuration.GetSection("LoggerPath").Value;

Serilog.Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).
                WriteTo.File(loggerPath, rollingInterval: RollingInterval.Day).
               CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    Log.Information("Application Started");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
