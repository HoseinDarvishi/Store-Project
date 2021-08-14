using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountManagement.Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<CustomerDiscount> CustomerDiscounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerDiscountMapping).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
