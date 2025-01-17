using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using HotelChatbotBackend.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

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

// Configure middleware
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
