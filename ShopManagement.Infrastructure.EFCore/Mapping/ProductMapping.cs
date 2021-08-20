using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> b)
        {
            b.ToTable("Products");
            b.HasKey(x => x.Id);

            b.Property(x => x.Name).HasMaxLength(255).IsRequired();
            b.Property(x => x.Slug).HasMaxLength(350).IsRequired();
            b.Property(x => x.Code).HasMaxLength(255);
            b.Property(x => x.Description).HasMaxLength(700).IsRequired();
            b.Property(x => x.Picture).HasMaxLength(500);
            b.Property(x => x.PictureAlt).HasMaxLength(255);
            b.Property(x => x.PictureTitle).HasMaxLength(200);
            b.Property(x => x.ShortDescription).HasMaxLength(100).IsRequired();
            b.Property(x => x.Keywords).HasMaxLength(255).IsRequired();
            b.Property(x => x.MetaDescription).HasMaxLength(500).IsRequired();

            b.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
            b.HasMany(x => x.Pictures).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
        }
    }
}
