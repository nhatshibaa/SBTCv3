using Microsoft.EntityFrameworkCore;
using SBTCv3.Data;

namespace SBTCv3.Models
{
    public static class SeedCart
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SBTCv3Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SBTCv3Context>>()))
            {
                // Look for any movies.
                if (context.Cart.Any())
                {
                    return;   // DB has been seeded
                }

                context.Cart.AddRange(
                    new Cart
                    {
                        
                        Email = "a@gmail.com",
                        IdentityCard = "0123123123112",
                        idTicket = 1,
                        Quantity = 2,
                        createTime = "1989-2-15",
                        exprired = DateTime.Parse("1989-2-12")
                    },

                    new Cart
                    {
                        
                        Email = "a@gmail.com",
                        IdentityCard = "0123123123112",
                        idTicket = 1,
                        Quantity = 2,
                        createTime = "1989-2-15",
                        exprired = DateTime.Parse("1989-2-12")
                    },

                    new Cart
                    {
                        
                        Email = "a@gmail.com",
                        IdentityCard = "0123123123112",
                        idTicket = 1,
                        Quantity = 2,
                        createTime = "1989-2-15",
                        exprired = DateTime.Parse("1989-2-12")
                    },
                   new Cart
                   {
                       
                       Email = "a@gmail.com",
                       IdentityCard = "0123123123112",
                       idTicket = 1,
                       Quantity = 2,
                       createTime = "1989-2-15",
                       exprired = DateTime.Parse("1989-2-12")
                   }
                );
                context.SaveChanges();
            }
        }
    }
}

