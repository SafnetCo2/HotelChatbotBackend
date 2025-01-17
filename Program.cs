using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using HotelChatbotBackend.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        // Allow specific origins, you can replace with actual allowed origin.
        policy.WithOrigins("https://hotelchatbot-1.onrender.com") // Allow Render URL
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Load the connection string from the configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"), // Fetch connection string from appsettings.json
        new MySqlServerVersion(new Version(8, 0, 33)),
        mySqlOptions => mySqlOptions.EnableRetryOnFailure()
    )
);

// Register services
builder.Services.AddControllers();

var app = builder.Build();

// Use CORS middleware
app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
