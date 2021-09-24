using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
   public class AccountMapping : IEntityTypeConfiguration<Account>
   {
      public void Configure(EntityTypeBuilder<Account> b)
      {
         b.ToTable("Accounts");
         b.HasKey(x => x.Id);

         b.Property(x => x.Fullname).HasMaxLength(100).IsRequired();
         b.Property(x => x.Username).HasMaxLength(100).IsRequired();
         b.Property(x => x.Password).HasMaxLength(1000).IsRequired();
         b.Property(x => x.Picture).HasMaxLength(1000).IsRequired();
         b.Property(x => x.Mobile).HasMaxLength(20).IsRequired();
         b.Property(x => x.Role).IsRequired();
      }
   }
}
