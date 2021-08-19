using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.EFCore
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }
        
        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryMapping).Assembly);

            modelBuilder.ApplyConfiguration(new InventoryMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
