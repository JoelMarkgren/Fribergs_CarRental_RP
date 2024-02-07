using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fribergs_CarRental_RP.Data;

namespace Fribergs_CarRental_RP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Admin> Admins { get; set; } = default!;
        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        
    }
}
