using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastructure.EFCore.Mapping
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> b)
        {
            b.ToTable("Inventory");
            b.HasKey(x => x.Id);

            b.OwnsMany(x => x.Operations, operation =>
            {
                operation.ToTable("InventoryOperations");
                operation.HasKey(x => x.Id);
                operation.Property(x => x.Description).HasMaxLength(1000);
                operation.WithOwner(x => x.Inventory).HasForeignKey(x => x.InventoryId);
            });
        }
    }
}
