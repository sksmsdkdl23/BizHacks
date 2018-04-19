using BizHacks.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizHacks.Context
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        { }

        public DbSet<Social> Socials { get; set; }

        public DbSet<Display> Displays { get; set; }

        public DbSet<Search> Searches { get; set; }
    }
}
