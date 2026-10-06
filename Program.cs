using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Repositories;
using MyApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Database
// MySQL + Entity Framework Core
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    try
    {
        options.UseMySql(
            connectionString,
            ServerVersion.AutoDetect(connectionString)
        );
    }
    catch
    {
        options.UseMySql(
            connectionString,
            new MySqlServerVersion(new Version(8, 0, 30))
        );
    }
});

// Repository
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

// Service
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();