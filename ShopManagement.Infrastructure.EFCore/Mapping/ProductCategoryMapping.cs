using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class ProductCategoryMapping : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> b)
        {
            b.ToTable("ProductCategories");
            b.HasKey(x => x.Id);

            b.Property(x => x.Name).HasMaxLength(255).IsRequired();
            b.Property(x => x.Description).HasMaxLength(500);
            b.Property(x => x.Keywords).HasMaxLength(80).IsRequired();
            b.Property(x => x.MetaDescription).HasMaxLength(150).IsRequired();
            b.Property(x => x.Picture).HasMaxLength(1000).IsRequired();
            b.Property(x => x.PictureAlt).HasMaxLength(255);
            b.Property(x => x.PictureTitle).HasMaxLength(500);
            b.Property(x => x.Slug).HasMaxLength(320).IsRequired();

            b.HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
        }
    }
}
