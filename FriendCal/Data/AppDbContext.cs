using Microsoft.EntityFrameworkCore;
using FriendCal.Models;

namespace FriendCal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<CalendarEvent> CalendarEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Alice", Username = "alice", Password = "password1" },
                new User { Id = 2, Name = "Bob", Username = "bob", Password = "password2" },
                new User { Id = 3, Name = "Charlie", Username = "charlie", Password = "password3" }
            );
        }
    }
}
