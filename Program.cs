using Microsoft.EntityFrameworkCore;
using HotelChatbotBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext to use MySQL with retry logic enabled
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 33)), // Replace with your MySQL server version
        mysqlOptions => mysqlOptions.EnableRetryOnFailure() // Enable retry logic
    )
);

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
