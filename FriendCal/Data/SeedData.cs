using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FriendCal.Data;
using FriendCal.Models;

namespace FriendCal
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // Check if the database already has any users
                if (context.Users.Any())
                {
                    return; // Database has been seeded
                }

                // Seed sample users
                context.Users.AddRange(
                    new User { Name = "John", Username = "john@example.com", Password = "password123" },
                    new User { Name = "Jane", Username = "jane@example.com", Password = "password456" },
                    new User { Name = "Alice", Username = "alice@example.com", Password = "password789" }
                );

                context.SaveChanges();
            }
        }
    }
}
