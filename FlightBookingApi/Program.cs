using FlightBookingApi.Interfaces;
using FlightBookingApi.Services;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Registrations for potential services 
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IBookingService, BookingService>();

 // Connection String Registrations 
builder.Services.AddScoped<IDbConnection>(db =>
      new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnectionString")));


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
