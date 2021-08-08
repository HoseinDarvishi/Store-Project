using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductPictureAgg;
using System;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class ProductPictureMapping : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> b)
        {
            b.ToTable("ProductPictures");

            b.Property(x => x.Picture).HasMaxLength(700).IsRequired();
            b.Property(x => x.PictureAlt).HasMaxLength(400).IsRequired();
            b.Property(x => x.PictureTitle).HasMaxLength(400).IsRequired();
            b.Property(x => x.ProductId).IsRequired();

            b.HasOne(x => x.Product).WithMany(x => x.Pictures).HasForeignKey(x => x.ProductId);
        }
    }
}
