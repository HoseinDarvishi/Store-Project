using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.CommentAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> b)
        {
            b.ToTable("ProductComments");
            b.HasKey(x => x.Id);

            b.Property(x => x.Name).HasMaxLength(50).IsRequired();
            b.Property(x => x.Email).HasMaxLength(255).IsRequired();
            b.Property(x => x.Message).HasMaxLength(1500).IsRequired();

            b.HasOne(x => x.Prodcut).WithMany(x => x.Comments).HasForeignKey(x => x.ProductId);
        }
    }
}
