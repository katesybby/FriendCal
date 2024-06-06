using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using FriendCal.Models;

namespace FriendCal.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // Look for any users.
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }

                context.Users.AddRange(
                    new User { Name = "Alice", Username = "alice", Password = "password1" },
                    new User { Name = "Bob", Username = "bob", Password = "password2" },
                    new User { Name = "Charlie", Username = "charlie", Password = "password3" }
                );

                context.SaveChanges();
            }
        }
    }
}
