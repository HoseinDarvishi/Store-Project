using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
   public class OrderMapping : IEntityTypeConfiguration<Order>
   {
      public void Configure(EntityTypeBuilder<Order> b)
      {
         b.ToTable("Orders");
         b.HasKey(X => X.Id);
         b.Property(x => x.TrackNumber).HasMaxLength(10).IsRequired();

         b.OwnsMany(x => x.Items, b => 
         {
            b.ToTable("OrderItems");
            b.HasKey(x => x.Id);
            b.WithOwner(x => x.Order).HasForeignKey(x => x.OrderId);
         });
      }
   }
}
