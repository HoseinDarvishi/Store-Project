using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Infrastacture.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastacture.EFCore
{
    public class BlogContext: DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        //public DbSet<Article> Articles { get; set; } 

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArticleCategoryMapping).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
