using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Infrastructure.EFCore.Mapping;

namespace ShopManagement.Infrastructure.EFCore
{
    public class Context : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        //public DbSet<Product> Products { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductCategoryMapping).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
