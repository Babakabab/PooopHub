using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;
using Persistance;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {

            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser { DisplayName = "Bob", UserName = "Bob", Email = "Baba@mail.com" },
                    new AppUser { DisplayName = "Babak", UserName = "Babak", Email = "Ba@mail.com" },
                    new AppUser { DisplayName = "Baboon", UserName = "Baboon", Email = "B@mail.com" },
                    new AppUser { DisplayName = "BobMan", UserName = "BobMan", Email = "Babaaaa@mail.com" },
                    new AppUser { DisplayName = "Bobbby", UserName = "Bobbby", Email = "Babak@mail.com" },
                    new AppUser { DisplayName = "Bobs", UserName = "Bobs", Email = "Babak@mail.com" },
                    new AppUser { DisplayName = "Bobbie", UserName = "Bobbie", Email = "Babak@mail.com" },
                    new AppUser { DisplayName = "Bobbo", UserName = "Bobbo", Email = "Babak@mail.com" },
                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$Word123");
                }
            }
            if (context.Toilets.Any()) return;

            var Toilets = new List<Toilet>
            {
                new Toilet
                {
                    Title = "Past Toilet 1",
                    CreatedAt = DateTime.Now,
                    Country = "Iran"
                },
                new Toilet
                {
                    Title = "Past Toilet 2",
                    CreatedAt = DateTime.Now,
                    Country = "Iran"
                },
                new Toilet
                {
                    Title = "Future Toilet 1",
                    CreatedAt = DateTime.Now,
                    Country = "Iran"
                },
                new Toilet
                {
                    Title = "Future Toilet 2",
                    CreatedAt = DateTime.Now,
                    Country = "Iran"
                },
                new Toilet
                {
                    Title = "Future Toilet 3",
                    CreatedAt = DateTime.Now,
                    Country = "Iran"
                },
                new Toilet
                {
                    Title = "Future Toilet 4",
                    CreatedAt = DateTime.Now,
                    Country = "Iran"
                },
                new Toilet
                {
                    Title = "Future Toilet 5",
                    CreatedAt = DateTime.Now,
                    Country = "Iran"
                },
                new Toilet
                {
                    Title = "Future Toilet 6",
                    CreatedAt = DateTime.Now,
                    Country = "Iran"
                },
                new Toilet
                {
                    Title = "Future Toilet 7",
                    CreatedAt = DateTime.Now,
                    Country = "Iran"
                    },
                new Toilet
                {
                    Title = "Future Activity 8",
                    CreatedAt = DateTime.Now,
                    Country = "Iran"
                }
            };

            await context.Toilets.AddRangeAsync(Toilets);
            await context.SaveChangesAsync();
        }
    }
}