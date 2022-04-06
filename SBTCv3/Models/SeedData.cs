using Microsoft.EntityFrameworkCore;
using SBTCv3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace SBTCv3.Models
{
    public static class SeedData
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SBTCv3Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SBTCv3Context>>()))
            {
                // Look for any movies.
                if (context.Ticket.Any())
                {
                    return;   // DB has been seeded
                }

                context.Ticket.AddRange(
                    new Ticket
                    {
                        name = "Vé tàu A01",
                        startLocation = "Hà nội",
                        endLocation = "Hải dương",
                        price = 150,
                        quantity = 11,
                        Time = "11/11/2021 10:00"
                    },

                    new Ticket
                    {
                        name = "Vé tàu C04",
                        startLocation = "Hà nội",
                        endLocation = "Hải dương",
                        price = 10,
                        quantity = 12,
                        Time = "04/01/2021 10:00"
                    },

                    new Ticket
                    {
                        name = "Vé tàu E11",
                        startLocation = "Hà nội",
                        endLocation = "Hải dương",
                        price = 100,
                        quantity = 5,
                        Time = "28/07/2021 10:00"
                    },

                    new Ticket
                    {
                        name = "Vé tàu G012",
                        startLocation = "Hà nội",
                        endLocation = "Hải dương",
                        price = 70,
                        quantity = 7,
                        Time = "24/06/2022 10:00"
                    }
                );
                await context.SaveChangesAsync();
            }
        }
    }
}
