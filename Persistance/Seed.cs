using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Persistance;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Toilets.Any()) return;

            var Toilets = new List<Toilet>
            {
                new Toilet
                {
                    Title = "Past Toilet 1",
                    CreatedAt = DateTime.Now,
                    City = "London",
                },
                new Toilet
                {
                    Title = "Past Toilet 2",
                    CreatedAt = DateTime.Now,
                    City = "Paris",
                },
                new Toilet
                {
                    Title = "Future Toilet 1",
                    CreatedAt = DateTime.Now,
                    City = "London",
                },
                new Toilet
                {
                    Title = "Future Toilet 2",
                    CreatedAt = DateTime.Now,
                    City = "London",
                },
                new Toilet
                {
                    Title = "Future Toilet 3",
                    CreatedAt = DateTime.Now,
                    City = "London",
                },
                new Toilet
                {
                    Title = "Future Toilet 4",
                    CreatedAt = DateTime.Now,
                    City = "London",
                },
                new Toilet
                {
                    Title = "Future Toilet 5",
                    CreatedAt = DateTime.Now,
                    City = "London",
                },
                new Toilet
                {
                    Title = "Future Toilet 6",
                    CreatedAt = DateTime.Now,
                    City = "London",
                },
                new Toilet
                {
                    Title = "Future Toilet 7",
                    CreatedAt = DateTime.Now,
                    City = "London",},
                new Toilet
                {
                    Title = "Future Activity 8",
                    CreatedAt = DateTime.Now,
                    City = "London",
                }
            };

            await context.Toilets.AddRangeAsync(Toilets);
            await context.SaveChangesAsync();
        }
    }
}