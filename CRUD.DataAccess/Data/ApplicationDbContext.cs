using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_NwDb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CRUD.Models.Models;
using CRUD_NwDb.RolesConfig;

namespace CRUD.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // Here, configuration paramaters are passed for configuration of our database
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}
