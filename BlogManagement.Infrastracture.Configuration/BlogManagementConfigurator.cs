using BlogManagement.Application;
using BlogManagement.Application.Constract.Article;
using BlogManagement.Application.Constract.ArticleCategory;
using BlogManagement.Application.Constract.ArticleComment;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Domain.ArticleCommentAgg;
using BlogManagement.Infrastacture.EFCore;
using BlogManagement.Infrastacture.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StoreQuery.Article;
using StoreQuery.Query;
using UtilityFreamwork.Infra;

namespace BlogManagement.Infrastracture.Configuration
{
   public class BlogManagementConfigurator
   {
      public static void Configure(IServiceCollection services, string connectionString)
      {
         services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
         services.AddTransient<Application.Constract.ArticleCategory.IArticleCategoryApplication, ArticleCategoryApplication>();

         services.AddTransient<IArticleRepository, ArticleRepository>();
         services.AddTransient<Application.Constract.Article.IArticleApplication, ArticleApplication>();

         services.AddTransient<Application.Constract.ArticleComment.IArticleCommentApplication, ArticleCommentApplication>();
         services.AddTransient<Domain.ArticleCommentAgg.IArticleCommentRepository, ArticleCommentRepository>();

         services.AddTransient<IArticleQuery, ArticleQuery>();

         services.AddTransient<IPermissionExposer, BlogPermissionExposer>();

         services.AddDbContext<BlogContext>(x => x.UseSqlServer(connectionString, b => b.MigrationsAssembly("ServiceHost")));
      }
   }
}
