using BlogManagement.Application;
using BlogManagement.Application.Constract.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Infrastacture.EFCore;
using BlogManagement.Infrastacture.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogManagement.Infrastracture.Configuration
{
    public class BlogManagementConfigurator
    {
        public static void Configure(IServiceCollection services , string connectionString)
        {
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();

            services.AddDbContext<BlogContext>(x => x.UseSqlServer(connectionString, b => b.MigrationsAssembly("ServiceHost")));
        }
    }
}
