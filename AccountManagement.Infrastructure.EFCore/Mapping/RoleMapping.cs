using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
   public class RoleMapping : IEntityTypeConfiguration<Role>
   {
      public void Configure(EntityTypeBuilder<Role> b)
      {
         b.ToTable("Roles");
         b.HasKey(x => x.Id);

         b.Property(x => x.Name).HasMaxLength(255).IsRequired();

         b.HasMany(x => x.Accounts).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);

         b.OwnsMany(x => x.Permissions, builder =>
         {
            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.Name);
            builder.ToTable("RolePermissions");
            builder.WithOwner(x => x.Role);
         });
      }
   }
}
