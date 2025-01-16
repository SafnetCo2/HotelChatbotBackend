using Microsoft.EntityFrameworkCore;
using HotelChatbotBackend.Models;

namespace HotelChatbotBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<HotelBooking> HotelBookings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
    }
}
