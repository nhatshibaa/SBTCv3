#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SBTCv3.Models;

namespace SBTCv3.Data
{
    public class SBTCv3Context : DbContext
    {
        public SBTCv3Context (DbContextOptions<SBTCv3Context> options)
            : base(options)
        {
        }

        public DbSet<SBTCv3.Models.Ticket> Ticket { get; set; }

        public DbSet<SBTCv3.Models.Cart> Cart { get; set; }
    }
}
