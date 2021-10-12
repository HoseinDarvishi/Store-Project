using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Constract.Comment;
using ShopManagement.Application.Constract.Order;
using ShopManagement.Application.Constract.Product;
using ShopManagement.Application.Constract.ProductCategory;
using ShopManagement.Application.Constract.ProductPicture;
using ShopManagement.Application.Constract.Slide;
using ShopManagement.Configuration.Permissions;
using ShopManagement.Domain.CommentAgg;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.SlideAgg;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repositories;
using StoreQuery.Product;
using StoreQuery.ProductCategory;
using StoreQuery.Query;
using StoreQuery.Slide;
using UtilityFreamwork.Infra;

namespace ShopManagement.Configuration
{
   public class ShopManagementConfigurator
   {
      public static void Configure(IServiceCollection services, string connectionString)
      {
         services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
         services.AddTransient<IArticleCategoryApplication, ProductCategoryApplication>();

         services.AddTransient<IProductApplication, ProductAppliation>();
         services.AddTransient<IProductRepository, ProductRepository>();

         services.AddTransient<IProductPictureApplication, ProductPictureApplication>();
         services.AddTransient<IProductPictureRepository, ProductPictureRepository>();

         services.AddTransient<ISlideRepository, SlideRepository>();
         services.AddTransient<ISlideApplication, SlideApplication>();

         services.AddTransient<ICommentApplication, CommentApplication>();
         services.AddTransient<ICommentRepository, CommentRepository>();

         services.AddTransient<IOrderApplication, OrderApplication>();
         services.AddTransient<IOrderRepository, OrderRepository>();

         //Query
         services.AddTransient<ISlideQuery, SlideQuery>();
         services.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();
         services.AddTransient<IProductQuery, ProductQuery>();

         //Permission
         services.AddTransient<IPermissionExposer, ShopPermissionExposer>();

         //Cart
         services.AddTransient<IComputCart, ComputCart>();
         services.AddSingleton<ICartHolder, CartHolder>();

         services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString, b => b.MigrationsAssembly("ServiceHost")));
      }
   }
}
