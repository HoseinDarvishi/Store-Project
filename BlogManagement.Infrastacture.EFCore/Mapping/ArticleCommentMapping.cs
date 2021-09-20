using BlogManagement.Domain.ArticleCommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastacture.EFCore.Mapping
{
    public class ArticleCommentMapping : IEntityTypeConfiguration<ArticleComment>
    {
        public void Configure(EntityTypeBuilder<ArticleComment> b)
        {
            b.ToTable("ArticleComments");
            b.HasKey(x => x.Id);

            b.Property(x => x.Name).HasMaxLength(255).IsRequired();
            b.Property(x => x.Email).HasMaxLength(500).IsRequired();
            b.Property(x => x.Message).HasMaxLength(30000).IsRequired();
            b.Property(x => x.Website).HasMaxLength(500);

            b.HasOne(x => x.Article).WithMany(X => X.Comments).HasForeignKey(x => x.ArticleId);
            b.HasOne(x => x.Parent).WithMany(x => x.Children).HasForeignKey(x => x.ParentId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
